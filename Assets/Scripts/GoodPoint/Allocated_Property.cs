using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//Created in 09/26/2019 by Zijie Zhang

//---<Purpose>---
//The property of already allocated words in goodpoint
//---</Purpose>---
//---<LOGS>---

//10/01/2019
//Created basic function

//01/16/2020
//Currently in used in Goodpoint

//---</LOGS>---

//---<Bugs or Questions in Mind>---
//---</Bugs or Questions in Mind>---


public class Allocated_Property : MonoBehaviour
{
    public string Keyword; //the hidden keyword behind it
    public string inner_Text; //hidden text
    public string description;//description
    public string Belonging_Character;// what does this belong to
    //private bool is_New;
    //[SerializeField]
    public int priority;
    private GameObject new_Indicator;

    private void Awake()
    {
        //is_New = true;
        new_Indicator = this.transform.parent.Find("new_Indicator").gameObject;
    }


    private void Start()
    {
        if(GoodPoint_Manager.Characters_List.Find(n => n.name == Belonging_Character).Keywords_List.Find(q => q.Keyword == Keyword).is_New == true)
            new_Indicator.transform.localScale = new Vector3(0, 0, 0);
        else
            new_Indicator.transform.localScale = new Vector3(1, 1, 1);
    }
    public void On_Click()
    {
       
        GoodPoint_Manager.Description_Text.transform.Find("Description_Text_Area").GetComponent<Text>().text = this.description; //if click on it, change the good point description
        GoodPoint_Manager.Characters_List.Find(n => n.name == Belonging_Character).Keywords_List.Find(q => q.Keyword == Keyword).is_New = true ;
        new_Indicator.transform.localScale = new Vector3(0, 0, 0);
    }
}
