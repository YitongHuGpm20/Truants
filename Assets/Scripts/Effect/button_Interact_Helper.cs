using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
//Created in 10/20/2019 by Zijie Zhang
//---<Purpose>---
//The purpose of this script is to create a fade in/out effect when the players hover on an object.
//---</Purpose>---

//---<LOGS>---
//10/20/2019
//Added functions

//01/09/2019
//This script is not in used
//---</LOGS>---

//---<Bugs or Questions in Mind>---
//---</Bugs or Questions in Mind>---


public class button_Interact_Helper:MonoBehaviour
{
    public void change_Color(GameObject target, Color destinate_Color, float time = 0f)
    {
        Color current_Color = target.GetComponent<Image>().color;
        Color.Lerp(current_Color, destinate_Color, time);
    }
}
