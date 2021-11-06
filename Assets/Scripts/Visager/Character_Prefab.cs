using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
//Created in 09/26/2019 by Zijie Zhang

//---<Purpose>---
//showing the person's chatting log
//---</Purpose>---
//---<LOGS>---

//10/01/2019
//Created basic functions

//01/16/2020
//need to change this later, it is so bad

//---</LOGS>---

//---<Bugs or Questions in Mind>---
//---</Bugs or Questions in Mind>---

public class Character_Prefab : MonoBehaviour
{
    public void Show_Chat()
    {
        Messenger_Manager.Dropzone.GetComponent<InputField>().text = "";
        Messenger_Manager.Current_Active = this.gameObject.name;
        //Messenger_Manager.Live_Dot.transform.position = this.gameObject.transform.position;
        //Messenger_Manager.Live_Dot.transform.localPosition = new Vector3(Messenger_Manager.Live_Dot.transform.localPosition.x - 150, Messenger_Manager.Live_Dot.transform.localPosition.y + 60, Messenger_Manager.Live_Dot.transform.localPosition.z);

        foreach (Transform temp in this.transform.parent)
        {
            temp.GetComponent<Text>().color = Color.white;
            Debug.Log(temp.name);
        }
        this.GetComponent<Text>().color = Color.green;

        foreach (Transform temp in Messenger_Manager.Actual_Chatting.transform)
        {
            Vector3 scale = temp.transform.localScale;
            scale.Set(0,0,0);
            temp.transform.localScale = scale;
        }
        if (Messenger_Manager.Avaliable_Chats.ContainsKey(this.gameObject))
        {
            foreach (GameObject temp_Add in Messenger_Manager.Avaliable_Chats[this.gameObject])
            {
                temp_Add.transform.localScale = new Vector3(1, 1, 1);
            }

        }
        
    }
}
