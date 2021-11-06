using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class RoomHandler : EventTrigger
{
    private RoomController room;

    private void Start()
    {
        room = GetComponent<RoomController>();
    }
    public override void OnPointerEnter(PointerEventData data)
    {
        //Debug.Log("OnPointerEnter called.");
        room.roomImage.transform.localScale *= 1.2f;
    }

    public override void OnPointerExit(PointerEventData data)
    {
        //Debug.Log("OnPointerExit called.");
        room.roomImage.transform.localScale /= 1.2f;
    }

    public override void OnPointerClick(PointerEventData data)
    {
        //Debug.Log("OnPointerClick called.");
        room.xmapManager.NextTurn(room.roomID);
    }
}
