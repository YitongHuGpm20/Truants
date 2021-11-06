using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Created in 10/04/2019 by Zijie Zhang
//---<Purpose>---
//This script is to create manager for attaching and detaching events in the point and click puzzle
//---</Purpose>---

//---<LOGS>---

//10/04/2019
//set up button  and events call backs

//01/16/2019
//Might need to revise later for better usage.


//---</LOGS>---

//---<Bugs or Questions in Mind>---
//---</Bugs or Questions in Mind>---

public class event_Manager : MonoBehaviour
{
    public delegate void event_Handle(object param = null); //event handle delegate
    public Dictionary<string, List<event_Handle>> event_Dictionary; //one to multiple dictionary to store click callbacks
    private event_Manager this_EventManager; //this event manager
    public string[] messages; //list of messages

    private void Awake()
    {
        event_Dictionary = new Dictionary<string, List<event_Handle>>(); //set up new dictionary
        this_EventManager = this.GetComponent<event_Manager>() as event_Manager;
    }

    public void trigger_Event(string key)
    {
        if (event_Dictionary.ContainsKey(key))
        {
            foreach(event_Handle temp in event_Dictionary[key])
            {
                temp(key); //foreach key in dictionary, call all functions store in it
            }
        }
        else
        {
            //Debug.Log("this button has an empty callback"); //if empty
        }
    }

    public void attach_Event(string key, event_Handle input_Event)
    {
        if (event_Dictionary.ContainsKey(key)) {
            event_Dictionary[key].Add(input_Event); //atach new events according to the keywords

        }
    }

    public void attach_And_Add_Event(string key, event_Handle input_Event)
    {
        add_Event(key);
        attach_Event(key, input_Event); //attach and add new event
    }
    public void add_Event(string key)
    {
        event_Dictionary.Add(key, new List<event_Handle>()); //add new event
    }

    public void detach_Event(string key, event_Handle input_Event)
    {
        if (event_Dictionary.ContainsKey(key))
        {
            event_Dictionary[key].Remove(input_Event); //remove single events according the keys
        }

    }

    public void detach_Allevent(string key) //detach all avents based on the keys
    {
        if (event_Dictionary.ContainsKey(key)) 
        {
          
        }
    }

    public void destroy_Manager() //destroy this object function
    {
        Destroy(this.gameObject);
    }
}
