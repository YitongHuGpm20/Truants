using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class suggest_Control : MonoBehaviour,IPointerDownHandler,IPointerEnterHandler,IPointerExitHandler
{
    public void OnPointerDown(PointerEventData eventData)
    {
        Searching_Manager.input_Fieldobj.GetComponent<InputField>().text = this.GetComponentInChildren<Text>().text;
        this.GetComponent<Image>().color = Color.cyan;
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        Searching_Manager.current_SuggestedIndex = this.transform.GetSiblingIndex();
        this.GetComponent<Image>().color = Color.cyan;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        Searching_Manager.current_SuggestedIndex = 0;
        this.GetComponent<Image>().color = Color.white;
    }
}
