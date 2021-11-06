using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Rendering.PostProcessing;

//Created in 09/26/2019 by Zijie Zhang
//---<LOGS>---

//10/10/2019
//Created for skill icon click response
//01/16/2019
//This script is half finished and abandoned

//---</LOGS>---

//---<Bugs or Questions in Mind>---
//---</Bugs or Questions in Mind>---

public class skill_Icon : MonoBehaviour
{
    private event_Manager ui_Manager; //reference for ui manger script
    public Sprite transparent; //transparent 
    public Sprite original; //original

    public Color special_Color; //color
    private ColorGrading concentrate_Color;//color when clicked concentrate_skill
    private Color current_Color;//curent color
    public bool concentrated;//if the player is concentrated
    
    private void Start()
    {
        concentrated = false;

        ui_Manager = GameObject.Find("ui_Manager").GetComponent<event_Manager>() as event_Manager;
        ui_Manager.attach_And_Add_Event("analyst_Icon", analyst_Icon);
        ui_Manager.attach_And_Add_Event("concentrate_Icon", concentrate_Icon);
        ui_Manager.attach_And_Add_Event("notebook_Icon", notebook_Icon);//attach the function to the button

       // concentrate_Color = Camera.main.GetComponent<PostProcessVolume>().profile.GetSetting<ColorGrading>();

        
    }

    private void Update()
    {
        current_Color = concentrated ?special_Color :Color.white; //check current color
    }

    private void FixedUpdate()
    {
       // concentrate_Color.colorFilter.value = Color.Lerp(concentrate_Color.colorFilter.value, current_Color, .2f);
    }
    public void analyst_Icon(object o)
    {
        Debug.Log("click analyst icon"); //analyst icon function
    }

    public void concentrate_Icon(object o)
    {
        concentrated = true;
        Debug.Log("click concentrate icon");
        foreach (Transform children in this.transform)
        {
            children.GetComponent<Image>().sprite = original;
            children.GetComponent<Animator>().enabled = true;//make everything seenable if players are concentrating
        }
        StartCoroutine(concentrate_Time()); //make everything unseenabble when 
    }

    IEnumerator concentrate_Time()
    {
        yield return new WaitForSeconds(5);
        foreach (Transform children in this.transform)
        {
            children.GetComponent<Animator>().enabled = false;
            children.GetComponent<Image>().sprite = transparent;
            //make evrything unseenable when the concentrate time is over
        }
        concentrated = false;
        Debug.Log("finish transparent");

    }

    public void notebook_Icon(object o)
    {
        Debug.Log("click on notebook"); //function for notebook icon,empty right now
    }
}
