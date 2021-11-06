using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
//Created in 10/24/2019 by Zijie Zhang
//---<LOGS>---

//10/24/2019
//Created for IMMA trigger


//---</LOGS>---

//---<Bugs or Questions in Mind>---
//---</Bugs or Questions in Mind>---
public class scriptable_IMMA_Trigger : MonoBehaviour
{
    [Header("references")]
    public GameObject picture_Content_Obj;
    public GameObject like_Number_Obj;
    public GameObject[] account_Name_Obj;
    public GameObject post_Content_Obj; //reference to gameobjects

    [Header("scriptable_Data")]
    public scriptable_IMMA data; //scriptable object data


    private void Awake()
    {
        set_Content();
    }

    public void set_Content()
    {
        picture_Content_Obj.GetComponent<Image>().sprite = data.picture_Content;
        like_Number_Obj.GetComponent<Text>().text = data.like_Number.ToString("N0") + " likes";
        foreach (GameObject obj in account_Name_Obj)
            obj.GetComponent<Text>().text = data.account_Name;
        post_Content_Obj.GetComponent<Text>().text = data.post_Content;
        //set contents from the scriptavle datas
    }
}
