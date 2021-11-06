using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//Created in 02/05/2020 by Zijie Zhang

//---<Purpose>---
//Having it manage the websites
//---</Purpose>---
//---<LOGS>---

//02/05/2020
//Created basic features

//02/06/2020
//This script is abandoned
//---</LOGS>---

//---<Bugs or Questions in Mind>---
//---</Bugs or Questions in Mind>---

public class Website_Scriptable : MonoBehaviour
{
    [TextArea(4, 4)]
    public string title; //title of the website
    public string article_Content; //the text content
    public bool if_Finished; //if the website is finished clicking
    public bool if_Published; //if the website is published for access
    public GameObject website_ContentPrefab; //the content prefab for website

    private void Start()
    {
        if_Finished = false; 
        website_ContentPrefab = Resources.Load<GameObject>("test/" + title);
        
    }

}
