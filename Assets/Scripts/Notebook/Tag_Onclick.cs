using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

///Created in 11/01/2019 by Zijie Zhang
/////---<Purpose>---
//The purpose of this script is to click each category(people's name), it shows the create keywords group for people
//---</Purpose>---

//---<LOGS>---

//11/21/2019
//Created basic functions


//---</LOGS>---

//---<Bugs or Questions in Mind>---
//---</Bugs or Questions in Mind>---

public class Tag_Onclick : MonoBehaviour
{
    public void onClick_Tag() //if lick
    {
        string Name_Text = transform.Find("Name").gameObject.GetComponent<Text>().text; 
        foreach (Transform temp in GoodPoint_Manager.Keyword_Area.transform )
        {
            Destroy(temp.gameObject); //destry the keywords
        }


        GoodPoint_Manager.Character Selected_Character = GoodPoint_Manager.Characters_List.Find(n => n.name == Name_Text);
        foreach (GoodPoint_Manager.Allocated_Keywords temp in Selected_Character.Keywords_List)
        {
            GameObject new_Keyword = Instantiate(Gameobj_Manager.GoodPoint.GetComponent<GoodPoint_Manager>().Keyword_Prefab, GoodPoint_Manager.Keyword_Area.transform);
            new_Keyword.GetComponentInChildren<Allocated_Property>().Keyword = temp.Keyword;
            new_Keyword.GetComponentInChildren<Allocated_Property>().inner_Text = temp.inner_Text;
            new_Keyword.GetComponentInChildren<Allocated_Property>().description = temp.description;
            new_Keyword.GetComponentInChildren<Allocated_Property>().Belonging_Character = Name_Text;
            new_Keyword.GetComponentInChildren<Allocated_Property>().priority = temp.priority;
            //new_Keyword.transform.SetParent(GoodPoint_Manager.Keyword_Area.transform);
            new_Keyword.GetComponentInChildren<Text>().text = temp.Keyword; //instatiate the keywords
        }


    }
}
