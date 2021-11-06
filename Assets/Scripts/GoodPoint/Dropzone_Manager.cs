using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

//Created in 09/26/2019 by Zijie Zhang

//---<Purpose>---
//To change the dropzone's text when words are dropped
//---</Purpose>---
//---<LOGS>---

//10/01/2019
//Created basic functions

//01/16/2020
//Still in used in the script

//---</LOGS>---

//---<Bugs or Questions in Mind>---
//---</Bugs or Questions in Mind>---
public class Dropzone_Manager : MonoBehaviour, IDropHandler
{
    public string Dropzone_Character; //if this match with the keyword's belonging character
    public void OnDrop(PointerEventData eventData)
    {
        if(this.Dropzone_Character == "All") this.GetComponent<InputField>().text = eventData.pointerDrag.GetComponent<Allocated_Property>().Keyword; //change the dropzone to inner text
        if (eventData.pointerDrag.GetComponent<Allocated_Property>()&& string.Compare(eventData.pointerDrag.GetComponent<Allocated_Property>().Belonging_Character, this.Dropzone_Character) == 0)
        {
            this.GetComponent<InputField>().text = eventData.pointerDrag.GetComponent<Allocated_Property>().Keyword;
        }//I forgot what it does???
    }

}
