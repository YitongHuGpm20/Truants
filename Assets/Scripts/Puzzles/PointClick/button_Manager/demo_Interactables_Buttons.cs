using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//Created in 10/06/2019 by Zijie Zhang
//---<Purpose>---
//The purpose of this script is to attach clicking evetns in the puzzle
//---<LOGS>---

//10/06/2019
//Created for interactable call backs


//---</LOGS>---

//---<Bugs or Questions in Mind>---
//---</Bugs or Questions in Mind>---
public class demo_Interactables_Buttons : MonoBehaviour
{
    private event_Manager ui_Manager;

    private void Start()
    {
        ui_Manager = GameObject.Find("ui_Manager").GetComponent<event_Manager>() as event_Manager;
        ui_Manager.attach_And_Add_Event("1_RightWalls", interact_RightWalls);
        ui_Manager.attach_And_Add_Event("1_LeftWalls", interact_LeftWalls);
        ui_Manager.attach_And_Add_Event("1_Ceiling", interact_Ceiling);
        ui_Manager.attach_And_Add_Event("1_Floor", interact_Floor);//attach gameobjects to the functions

    }

    public delegate void test();
    //function for interacting points
    public void interact_RightWalls(object o)
    {
       // Debug.Log("interact right wall"); 
    }

    public void interact_LeftWalls(object o)
    {
       // Debug.Log("interact left wall");
    }

    public void interact_Ceiling(object o)
    {
       // Debug.Log("interact ceiling");
    }

    public void interact_Floor(object o)
    {
       // Debug.Log("interact Floor");
    }
}
