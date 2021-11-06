using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Resizable_Window : MonoBehaviour,IPointerDownHandler,IPointerUpHandler
{
    public bool Begin_Resizing;
    public Vector3 lastMouseCoordinate = Vector3.zero;
    private Transform This_Transform;
    private Rect This_Rect;
    private RectTransform This_Rectransform;
    private enum Scale_Direction { Left,Right,Up,Down};

    public Vector2 Top_Left;
    public Vector2 Bot_Left;
    public Vector2 Top_Right;
    public Vector2 Bot_Right;



    private void Awake()
    {
        This_Transform = this.gameObject.transform;
        This_Rect = this.GetComponent<RectTransform>().rect;
        This_Rectransform = this.GetComponent<RectTransform>();
    }
    public void OnPointerUp(PointerEventData eventData)
    {
        Start_Scale();
        Begin_Resizing = false;
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        Begin_Resizing = true;
        Top_Left = new Vector2(This_Transform.position.x - This_Rect.width / 2, This_Transform.position.y + This_Rect.height / 2);
        Bot_Left = new Vector2(This_Transform.position.x - This_Rect.width / 2, This_Transform.position.y - This_Rect.height / 2);
        Top_Right = new Vector2(This_Transform.position.x + This_Rect.width / 2, This_Transform.position.y + This_Rect.height / 2);
        Bot_Right = new Vector2(This_Transform.position.x + This_Rect.width / 2, This_Transform.position.y - This_Rect.height / 2);
        Check_MousePos(eventData);

    }

    private void Update()
    {
        Vector3 mouseDelta = Input.mousePosition - lastMouseCoordinate;

        // Then we check if it has moved to the left.
        if (mouseDelta.x !=0) // Assuming a negative value is to the left.
        // Then we store our mousePosition so that we can check it again next frame.
        lastMouseCoordinate = Input.mousePosition;
    }

    private void Check_MousePos(PointerEventData eventData)
    {
        if(Mathf.Abs(eventData.position.x-Top_Left.x) < 30f)
        {
            if (eventData.position.y < Top_Left.y && eventData.position.y > Bot_Left.y)
                Debug.Log("On left");
        }

        if(Mathf.Abs(eventData.position.x - Top_Right.x) < 30f)
        {
            if (eventData.position.y < Top_Right.y && eventData.position.y > Bot_Right.y)
                Debug.Log("On Right");
        }

        if (Mathf.Abs(eventData.position.y - Top_Right.y) < 30f)
        {
            if (eventData.position.x < Top_Right.x && eventData.position.x > Top_Left.x)
                Debug.Log("On Top");
        }

        if (Mathf.Abs(eventData.position.y - Bot_Right.y) < 30f)
        {
            if (eventData.position.x < Bot_Right.x && eventData.position.x > Bot_Left.x)
                Debug.Log("On Bot");
        }


    }

    private void Start_Scale()
    {
        Vector2 original_Pos = This_Transform.position;
        float original_Width = This_Rect.width;
        float offset = this.This_Rect.width - lastMouseCoordinate.x;
        float new_rect = this.This_Rect.width + (offset) / 2;
        float t = ((new_rect - original_Width)/2);
        Debug.Log(t);
        This_Rectransform.sizeDelta = new Vector2((this.This_Rect.width + (offset)/2), This_Rect.height);
        This_Transform.position = new Vector3(original_Pos.x - t, This_Transform.position.y, This_Transform.position.z);
    }
}
