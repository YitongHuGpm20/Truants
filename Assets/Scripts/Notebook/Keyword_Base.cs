using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
//Created in 11/02/2019 by Zijie Zhang
//---<Purpose>---
//The purpose of this script is to create base script for keywords
//---</Purpose>---
//---<LOGS>---

//---<LOGS>---

//11/02/2019
//Created for keyword, relates to the notebook

//11/05/2019
//Added callbacks for unallocated keywords
//---</LOGS>---

//---<Bugs or Questions in Mind>---
//---</Bugs or Questions in Mind>---

public class Keyword_Base : MonoBehaviour,IPointerDownHandler
{
    [TextArea(3, 4)]
    public string Apparent_Text; // apparent reading text
    [TextArea(3, 4)]
    public string Keyword;//actual keyword

    private Text this_Text; //text component
    public int priority;

    public string Belonging_Character; //which character that belongs to
    private bool Interacted; //if this is clicked

    [TextArea(3, 4)]
    public string Inner_Text; // inner text for keyword
    [TextArea(3, 4)]
    public string Description; //description in GoodPoint
    //private enum Keywords_Type { Adjective, Info, Verb }; 
    //private enum Used_Apps { }; //Not used

    private bool used = false; //if the keywords is used

    private GameObject Duplicate = null;
    private bool finished = false; //variables for moving animations

    private void Awake()
    {
        this_Text = this.GetComponent<Text>();
        this_Text.text = Apparent_Text;
        this_Text.color = Color.red;
        Interacted = false;
    }

    public void OnPointerDown(PointerEventData pointerEventData)
    {
        if (!Interacted)
        {
            this_Text.color = Color.black;
            //Notebook_Base.Add_Keyword_ToCharacter(Belonging_Character, this.Keyword);
            //Notebook_Base.Show_Content();
            Interacted = true;
            this.gameObject.GetComponent<Button>().onClick.Invoke();
            this.gameObject.GetComponent<Button>().interactable = false;
            
            string[] temp = { this.Belonging_Character, this.Keyword, this.Inner_Text, this.Description,this.priority.ToString()};
            //Gameobj_Manager.Unallocated_KeywordsStorage.SendMessage("Add_UnallocatedKeywords", temp); //call add function
            Gameobj_Manager.GoodPoint.SendMessage("Add_Keyword", temp);
        } //if the keywords is not clicked, execute
    }
    //if the text if clicked, change the text color to black

    private void Update()
    {
        if (Interacted &&!used)
        {
            Duplicate = Instantiate(this.gameObject, Gameobj_Manager.Canvas.transform, true);
            //Destroy(Duplicate.GetComponent<Keyword_Base>());
            Duplicate.transform.localScale = new Vector3(1f, 1f, 1f);
            Duplicate.GetComponent<Keyword_Base>().Move_TowardIcon();
            Duplicate.GetComponent<Keyword_Base>().Interacted = true;
            Duplicate.GetComponent<Keyword_Base>().used = true;
            used = true;
            finished = true;
        }

        if (used&&!finished)
        {
            
            Move_TowardIcon();
            
        }


    }

    private void Move_TowardIcon() //functions for moving towards the good point
    {
        GameObject Notebook_Icon = GameObject.Find("GoodpointShortcut");
        this.transform.SetAsLastSibling();
        this.transform.position = Vector3.MoveTowards(this.transform.position, Notebook_Icon.transform.position, 0.3f);

        if (Vector3.Distance(this.transform.position, Notebook_Icon.transform.position) < 0.001f)
        {
            Destroy(this.gameObject);
            finished = true;
        }
    }
}
