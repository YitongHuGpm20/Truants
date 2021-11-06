using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

//Created in 10/01/2019 by Zijie Zhang

//---<Purpose>---
//The purpose of this script is to dropzone accept the drag and drop vocabs
//---<LOGS>---

//10/01/2019
//created basic function

//01/16/2019
//This is currently abandoned

//---</LOGS>---

//---<Bugs or Questions in Mind>---
//---</Bugs or Questions in Mind>---

public class input_Dropzone : MonoBehaviour,IDropHandler
{
    public void OnDrop(PointerEventData eventData)
    {
        if (eventData.pointerDrag.GetComponent<unallocated_Property>().allocated)
           
        {
            this.GetComponent<InputField>().text = eventData.pointerDrag.GetComponent<unallocated_Property>().inner_Text;
        }
    }
}
