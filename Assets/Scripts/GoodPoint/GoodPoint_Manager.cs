using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;
using System;
//Created in 09/26/2019 by Zijie Zhang

//---<Purpose>---
//script goodpoint objects manager
//---</Purpose>---
//---<LOGS>---

//10/01/2019
//Created basic functions

//01/16/2020
//Still in used in the script

//---</LOGS>---

//---<Bugs or Questions in Mind>---
//---</Bugs or Questions in Mind>---

public class GoodPoint_Manager : MonoBehaviour
{
    private GameObject Tag_Area; //up?left area
    public static GameObject Description_Text; //description text in the bottom
    public static GameObject Keyword_Area; //right where keywords are show

    public static GameObject Background_Image; //background image

    public GameObject Button_Prefab; //button prefab
    public GameObject Keyword_Prefab; //keywords prefab

    public GameObject GoodPoint_Icon; //icon of this app in the bottom bar

    public static List<Character> Characters_List;
    public static GameObject goodpoint;
    private bool New_Status; //if there are new keywords added in this app
    private bool opened = false; //if this is opened


    private void Awake()
    {
        goodpoint = this.gameObject;
        Background_Image = transform.Find("Keyword_Background").gameObject;
        Tag_Area = transform.Find("Nametag_Area").gameObject;
        Description_Text = transform.Find("Description_Area").gameObject;
        Keyword_Area = transform.Find("Keyword_Storage").gameObject; //setu[s
        New_Status = false;
        Characters_List = new List<Character>();

    }
    public class Allocated_Keywords
    {
        public string Keyword;
        public string inner_Text;
        GameObject Reference_Gameobjects; //reference to gameobjects for deletion
        public string description;
        public int priority;
        public bool is_New;

        public Allocated_Keywords(string word, string Inner_Text, string description_Text)
        {
            inner_Text = Inner_Text;
            Keyword = word;
            description = description_Text;
            priority = 0;
            is_New = false;
            //Reference_Gameobjects = gameobject;
            //Reference_Gameobjects.GetComponent<Text>().text = Keyword; //constructor
        }
    }

    public class Character
    {
        public GameObject Tag_Button;
        public string name;
        public List<Allocated_Keywords> Keywords_List;

        public Character(string Name, GameObject Button)
        {
            name = Name;
            Tag_Button = Button;
            Keywords_List = new List<Allocated_Keywords>();
        }
    } //character class

    //string Name, string Word,string Inner_Text
    public void Add_Keyword(string[] Input)
    {
        terms_Onclick();
        New_Status = true;
        GoodPoint_Icon.transform.Find("Hint_Image").GetComponent<Image>().enabled = true;
        string Name = Input[0];
        string Word = Input[1];
        string Inner_Text = Input[2];
        string description = Input[3];
        int priority = Int16.Parse(Input[4]);
        Allocated_Keywords New_Keyword = new Allocated_Keywords(Word, Inner_Text, description);
        if ((!(Characters_List.Any(n => n.name == Name))))
        {
            if (!(Characters_List.Any(n => n.Keywords_List.Any(q=>q.Keyword == Word))))
            {
                GameObject new_Button = Instantiate(Button_Prefab, Tag_Area.transform);
                new_Button.transform.Find("Name").GetComponent<Text>().text = Name;
                //new_Button.transform.SetParent(Tag_Area.transform);
                Character New_Character = new Character(Name, new_Button);
                New_Character.Keywords_List.Add(New_Keyword);
                Characters_List.Add(New_Character);
            }
            else if((Characters_List.Any(n => n.Keywords_List.Any(q => q.Keyword == Word))))
            {
                if(priority> Characters_List.Find(n => n.name == Name).Keywords_List.Find(q => q.Keyword == Word).priority)
                {
                    Characters_List.Find(n => n.name == Name).Keywords_List.Find(q => q.Keyword == Word).description = description;
                    
                }
            }
        }
        else
        {
            if (Characters_List.Find(n => n.name == Name).Keywords_List.Exists(q => q.Keyword == Word))
            {
                if (Characters_List.Find(n => n.name == Name).Keywords_List.Find(q => q.Keyword == Word).priority < priority)
                {
                    Characters_List.Find(n => n.name == Name).Keywords_List.Find(q => q.Keyword == Word).priority = priority;
                    Characters_List.Find(n => n.name == Name).Keywords_List.Find(q => q.Keyword == Word).description = description;
                    Characters_List.Find(n => n.name == Name).Keywords_List.Find(q => q.Keyword == Word).is_New = false;
                }
            }
            else
                Characters_List.Find(n => n.name == Name).Keywords_List.Add(New_Keyword);

        }
        terms_Onclick();
        Characters_List.Find(n => n.name == Name).Tag_Button.GetComponent<Button>().onClick.Invoke();
        //added new keyword
    }

    ///////////////////////////////////////////Button Callbacks///////////////////////////////////////////


    public void GoodPoint_IconClick()
    {
        opened = !opened;
        if (!opened)
        {
            this.transform.localScale = new Vector3(0, 0, 0);
        }
        else
        {
            this.transform.localScale = new Vector3(1, 1, 1);
            this.transform.SetAsLastSibling();
        } //if goodpoint is clicked
    }

    public void terms_Onclick()
    {
        if (Characters_List.Count > 0)
        {
            Characters_List.First().Tag_Button.GetComponent<Button>().onClick.Invoke();
            foreach (Character temp in Characters_List)
                temp.Tag_Button.SetActive(true);
        }
        task_Manager.finished_Button.gameObject.SetActive(false);
        task_Manager.to_DoButton.gameObject.SetActive(false);
        foreach (Transform temp in Keyword_Area.transform)
            Destroy(temp.gameObject);
    }

    public void tasks_Onclick()
    {
        if (Characters_List.Count > 0)
        {
            foreach (Character temp in Characters_List)
                temp.Tag_Button.SetActive(false);
        }
        
        task_Manager.finished_Button.gameObject.SetActive(true);
        task_Manager.to_DoButton.gameObject.SetActive(true);
        
        foreach (Transform temp in Keyword_Area.transform)
            Destroy(temp.gameObject);
        task_Manager.to_DoButton.onClick.Invoke();

    }
}
        //    New_Status = false;
        //    GoodPoint_Icon.transform.Find("Hint_Image").GetComponent<Image>().enabled = false;
        //    Image[] All_Categories = this.transform.Find("Categories").gameObject.GetComponentsInChildren<Image>();
        //    foreach(Image temp in All_Categories)
        //    {
        //        Debug.Log(temp.gameObject.name);
        //        temp.gameObject.GetComponentInChildren<Text>().enabled = false;

        //        temp.enabled = false;

        //    }

        //    if (Background_Image.activeSelf)
        //    {
        //        Background_Image.SetActive(false);
        //        Description_Text.SetActive(false);
        //        foreach(Transform temp in Keyword_Area.transform)
        //        {
        //            temp.GetComponentInChildren<Text>().enabled = false;
        //            temp.GetComponent<Image>().enabled = false;


        //        }
        //        Tag_Area.SetActive(false);
        //    }
        //    else
        //    {
        //        Background_Image.SetActive(true);
        //        Description_Text.SetActive(true);
        //        foreach (Transform temp in Keyword_Area.transform)
        //        {
        //            temp.GetComponent<Image>().enabled = true;
        //            temp.GetComponentInChildren<Text>().enabled = true;
        //        }
        //        foreach (Image temp in All_Categories)
        //        {
        //            temp.enabled = true;
        //            temp.gameObject.GetComponentInChildren<Text>().enabled = true;
        //        }
        //        //Tag_Area.SetActive(true);
        //    }
        //}

