using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using UnityEngine.EventSystems;
///Created in 11/01/2019 by Zijie Zhang
//---<LOGS>---

//---<Purpose>---
//The purpose of this script is to create drag and drop function for each keywords that are already allocated in Goodpoint.
//---</Purpose>---

//11/05/2019
//Created for draging and dropping unallocated keywords


//---</LOGS>---

//---<Bugs or Questions in Mind>---
//---</Bugs or Questions in Mind>---
public class Keywords_DragDrop : MonoBehaviour, IDragHandler, IEndDragHandler, IBeginDragHandler , IPointerDownHandler
{
    //Transform parentReturn = null; //parent to return to
    private Vector2 originalLocalPointerPosition;

    public void OnBeginDrag(PointerEventData eventData)
    {
        //parentReturn = this.transform.parent;
        //this.transform.SetParent(Gameobj_Manager.LoginScreen.transform); //begin to drag, store the original parent

        this.GetComponent<CanvasGroup>().blocksRaycasts = false; //begin brag
        this.GetComponent<Allocated_Property>().On_Click();

        GoodPoint_Manager.Description_Text.transform.Find("Description_Text_Area").GetComponent<Text>().text = this.GetComponent<Allocated_Property>().description; //make the description change to the keyword's description
    }
    public void OnDrag(PointerEventData eventData)
    {
        //this.transform.position = new Vector3((Input.mousePosition).x,(Input.mousePosition).y, transform.position.z); ; //drag as mouse position
        var screenPoint = (Input.mousePosition);
        screenPoint.z = 40.0f; //distance of the plane from the camera
        transform.position = Camera.main.ScreenToWorldPoint(screenPoint); //line up with the camera
        //foreach(Transform temp in this.transform.parent)
        //{
        //    temp.position = new Vector3(temp.position.x,temp.position.y,-10);
        //    temp.parent.position = new Vector3(temp.position.x, temp.position.y, -10);
        //}
        //Debug.Log("this"+ this.transform.position+" Mouse"+ Input.mousePosition); 
        Debug.Log(this.transform.parent.gameObject.layer);
        
    }

    public void OnPointerDown(PointerEventData data)
    {
        RectTransform parentRectTransform = GoodPoint_Manager.goodpoint.transform.parent as RectTransform;
        Vector3 originalPanelLocalPosition = GoodPoint_Manager.goodpoint.transform.localPosition;
        RectTransformUtility.ScreenPointToLocalPointInRectangle(parentRectTransform, data.position, data.pressEventCamera, out originalLocalPointerPosition);
        GoodPoint_Manager.goodpoint.transform.SetAsLastSibling();
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        //transform.SetParent(parentReturn); //when finish draging, set it back to original parent
        //this.transform.parent.SetParent(this.transform.parent.parent);
        //this.transform.SetParent(parentReturn);

        transform.localPosition = Vector3.zero;
        //set back the position


        this.GetComponent<CanvasGroup>().blocksRaycasts = true;

        //foreach (Transform temp in this.transform.parent)
        //{
        //    temp.position = new Vector3(temp.position.x, temp.position.y, 0);
        //    temp.parent.position = new Vector3(temp.position.x, temp.position.y, 0);
        //}

        Debug.Log(this.transform.parent.gameObject.layer);
    }
}
