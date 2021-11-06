using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//Created in 12/05/2019 by Zijie Zhang
//---<Purpose>---
//The purpose of this script is to fit the conditons for messenger
//---</Purpose>---

//---<LOGS>---
//12/05/2019
//Added basic function

//01/09/2019
//This script should be deleted later for better messenger stuffs.
//---</LOGS>---

//---<Bugs or Questions in Mind>---
//---</Bugs or Questions in Mind>---
public class Conditions_Helpers : MonoBehaviour
{
    public bool Clue = false;
    public bool Username = false;

    public void DM_Comfromt()
    {
        planner_Manager.Destory_TaskByContent("Find a way to access Rena's Bouquet account");
    }

    public void set_Clue()
    {
        Clue = true;
        Call_task();
    }

    public void set_Username()
    {
        Username = true;
        Call_task();
    }

    public void Call_task()
    {
        if (Clue && Username)
        {
            planner_Manager.Destory_TaskByContent("Find out more about Rena Woo and her involvement with Joy");
            Gameobj_Manager.Planner.GetComponent<planner_Manager>().initialize_Newtask("Find a way to access Rena's Bouquet account");
        }
    }
}
