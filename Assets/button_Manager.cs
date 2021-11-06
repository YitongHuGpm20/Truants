using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class button_Manager : MonoBehaviour, IPointerEnterHandler,IPointerExitHandler
{
    private void OnDestroy()
    {
        cursor_Management.cursorObj.GetComponent<cursor_Management>().on_Normal();  
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        cursor_Management.cursorObj.GetComponent<cursor_Management>().on_HoverButton();
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        cursor_Management.cursorObj.GetComponent<cursor_Management>().on_Normal();
    }
}
