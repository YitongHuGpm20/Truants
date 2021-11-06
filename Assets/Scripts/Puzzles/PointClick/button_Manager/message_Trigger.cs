using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//Created in 10/02/2019 by Zijie Zhang
//---<LOGS>---

//10/02/2019
//Created for triggering diagolgue

//01/16/2019
//This script is in used along with the point and click puzzles

//---</LOGS>---

//---<Bugs or Questions in Mind>---
//---</Bugs or Questions in Mind>---
public class message_Trigger : MonoBehaviour
{
    public message test;

    public void trigger_Dialogue()
    {
        FindObjectOfType<message_Manager>().start_Message(test); //function for trigger next diaglogue
    }
}
