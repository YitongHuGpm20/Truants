using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
//Created in 09/26/2019 by Zijie Zhang

//---<Purpose>---
//script for chatting scriptables
//---</Purpose>---
//---<LOGS>---

//10/01/2019
//Created basic functions

//01/16/2020
//Still in used in the script

//---</LOGS>---

//---<Bugs or Questions in Mind>---
//---</Bugs or Questions in Mind>---
[CreateAssetMenu(fileName = "New Chat", menuName = "Chat")]
public class Chat_Base : ScriptableObject
{
    public string Belonging_Chat; //what does this belong to
    [System.Serializable]
    public class Chat_Info
    {
        public Sprite Characters_Potraits; //character portraits
        [TextArea(4,8)]
        public string Sentences; //sentences that they are speaking
        public string Speaker_Name; //who's speaking
    }
    public Chat_Info[] Chat_Queue; //queue of chating
}
