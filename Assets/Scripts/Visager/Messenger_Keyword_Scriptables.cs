using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;
using UnityEditor;
//Created in 09/26/2019 by Zijie Zhang

//---<Purpose>---
//script for chatting prefab, which is message and chatting for messages
//---</Purpose>---
//---<LOGS>---

//10/01/2019
//Created basic functions

//01/16/2020
//Still in used in the script

//---</LOGS>---

//---<Bugs or Questions in Mind>---
//---</Bugs or Questions in Mind>---
[CreateAssetMenu(fileName = "New Keywords", menuName = "Messenger_Keyword")]
//[InitializeOnLoad]
public class Messenger_Keyword_Scriptables : ScriptableObject
{
    public string Keyword;
    public string current_Innertext;
    [TextArea(4,4)]
    public List<string> List_Of_Innertext;
    public Chat_Base Current_Chats;
    public List<Chat_Base> List_Of_Chats;

    private void Awake()
    {
    }
    public void Next_Innertext()
    {
        current_Innertext = List_Of_Innertext[List_Of_Innertext.IndexOf(current_Innertext)+1];
        Current_Chats = List_Of_Chats[List_Of_Chats.IndexOf(Current_Chats) + 1]; //next text
    }

    void OnEnable()
    {
        current_Innertext = List_Of_Innertext.First();
        Current_Chats = List_Of_Chats.First(); //make them equal the first .
    }
}
