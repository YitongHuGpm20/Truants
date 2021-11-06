using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

//Created in 09/26/2019 by Zijie Zhang

//---<Purpose>---
//script for chatting prefab, which is message that each time players send
//---</Purpose>---
//---<LOGS>---

//10/01/2019
//Created basic functions

//01/16/2020
//This is so bad, need to change definitly

//---</LOGS>---

//---<Bugs or Questions in Mind>---
//---</Bugs or Questions in Mind>---
public class Messenger_Dropzone_Manager : MonoBehaviour, IDropHandler
{
    //private bool Joy_Purse = false;
    //public bool DrKwan = false;
    //public bool Dm_Button = false;
    //private bool tempa = false;
    //private bool tempb = false;
    //private bool tempc = false;
    //private bool tempd = false;
    //private bool renawoopwoop = false;
    //private bool clicked = false; //change this
    private bool chatting = false;
    public static bool alex_Active = false;
    /*chatboolean hardcoded*/
    private bool joy_Asked = false;
    private bool tina_Asked = false;
    private bool rena_Asked = false;
    private bool theKwan_Asked = false;
    private bool baiNing_Asked = false;
    private bool loop_Advanced = false;

    private bool Alex_asked = false;
    public static GameObject messenger_dropzoneobj;

    private int asked_Counter = 0;
    int voCount1 = 0;
    int voCount2 = 0;
    private bool one_Time = false;

    public bool dm_Opended = false;

    public void opened()
    {
        dm_Opended = true;
        Chat_Next(new string[2] { "Bai Ning", "the.kwan.and.only"});
    }


    public List<Messenger_Keyword_Scriptables> List_Keywords;
    public static string Saved_Keyword;
    private void Awake()
    {
        this.GetComponent<InputField>().readOnly = true;
        messenger_dropzoneobj = this.gameObject;
        
    }
    public string Dropzone_Character;
    public void OnDrop(PointerEventData eventData)
    {
        if (Messenger_Manager.Current_Active == "Alex Perry")
            if (!Messenger_Dropzone_Manager.alex_Active)
                return;
            
        if (!chatting)
        {

            Saved_Keyword = eventData.pointerDrag.GetComponent<Allocated_Property>().Keyword;
            if (Messenger_Manager.Current_Active == "James Kwan")
                this.GetComponent<InputField>().text = List_Keywords.Find(x => x.Keyword == Saved_Keyword).current_Innertext;
            else if (Saved_Keyword == "LTBMC" && Messenger_Manager.Current_Active == "Alex Perry" && Alex_asked)
            {
                int index = List_Keywords.Find(x => x.Keyword == Saved_Keyword).List_Of_Chats.Count;
                Chat_Base temp = List_Keywords.Find(x => x.Keyword == Saved_Keyword).List_Of_Chats[index - 1];
                this.GetComponent<InputField>().text = temp.Chat_Queue[0].Sentences;
            }
            else
            {
                Chat_Base temp = List_Keywords.Find(x => x.Keyword == Saved_Keyword).List_Of_Chats.Find(x => x.Belonging_Chat == Messenger_Manager.Current_Active);
                this.GetComponent<InputField>().text = temp.Chat_Queue[0].Sentences;
            }
        }

    } //if something drop on the zone

    public void On_ClickReply()
    {
        if (this.GetComponent<InputField>().text == "")
        {
            return;
        }
        foreach (KeyValuePair< GameObject, List < GameObject >> temp in Messenger_Manager.Avaliable_Chats)
        {
            temp.Key.GetComponent<Button>().interactable = false;
        }


        this.GetComponent<InputField>().interactable = false;
        chatting = true;
        //List_Keywords.Find(x => x.Keyword == Saved_Keyword).List_Of_Chats.Find(x => x.Belonging_Chat == Messenger_Manager.Current_Active);
        //Messenger_Manager.Chat_Manager.GetComponent<Chat_Manager>().Initialized_Chatting(List_Keywords.Find(x => x.Keyword == Saved_Keyword).Current_Chats);
        if (Alex_asked && Saved_Keyword == "LTBMC" && Messenger_Manager.Current_Active == "Alex Perry")
        {
            int index = List_Keywords.Find(x => x.Keyword == Saved_Keyword).List_Of_Chats.Count;

            Messenger_Manager.Chat_Manager.GetComponent<Chat_Manager>().Initialized_Chatting(List_Keywords.Find(x => x.Keyword == Saved_Keyword).List_Of_Chats[index-1]);
        }
        else if (Messenger_Manager.Current_Active == "Alex Perry")
        {
            Messenger_Manager.Chat_Manager.GetComponent<Chat_Manager>().Initialized_Chatting(List_Keywords.Find(x => x.Keyword == Saved_Keyword).List_Of_Chats.Find(x => x.Belonging_Chat == Messenger_Manager.Current_Active));
        }
        else
            //Messenger_Manager.Chat_Manager.GetComponent<Chat_Manager>().Initialized_Chatting(List_Keywords.Find(x => x.Keyword == Saved_Keyword).List_Of_Chats.Find(x => x.Belonging_Chat == Messenger_Manager.Current_Active));
            Messenger_Manager.Chat_Manager.GetComponent<Chat_Manager>().Initialized_Chatting(List_Keywords.Find(x => x.Keyword == Saved_Keyword).Current_Chats);
        Messenger_Manager.Reply_Button.GetComponent<Button>().interactable = false; //once it click reply
    }

    public void Chat_Next(string[] Name)
    {
        for (int i = 0; i < Name.Length; i++)
        {
            Debug.Log(Name[i]);
            int Current_Index = this.List_Keywords.FindIndex(X => X.Keyword == Name[i]);
            int Current_ChatIndex = List_Keywords[Current_Index].List_Of_Chats.FindIndex(x => x == List_Keywords[Current_Index].Current_Chats);
            if (Current_ChatIndex == List_Keywords[Current_Index].List_Of_Chats.Count + 1)
                return;
            List_Keywords[Current_Index].Current_Chats = List_Keywords[Current_Index].List_Of_Chats[Current_ChatIndex + 1];



            List_Keywords[Current_Index].current_Innertext = List_Keywords[Current_Index].List_Of_Innertext[Current_ChatIndex + 1];
        } //start getting the text


    }

    ////hard coded section, why exists///
    public void Hard_CodedConditions(string words)
    {
        this.GetComponent<InputField>().interactable = true;
        if (words == "Joy Aun" || words == "Tina Knigh" || words == "Rena Woo")
        {
            Debug.Log("hi");
            int Current_Index = this.List_Keywords.FindIndex(X => X.Keyword == words);
            int Current_ChatIndex = List_Keywords[Current_Index].List_Of_Chats.FindIndex(x => x == List_Keywords[Current_Index].Current_Chats);
            if (Current_ChatIndex == 1 && asked_Counter == -1)
            {
                Chat_Next(new string[9] { "Bai Ning", "James Kwan", "LTBMC", "Joy Aun", "Tina Knigh", "Rena Woo", "Miong", "the.kwan.and.only", "Langxian City" });
                task_Manager.task_obj.GetComponent<task_Manager>().try_FinishTask(6);
                this.GetComponent<task_Property>().add_Task();
                voCount1++;
                if (voCount1 == 1)
                {
                    SettingsManager.instance.PlaySFX2D(SettingsManager.instance.sfxClips[17]);
                }
            }
        }

        if (words == "Joy Aun" && !joy_Asked)
        {
            joy_Asked = true;
            asked_Counter++;
        }
        else if (words == "Tina Knigh" && !tina_Asked)
        {
            tina_Asked = true;
            asked_Counter++;
        }
        else if (words == "Rena Woo" && !rena_Asked) {
            rena_Asked = true;
            asked_Counter++;
        }

        if (asked_Counter == 2)
        {
            Chat_Next(new string[3] { "Joy Aun", "Tina Knigh", "Rena Woo" });
            asked_Counter = -1;
        }

        if (words == "the.kwan.and.only" )
        {
            int Current_Index = this.List_Keywords.FindIndex(X => X.Keyword == words);
            int Current_ChatIndex = List_Keywords[Current_Index].List_Of_Chats.FindIndex(x => x == List_Keywords[Current_Index].Current_Chats);
            if (Current_ChatIndex == 2 && !loop_Advanced)
            {
                Chat_Next(new string[1] { "Bai Ning" });
                loop_Advanced = true;
            }
            else if (Current_ChatIndex == 3)
            {
                Chat_Next(new string[9] { "Bai Ning", "James Kwan", "LTBMC", "Joy Aun", "Tina Knigh", "Rena Woo", "Miong", "the.kwan.and.only", "Langxian City" });
                Chat_Next(new string[1] { "Bai Ning" });
            }
        }

        if (words == "Bai Ning" )
        {
            int Current_Index = this.List_Keywords.FindIndex(X => X.Keyword == words);
            int Current_ChatIndex = List_Keywords[Current_Index].List_Of_Chats.FindIndex(x => x == List_Keywords[Current_Index].Current_Chats);

            if (Current_ChatIndex == 2 && !loop_Advanced)
            {
                Chat_Next(new string[1] { "the.kwan.and.only" });
                loop_Advanced = true;
            }

            else if (Current_ChatIndex == 3) {
                Chat_Next(new string[9] { "Bai Ning", "James Kwan", "LTBMC", "Joy Aun", "Tina Knigh", "Rena Woo", "Miong", "the.kwan.and.only", "Langxian City" });
                Chat_Next(new string[1] { "the.kwan.and.only" });
            }
        }

        if (words == "LTBMC" & Alex_asked == true && Messenger_Manager.Current_Active == "Alex Perry")
        {
            Instantiate(Resources.Load("Prefabs/Visager/Download_XploitPanel"), Messenger_Manager.Chat_Content.transform.Find("Scroll_Rect").Find("Actual_Chat_Content"));
        }

        if (words == "Tina Knigh" && Messenger_Manager.Current_Active == "Alex Perry")
        {
            Alex_asked = true;
        }

        if (words == "LTBMC" && Messenger_Manager.Current_Active == "James Kwan" && !one_Time)
        {
            int Current_Index = this.List_Keywords.FindIndex(X => X.Keyword == words);
            int Current_ChatIndex = List_Keywords[Current_Index].List_Of_Chats.FindIndex(x => x == List_Keywords[Current_Index].Current_Chats);
            if (Current_ChatIndex == 2)
            {
                GameManager.sd3 = true;
                one_Time = true;
                task_Manager.task_obj.GetComponent<task_Manager>().try_FinishTask(7);
                this.GetComponent<task_Property>().add_Task();
                voCount2++;
                if (voCount2 == 1)
                {
                    SettingsManager.instance.PlaySFX2D(SettingsManager.instance.sfxClips[19]);
                }
            }
        }

        foreach (KeyValuePair<GameObject, List<GameObject>> temp in Messenger_Manager.Avaliable_Chats)
        {
            temp.Key.GetComponent<Button>().interactable = true;
        }

        if (words == "xPloit")
        {
            this.GetComponent<task_Property>().add_Task();
            task_Manager.task_obj.GetComponent<task_Manager>().try_FinishTask(11);
        }

        //if (words == "Joy's Purse" && !Joy_Purse)
        //{
        //    Chat_Next(new string[3] { "Rena Woo", "renawoopwoop", "Joy Aun", });
        //    Joy_Purse = true;
        //}
        //if (words == "Joy Aun"||words == "Joy's Purse")
        //{

        //    int Current_Index = this.List_Keywords.FindIndex(X => X.Keyword == "Joy Aun");
        //    int Current_ChatIndex = List_Keywords[Current_Index].List_Of_Chats.FindIndex(x => x == List_Keywords[Current_Index].Current_Chats);
        //    Debug.Log(Current_ChatIndex + " " + List_Keywords[Current_Index].List_Of_Chats.Count);
        //    if (Current_ChatIndex+1 == List_Keywords[Current_Index].List_Of_Chats.Count)
        //    {
        //        Instantiate(Resources.Load("Prefabs/Messenger/Endchat_Button"), Messenger_Manager.Chat_Content.transform.Find("Scroll_Rect").Find("Actual_Chat_Content"));
        //    }
        //}
        //if(words == "renawoopwoop"&&Joy_Purse == true &&!tempa)
        //{
        //    Chat_Next(new string[1] { "Dr.Kwan" });

        //    tempa = true;
        //}

        //if (words == "renawoopwoop" && Joy_Purse == true && !tempb)
        //{

        //    if (Dm_Button)
        //    {
        //        tempb = true;
        //        DrKwan = true;
        //        Chat_Next(new string[1] { "Dr.Kwan" });
        //    }
        //    if (!renawoopwoop)
        //        renawoopwoop = true;
        //}

        //if(words == "Dr.Kwan" && DrKwan &&!tempc &&Dm_Button)
        //{
        //    Chat_Next(new string[6] { "Rena Woo", "renawoopwoop", "Joy Aun", "Megat", "Joy's Purse","Dr.Kwan" });
        //    tempc = true;
        //}

        //else if (words == "Dr.Kwan" && renawoopwoop && !tempd && Dm_Button)
        //{
        //    Chat_Next(new string[6] { "Rena Woo", "renawoopwoop", "Joy Aun", "Megat", "Joy's Purse", "Dr.Kwan" });
        //    tempd = true;
        //}
        ////if(words == "Dr.Kwan" && DrKwan && !tempd && !Dm_Button)
        ////{
        ////    Chat_Next(new string[1] { "Dr.Kwan" });
        ////    tempd = true;
        ////}
        chatting = false;
    }

    //public void Set_Dm()
    //{
    //    if (clicked)
    //        return;
    //    clicked = true;
    //    Dm_Button = true;
    //    if(renawoopwoop)
    //        Chat_Next(new string[1] { "Dr.Kwan" });

    //}
}
