using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Created in 09/26/2019 by Zijie Zhang

//---<Purpose>---
//script for chatting prefab, which is message that each time players send
//---</Purpose>---
//---<LOGS>---

//10/01/2019
//Created basic functions

//01/16/2020
//Still in used in the script

//---</LOGS>---

//---<Bugs or Questions in Mind>---
//---</Bugs or Questions in Mind>---

public class Chat_Prefab : MonoBehaviour
{
    [System.Serializable]
    public class chat_Gameobject
    {
        public GameObject Profile_Picture; //profile pic 
        public GameObject Text_Bubble; //text bubble pos
        public GameObject Name; //name under the pic
        public GameObject Text_Content;//content of the message
    }

    public chat_Gameobject this_Chat_Info; 
    private void Awake()
    {
        this_Chat_Info = new chat_Gameobject();
        this_Chat_Info.Profile_Picture = this.transform.Find("Profile_Picture").gameObject;
        this_Chat_Info.Text_Bubble = this.transform.Find("Text_Bubble").gameObject;
        this_Chat_Info.Name = this.transform.Find("Name").gameObject;
        this_Chat_Info.Text_Content = this.transform.Find("Text_Content").gameObject;
        //setups


    }
}
