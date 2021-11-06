using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

//Created in 10/19/2019 by Zijie Zhang

//---<Purpose>---
//The purpose of this script is to change the cursor if it hovers on top of clickable
//---<LOGS>---

//10/01/2019
//created basic function

//---</LOGS>---

//---<Bugs or Questions in Mind>---
//1.Usage
//2.Animations
//---</Bugs or Questions in Mind>---

public class cursors_Hover : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public Texture2D normal;
    public Texture2D interact_Before;
    public Texture2D interact_After; //temporary not in used, abandon

    public void OnPointerEnter(PointerEventData event_Data)
    {
        Cursor.SetCursor(interact_Before,Vector2.zero,CursorMode.Auto);
       
    }

    public void OnPointerExit(PointerEventData event_Data)
    {
        Cursor.SetCursor(normal, Vector2.zero, CursorMode.Auto);
    }
    
}
