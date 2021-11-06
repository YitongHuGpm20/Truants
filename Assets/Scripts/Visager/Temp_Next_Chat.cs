using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Created in 09/26/2019 by Zijie Zhang

//---<Purpose>---
//To change the dropzone's text when words are dropped
//---</Purpose>---
//---<LOGS>---

//10/01/2019
//Created basic functions

//01/16/2020
//Still in used in the script, but might delete later, kind of suck

//---</LOGS>---

//---<Bugs or Questions in Mind>---
//---</Bugs or Questions in Mind>---

public class Temp_Next_Chat : MonoBehaviour
{
    public string[] Input; //words that move to next innertext

    public void On_Click_Next()
    {
        Messenger_Manager.Dropzone.GetComponent<Messenger_Dropzone_Manager>().Chat_Next(Input);
    }//on click function
}
