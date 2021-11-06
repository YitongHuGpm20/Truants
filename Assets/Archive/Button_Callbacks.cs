using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Button_Callbacks : MonoBehaviour
{
    public List<GameObject> interacble_Groups;
    public Texture2D interacted;
    public Texture2D not_Interacted;
    public Texture2D normal;
    private void Awake()
    {
        foreach(Transform obj in this.gameObject.transform)
        {
            interacble_Groups.Add(obj.gameObject);
        }
    }

    void debug_Object_Name()
    {
        Debug.Log("hi");
    }

    void set_Cursor_Interacted()
    {
        Cursor.SetCursor(interacted, Vector2.zero, CursorMode.Auto);
    }

    void set_Cursor_Not_Interacted()
    {
        Cursor.SetCursor(not_Interacted, Vector2.zero, CursorMode.Auto);
    }

    void set_Cursor_Normal()
    {
        Cursor.SetCursor(normal, Vector2.zero, CursorMode.Auto);
    }

    public class interactable_Points{
        bool completed;
    }
}
