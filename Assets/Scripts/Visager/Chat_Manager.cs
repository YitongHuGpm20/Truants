using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;

//Created in 09/26/2019 by Zijie Zhang

//---<Purpose>---
//script for chatting manager, managing when to add, delete chatting 
//---</Purpose>---
//---<LOGS>---

//10/01/2019
//Created basic functions

//01/16/2020
//Still in used in the script

//---</LOGS>---

//---<Bugs or Questions in Mind>---
//---</Bugs or Questions in Mind>---

public class Chat_Manager : MonoBehaviour
{
    //public Text Chat_Name;
    //public Text Chat_Text;
    //public Sprite Characters_Potraits;
    private bool initialized = true;
    public Chat_Base test;
    public Queue<Chat_Base.Chat_Info> Chat_Info_Queue = new Queue<Chat_Base.Chat_Info>();

    public void Enqueue_Newchat(Chat_Base temp)
    {
        Chat_Info_Queue.Clear();
        foreach(Chat_Base.Chat_Info info in temp.Chat_Queue)
        {
            Chat_Info_Queue.Enqueue(info);
        }
        //Dequeue_Newchat();
    }

    public void Dequeue_Newchat()
    {
        
        if(Chat_Info_Queue.Count == 0)
        {
            Messenger_Manager.Dropzone.GetComponent<Messenger_Dropzone_Manager>().Hard_CodedConditions(Messenger_Dropzone_Manager.Saved_Keyword);
            Messenger_Manager.Reply_Button.GetComponent<Button>().interactable = true;
            CancelInvoke();
            return;
        }
        SettingsManager.instance.playSFXByID(8);
        GameObject new_Chat_Content = Instantiate(Messenger_Manager.Content_Prefab,Messenger_Manager.Chat_Content.transform.Find("Scroll_Rect").Find("Actual_Chat_Content"));
        GameObject Save_obj = Messenger_Manager.Avaliable_Chats.Keys.FirstOrDefault(temp=>temp.name == Messenger_Manager.Current_Active);
        //foreach (GameObject obj in Messenger_Manager.Avaliable_Chats.Keys)
        //    Debug.Log(obj.name);

        List<GameObject> Save_List = Messenger_Manager.Avaliable_Chats[Save_obj];
        Save_List.Add(new_Chat_Content);

        Chat_Base.Chat_Info Info = Chat_Info_Queue.Dequeue();
        //Debug.Log(new_Chat_Content.GetComponent<Chat_Prefab>());
        //Chat_Name.text = Info.Speaker_Name;
        //Chat_Text.text = Info.Sentences;
        //Characters_Potraits = Info.Characters_Potraits;
        new_Chat_Content.GetComponent<Chat_Prefab>().this_Chat_Info.Name.GetComponent<Text>().text = Info.Speaker_Name;
        new_Chat_Content.GetComponent<Chat_Prefab>().this_Chat_Info.Profile_Picture.GetComponent<Image>().sprite = Info.Characters_Potraits;
        new_Chat_Content.GetComponent<Chat_Prefab>().this_Chat_Info.Text_Content.GetComponent<Text>().text = Info.Sentences;
        Profile_Pic_Pos(new_Chat_Content, Info.Speaker_Name);
        initialized = false;
        Messenger_Manager.Chat_Content.transform.Find("Scroll_Rect").gameObject.GetComponent<ScrollRect>().verticalNormalizedPosition = 0;
        Canvas.ForceUpdateCanvases();
    }

    private void Profile_Pic_Pos(GameObject Input, string name)
    {
        if(name == "Handsome Prince")
        {
            Input.GetComponent<Chat_Prefab>().this_Chat_Info.Profile_Picture.transform.localPosition = new Vector3(Input.GetComponent<Chat_Prefab>().this_Chat_Info.Profile_Picture.transform.localPosition.x + 800, Input.GetComponent<Chat_Prefab>().this_Chat_Info.Profile_Picture.transform.localPosition.y, Input.GetComponent<Chat_Prefab>().this_Chat_Info.Profile_Picture.transform.localPosition.z);
            Input.GetComponent<Chat_Prefab>().this_Chat_Info.Name.transform.localPosition = new Vector3(Input.GetComponent<Chat_Prefab>().this_Chat_Info.Name.transform.localPosition.x + 800, Input.GetComponent<Chat_Prefab>().this_Chat_Info.Name.transform.localPosition.y, Input.GetComponent<Chat_Prefab>().this_Chat_Info.Name.transform.localPosition.z);
            Input.GetComponent<Chat_Prefab>().this_Chat_Info.Text_Bubble.transform.localRotation = Quaternion.Euler(0, 180, 0);
        }//change the messeage pos if the name is main character
    }

    private void Update()
    {
        //if (Input.GetMouseButtonDown(0))
        //{
        //    if(initialized)
        //        //Dequeue_Newchat();
        //    initialized = true;
        //} //for testing
    }

    public void Initialized_Chatting(Chat_Base Input)
    {
        Enqueue_Newchat(Input);
        InvokeRepeating("Dequeue_Newchat", 0.0f, 2f); //give it some time before sending next message
    }


}
