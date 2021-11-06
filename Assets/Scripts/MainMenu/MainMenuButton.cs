using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class MainMenuButton : MonoBehaviour, ISelectHandler, IPointerEnterHandler, IPointerExitHandler
{
    public Button otherButton;

    public void OnPointerEnter(PointerEventData eventData)
    {
        otherButton.Select();
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        EventSystem.current.GetComponent<EventSystem>().SetSelectedGameObject(null);
    }

    public void OnSelect(BaseEventData eventData)
    {
        //otherButton.onClick.Invoke();
    }

    
}
