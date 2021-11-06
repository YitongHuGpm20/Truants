using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class cursor_Management : MonoBehaviour
{
    private Texture2D normal_Sprite;
    private SpriteRenderer renderThing;
    //private GameObject trail_Effect;
    private GameObject click_Effect;

    public float time_Init = 0.1f;

    private Texture2D drag_Sprite;
    private Texture2D hover_Sprite;
    private GameObject canvas;
    public static GameObject cursorObj;

    private void Awake()
    {
        cursorObj = this.gameObject;
        add_MouseEvent();
        //trail_Effect = Resources.Load("Images/Cursor/SparkleYellow_2") as GameObject;
        renderThing = this.GetComponent<SpriteRenderer>();
        //Cursor.visible = false;
        normal_Sprite = Resources.Load("Images/TempAssets/Cursor/Aero-Normal") as Texture2D;
        drag_Sprite = Resources.Load("Images/TempAssets/Cursor/Move") as Texture2D;
        hover_Sprite = Resources.Load("Images/TempAssets/Cursor/Aero-Link") as Texture2D;

        Cursor.SetCursor(normal_Sprite, Vector2.zero, CursorMode.ForceSoftware);

        //Cursor.SetCursor(cursor_Texture, Vector2.zero, CursorMode.ForceSoftware);
    }

    private void Update()
    {
        Vector3 pos = (Input.mousePosition);
        pos.z = 100;
        this.transform.position = Camera.main.ScreenToWorldPoint(pos);

        if (Input.GetMouseButtonDown(0)) { }
        else if (Input.GetMouseButtonUp(0)) { }

        if (time_Init <= 0)
        {
            //Instantiate(trail_Effect, Camera.main.ScreenToWorldPoint(pos), Quaternion.identity);
        }
        else
        {
            time_Init -= Time.deltaTime;
        }

    }

    public void on_HoverButton()
    {
        Cursor.SetCursor(hover_Sprite, Vector2.zero, CursorMode.ForceSoftware);
    }

    public void on_Dragging()
    {
        Cursor.SetCursor(drag_Sprite, Vector2.zero, CursorMode.ForceSoftware);
    }

    public void on_Normal()
    {
        Cursor.SetCursor(normal_Sprite, Vector2.zero, CursorMode.ForceSoftware);
    }

    private void add_MouseEvent()
    {
        canvas = GameObject.Find("Canvas").gameObject;
        Button[] buttons = canvas.GetComponentsInChildren<Button>(true);

        EventTrigger.Entry new_MouseHoverevent = new EventTrigger.Entry();
        new_MouseHoverevent.eventID = EventTriggerType.PointerEnter;
        new_MouseHoverevent.callback.AddListener((eventData) => { on_HoverButton(); });

        EventTrigger.Entry new_MouseExitevent = new EventTrigger.Entry();
        new_MouseExitevent.eventID = EventTriggerType.PointerExit;
        new_MouseExitevent.callback.AddListener((eventData) => { on_Normal(); });

        ////EventTrigger.Entry new_MouseClickevent = new EventTrigger.Entry();
        ////new_MouseClickevent.eventID = EventTriggerType.PointerClick;
        ////new_MouseClickevent.callback.AddListener((eventData) => { on_Normal(); });

        //button_Manager button_manage = this.gameObject.GetComponent<button_Manager>();
        foreach (Button temp in buttons)
        {
            EventTrigger newTrigger = temp.gameObject.AddComponent<EventTrigger>();
            newTrigger.triggers.Add(new_MouseExitevent);
            newTrigger.triggers.Add(new_MouseHoverevent);
            //newTrigger.triggers.Add(new_MouseClickevent);
            //temp.gameObject.AddComponent<button_Manager>();
        }
    }

    //private void raycast_Check()
    //{
    //    Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
    //    RaycastHit hit;

    //    if (Physics.Raycast(ray, out hit))
    //    {
    //        if (hit.transform.gameObject.GetComponent<Button>())
    //        {
    //            Debug.Log("This is a Button");
    //        }
    //        else
    //        {
    //            Debug.Log("This isn't a Player");
    //        }
    //    }
    //}



}
