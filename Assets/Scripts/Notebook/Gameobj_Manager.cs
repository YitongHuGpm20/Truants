using System.Collections;
using System.Collections.Generic;
using UnityEngine;

///Created in 11/01/2019 by Zijie Zhang
//---<Purpose>---
//The purpose of this script is to allocate each gameobject in notebook for keywords
//---</Purpose>---

//---<LOGS>---

//11/05/2019
//Created for unallocated keywords callbacks



//---</LOGS>---

//---<Bugs or Questions in Mind>---
//the effiecieny of using game.find, change that later
//---</Bugs or Questions in Mind>---

public class Gameobj_Manager : MonoBehaviour
{
    public static GameObject Unallocated_KeywordsStorage;
    public static GameObject Notebook_Icon;
    public static GameObject Planner;
    public static GameObject GoodPoint;
    public static GameObject Canvas;
    public static GameObject LoginScreen;
    public static GameObject VisageHome;

    private void Awake()
    {
        Unallocated_KeywordsStorage = GameObject.Find("Keyword_Storage"); //gameobject for storing unallocated keywords
        Planner = GameObject.Find("task_List");
        Notebook_Icon = GameObject.Find("GoodpointShortcut");
        GoodPoint = GameObject.Find("GoodPointWindow");
        Canvas = GameObject.Find("Canvas");
        LoginScreen = GameObject.Find("LoginScreen");
        VisageHome = GameObject.Find("WindowArea/BrovoWindow/VisageWindow/VisageHome");
    }

    private void Update()
    {
    }
}
