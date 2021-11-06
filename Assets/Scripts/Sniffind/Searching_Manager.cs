using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using System.Globalization;
using System.Threading;
using System;
using System.Linq;


//Created in 02/05/2020 by Zijie Zhang

//---<Purpose>---
//Having it manage the searching of the Sniffind, which is a big part
//---</Purpose>---
//---<LOGS>---

//02/05/2020
//Created basic features, search suggestion and arrow key suggestion, tab complete, enter to search

//---</LOGS>---

//---<Bugs or Questions in Mind>---
public class Searching_Manager : MonoBehaviour,ISelectHandler,IDeselectHandler //Handler that come in handy
{
    private string Search_Text; //searching text
    private List<GameObject> Search_Result; //search result that should appear
    private GameObject Search_ResultPrefab; //
    private List<string> Keywords_List; //list of all the fucking keywords
    private GameObject Sugestion_Prefab; //prefab for suggestion
    private List<string> Current_Valid_Keywords; //list of current valid keywords
    private Slider Progress_Bar; //slider of progress bar for loading
    private GameObject Searching_Text;//the gameobj of searching text
    private bool Suggesting = false; //is it suggesting?
    public static int current_SuggestedIndex = -1; //selection index for keyword suggestion
    private GameObject Changedcolor_gobj; //gameobj that changed color in sugesstion
    private GameObject Result_Area;

    public static GameObject input_Fieldobj; 

    private void Awake()
    {
        input_Fieldobj = this.gameObject;
        Search_ResultPrefab = Resources.Load<GameObject>("Prefabs/Sniffind/Search_ResultPrefab");
        Search_Result = new List<GameObject>();
        Keywords_List = new List<string>();
        Sugestion_Prefab = Resources.Load<GameObject>("Prefabs/Sniffind/Sugesstion_Prefab");
        Current_Valid_Keywords = new List<string>();
        Progress_Bar = this.transform.Find("Loading_Bar").gameObject.GetComponent<Slider>();
        Searching_Text = Progress_Bar.transform.Find("Text").gameObject;
        Result_Area = this.transform.parent.transform.Find("Result_Area").gameObject;
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return) || Input.GetKeyDown(KeyCode.KeypadEnter))
        {
            if(this.GetComponent<InputField>().text !="")
                On_Search(); //when players press enter and the text is not empty, search, does not work for isfocused check, so i put this out
        }
        if (this.GetComponent<InputField>().isFocused) //if the inputfield is focused
        {
            if (Input.GetKeyDown(KeyCode.Tab)) //if press tab key
            {
                if (Suggesting) //if suggesting
                {
                    this.transform.GetComponent<InputField>().text = Current_Valid_Keywords[current_SuggestedIndex];//auto complete the one that is highlighted
                }
                else
                {
                    this.transform.GetComponent<InputField>().text = Current_Valid_Keywords[0]; //else just auto complete the first one
                    
                }
                this.GetComponent<InputField>().MoveTextEnd(false); //move the cursor to the end
            }
            if (Input.GetKeyDown(KeyCode.UpArrow)) //if press up arrow key, suggest upper one
            {
                current_SuggestedIndex--;
                Suggest_Arrow();
            }
            else if (Input.GetKeyDown(KeyCode.DownArrow)) //if press down arrow key, suggest down one
            {
                current_SuggestedIndex++;
                Suggest_Arrow();
            }

        }

        if (!this.GetComponent<InputField>().isFocused && this.GetComponent<InputField>().text != "" && Input.GetKey(KeyCode.Return))
            On_Search();

    }

    public void On_Search()
    {
        Result_Area.SetActive(true);
        Progress_Bar.gameObject.SetActive(true);
        Progress_Bar.value = 0f; // put the slider back the 0
        StartCoroutine(Search_Progress());
    }

    IEnumerator Search_Progress()
    {
        Searching_Text.transform.localScale = new Vector3(1, 1, 1); //make searching appear
        while (Progress_Bar.value < 1) 
        {
            Progress_Bar.value += 0.1f; //for every 0.05s, +=1 loading
            yield return new WaitForSeconds(0.05f);
        }
        Searching_Text.transform.localScale = new Vector3(0, 0, 0); //searching disappear
        Search_Text = this.transform.Find("Text").GetComponent<Text>().text; //get the current searching text
        Search_Text.ToLower(); //to lower case
        foreach (GameObject temp in Search_Result)
        {
            Destroy(temp); 
        }
        Search_Result.Clear(); //clear last search result

        foreach (GameObject website in Sniffind_Manager.Website_Arrays) //start comparing the search result
        {
            if (website.GetComponent<Website_Manager>().Search_Content.IndexOf(Search_Text, StringComparison.OrdinalIgnoreCase) >= 0) //if one of the word matched
            {
                if (Keywords_List.Any(n=> n.Equals(Search_Text, StringComparison.OrdinalIgnoreCase)))
                {
                    GameObject temp = Instantiate(Search_ResultPrefab, Sniffind_Manager.Search_ResultArea.transform); //added to the search result area
                    if (website.GetComponent<Website_Manager>().message == "")
                        temp.transform.Find("Title").GetComponent<Button>().onClick.AddListener(() => website.GetComponent<Website_Manager>().Show_Websites_Onclick()); //added onclick on the title
                    else
                        temp.transform.Find("Title").GetComponent<Button>().onClick.AddListener(() => website.SendMessage(website.GetComponent<Website_Manager>().message));

                    temp.transform.Find("Title").gameObject.GetComponent<Text>().text = website.GetComponent<Website_Manager>().Search_Title; //title equal to website's title
                    temp.transform.Find("Content").gameObject.GetComponent<Text>().text = website.GetComponent<Website_Manager>().Search_Content + "..."; //content equal to the content with...
                    Search_Result.Add(temp); //added the search result list for later usage
                }
            }

        }
        Sniffind_Manager.Search_ResultArea.transform.Find("Search_Result").Find("Num").GetComponent<Text>().text = Search_Result.Count.ToString(); //calculate how many search results are there

        this.GetComponent<InputField>().ActivateInputField(); //focus back to the input 
        yield return null; //wait 1 frame before move cursor to the end, super important, else it wouldn't work
        this.GetComponent<InputField>().MoveTextEnd(false); //move cursor to the end
        Progress_Bar.gameObject.SetActive(false);
    }
    public void on_Suggest()
    {
        
        StartCoroutine(Suggest_Progress()); //on value edit, suggest keyword
    }

    IEnumerator Suggest_Progress()
    {
        yield return null; //waited one frame, super important, else get text wouldn't work
        Add_Keywords(); //add goodpoint's keyword to the list
        Keywords_List.Sort(); //sort the keywords

        Search_Text = this.transform.Find("Text").GetComponent<Text>().text; //get current typed text
        Current_Valid_Keywords.Clear(); //clear all last valid keywords
        
        foreach (Transform temp in this.transform.Find("Suggest_Field"))
        {
            Debug.Log(temp.gameObject);
            Destroy(temp.gameObject); //clear all inilize valid keywords
        }
        if (Search_Text != "" &&Search_Text.Length>1 && !Keywords_List.Contains(Search_Text))
        {
            foreach (string keyword in Keywords_List) //start comparsion
            {
                if (keyword.IndexOf(Search_Text, StringComparison.OrdinalIgnoreCase) >= 0)
                {
                    Current_Valid_Keywords.Add(keyword);
                    GameObject new_Suggest = Instantiate(Sugestion_Prefab, this.transform.Find("Suggest_Field"));
                    new_Suggest.transform.Find("Text").GetComponent<Text>().text = keyword;
                } //if substring is valid, added to the keywords and initialize

            }
        }
    }

    private void Add_Keywords()
    {
        Keywords_List.Clear();
        if (GoodPoint_Manager.Characters_List != null) //if characters list not null, added every fucking keywords to the list
        {
            foreach (GoodPoint_Manager.Character temp_charcter in GoodPoint_Manager.Characters_List)
            {
                foreach (GoodPoint_Manager.Allocated_Keywords temp_keyword in temp_charcter.Keywords_List)
                {
                    Keywords_List.Add(temp_keyword.Keyword);
                }
            }
        }
    }

    private void Suggest_Arrow() //suggestion arrow
    {
        Suggesting = true; //suggesting
        GameObject target = this.transform.Find("Suggest_Field").gameObject; //target gameobj that needs to change color
        if (target.transform.childCount > 0)
        {
            if (current_SuggestedIndex < 0)
                current_SuggestedIndex = 0; //if index < 0 , just make it 0
            else if (current_SuggestedIndex > target.transform.childCount - 1)
                current_SuggestedIndex = target.transform.childCount - 1; //if index > length, just make it last one

            Changedcolor_gobj = target.transform.GetChild(current_SuggestedIndex).gameObject;
            target.transform.GetChild(current_SuggestedIndex).GetComponent<Image>().color = Color.cyan; //change the target to cyan
            foreach (Transform temp in target.transform)
            {
                if (temp.GetSiblingIndex() != current_SuggestedIndex)
                    temp.GetComponent<Image>().color = Color.white; //change other back to white

            }
            this.GetComponent<InputField>().MoveTextEnd(false); //move the cursor to the end
        }
    }

    public void OnSelect(BaseEventData eventData) //if select, have a suggestion
    {
        on_Suggest();
    }

    public void OnDeselect(BaseEventData eventData) //if deselect, make the suggestion go away
    {
        Suggesting = false;
        if (this.transform.Find("Suggest_Field").childCount > 0)
        {
            foreach (Transform temp in this.transform.Find("Suggest_Field"))
            {
                Destroy(temp.gameObject);
            }
        }
    }

}
