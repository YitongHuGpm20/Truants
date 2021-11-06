using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
//Created in 10/25/2019 by Zijie Zhang
//---<LOGS>---

//10/25/2019
//Created for IMMA scriptable data


//---</LOGS>---

//---<Bugs or Questions in Mind>---
//---</Bugs or Questions in Mind>---
[CreateAssetMenu(fileName = "IMMA_Data", menuName = "ScriptableObjects/IMMA_Scriptable", order = 1)]
public class scriptable_IMMA : ScriptableObject
{
    [Header ("content_Variables")]
    public string account_Name;
    public int like_Number;
    [TextArea(3,4)]
    public string post_Content;
    public Sprite picture_Content;

    //contents
}
