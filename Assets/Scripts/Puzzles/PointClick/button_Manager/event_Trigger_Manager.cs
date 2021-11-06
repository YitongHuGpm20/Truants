using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Created in 10/02/2019 by Zijie Zhang
//---<Purpose>---
//This script is to create manager for messege in point and click puzzles
//---</Purpose>---
//---<LOGS>---

//10/02/2019
//Created for diaglogue trigger


//---</LOGS>---

//---<Bugs or Questions in Mind>---
//---</Bugs or Questions in Mind>---
public class event_Trigger_Manager : MonoBehaviour
{
    private event_Manager _event_Manager;
    private void Awake()
    {
        _event_Manager = this.GetComponent<event_Manager>() as event_Manager; //get this component

    }
    public void trigger_Event(string key)
    {
        //Debug.Log("Triggering");
        _event_Manager.trigger_Event(key); //trigger event
    }
}
