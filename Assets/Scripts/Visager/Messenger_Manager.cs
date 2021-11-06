using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;

//Created in 12/07/2019 by Zijie Zhang
//---<Purpose>---
//The purpose of this script is to allocate gameobject components for messenger
//---</Purpose>---

//---<LOGS>---
//12/07/2019
//Added basic function

//---</LOGS>---

//---<Bugs or Questions in Mind>---
//---</Bugs or Questions in Mind>---
public class Messenger_Manager : MonoBehaviour
{
    private static GameObject Messenger_Panel; //messenger panel transform
    public static Dictionary<GameObject, List<GameObject>> Avaliable_Chats; //all avaliable people to chat
    private static GameObject List_Chat; //list of chat
    public static GameObject Chat_Content; //content of chating
    public static GameObject Actual_Chatting; //actual content of chatting
    public static string Current_Active;//who is currently active person to chat

    public static GameObject Live_Dot; //the dot symbolize who are you chatting currently

    public static GameObject Send_Position; //position to for sending message
    public static GameObject Reply_Position; //position for replying message

    public static GameObject Content_Prefab; //prefab of chatting content
    private GameObject Character_Prefab; //character pos
    public static GameObject Chat_Manager; //chatting manager
    public static GameObject Reply_Button; //button for replying message
    private static bool Opened = false; //if the panel is opened
    public static GameObject Dropzone; //area for dropping keyword to reply
    public static GameObject messenger_Obj;
    public GameObject slider;
    public GameObject underline;
    bool isWindowOn;

    private void Awake()
    {
        Messenger_Panel = this.gameObject.transform.parent.gameObject;
        Live_Dot = Messenger_Panel.transform.Find("Live_Dot").gameObject;
        List_Chat = Messenger_Panel.transform.Find("List_Content").gameObject;
        Chat_Content = Messenger_Panel.transform.Find("Chat_Content").gameObject;
        Actual_Chatting = Chat_Content.transform.Find("Scroll_Rect").Find("Actual_Chat_Content").gameObject;

        Send_Position = Chat_Content.transform.Find("Initial_Point_Send").gameObject;
        Reply_Position = Chat_Content.transform.Find("Initial_Point_Reply").gameObject;

        Character_Prefab = Resources.Load("Prefabs/VerticalSlice/Messenger/Character_Prefab") as GameObject;
        Content_Prefab = Resources.Load("Prefabs/VerticalSlice/Messenger/Content_Prefab") as GameObject;

       Avaliable_Chats = new Dictionary<GameObject, List<GameObject>>();
        Chat_Manager = Messenger_Panel.transform.Find("Chat_Manager").gameObject;
        Reply_Button = Messenger_Panel.transform.Find("Input_Reply").Find("Reply_Button").gameObject;
        Dropzone = Messenger_Panel.transform.Find("Input_Reply").Find("InputField").gameObject; //setups
        //slider = GameObject.FindGameObjectWithTag("slidermessenger");
        messenger_Obj = this.gameObject;

        isWindowOn = false;
    }

    private void Start()
    {
       // Initialize_NewCharacter("James Kwan"); //initialize rena woo to talk to

        //Initialize_NewCharacter("Alex Perry");
    }

    public void Initialize_NewCharacter(string Name)
    {
        if (!Avaliable_Chats.Keys.Any(key => key.name == Name))
        {
            GameObject New_Character = Instantiate(Character_Prefab, List_Chat.transform);
            New_Character.name = Name;
            New_Character.GetComponentInChildren<Text>().text = Name;
            List<GameObject> Chat_Content = new List<GameObject>();
            Avaliable_Chats.Add(New_Character, Chat_Content);
        }
    } //add new characters for chatting

    private void Initialize_NewSentence()
    {

    }
    public void On_Click_Icon()
    {
        if (!isWindowOn)
        {
            
            //Messenger_Panel.transform.localScale = new Vector3(1, 1, 1); // scale needs to be changed later
            slider.SetActive(true);
            slider.GetComponent<Slider>().value = 1;
            underline.SetActive(true);
            Messenger_Panel.transform.SetAsLastSibling();
            isWindowOn = true;
            if(Avaliable_Chats.Count >0)
                Avaliable_Chats.First().Key.GetComponent<Button>().onClick.Invoke();
        }
        else
        {
            //Messenger_Panel.transform.localScale = new Vector3(0, 0, 0);
            slider.GetComponent<Slider>().value = 0;
            slider.SetActive(false);
            underline.SetActive(false);
            isWindowOn = false;
        }
    }
}
