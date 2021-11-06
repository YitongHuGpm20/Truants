using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
///Created in 11/05/2019 by Zijie Zhang
///

//---<Purpose>---
//The purpose of this script is to create basic for unallocated keywords
//---</Purpose>---

//---<LOGS>---

//11/05/2019
//Created for unallocated keywords storage

//01/10/2019
//This script is not in used.


//---</LOGS>---

//---<Bugs or Questions in Mind>---
//---</Bugs or Questions in Mind>---
public class Unallocate_Keywords : MonoBehaviour
{
    private GameObject Keywords_Area; //reference to the keywords area
    private List<Unallocated_Keywords> Unallocated_List; //list to store unallocated keywords
    public GameObject Keyword_Prefab; //prefab for initialize unakkicated keywords prefab
    private void Awake()
    {
        Keywords_Area = this.gameObject;
        Unallocated_List = new List<Unallocated_Keywords>();
    }
    public class Unallocated_Keywords
    {
        string Character_Name;
        string Keyword;
        GameObject Reference_Gameobjects; //reference to gameobjects for deletion

        public Unallocated_Keywords(string name, string word, GameObject gameobject)
        {
            Character_Name = name;
            Keyword = word;
            Reference_Gameobjects = gameobject;
            Reference_Gameobjects.GetComponent<Text>().text = Keyword; //constructor
        }
    }

    public void Add_UnallocatedKeywords(string[] Contents)
    {
        GameObject new_KeywordObject = Instantiate(Keyword_Prefab, this.gameObject.transform);
        Debug.Log(new_KeywordObject.transform.localScale);
        new_KeywordObject.GetComponent<unallocated_Property>().Character_Name = Contents[0];
        new_KeywordObject.GetComponent<unallocated_Property>().Keyword = Contents[1];
        new_KeywordObject.GetComponent<unallocated_Property>().inner_Text = Contents[2];
        //new_KeywordObject.transform.SetParent(this.gameObject.transform);
        Unallocated_Keywords temp = new Unallocated_Keywords(Contents[0], Contents[1], new_KeywordObject); //add new unallocated keywords
    }

    
         
}
