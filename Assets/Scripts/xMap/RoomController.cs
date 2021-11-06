using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RoomController : MonoBehaviour
{
    public int roomID;
    public RoomController[] connected_rooms;
    public Image roomImage;
    public List<Button> actions;
    public Image guard;
    public roomState currentState = roomState.forbidden;
    public bool locked;
    public xMapManager xmapManager;

    private Text text;

    void Start()
    {
        xmapManager = GameObject.Find("cctvManager").GetComponent<xMapManager>();
        roomImage = GetComponent<Image>();
        text =GetComponentInChildren<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        switch (currentState)
        {
            case roomState.available:
                if (!locked)
                    roomImage.color = Color.green;
                break;
            //case roomState.dangerous:
            //    roomImage.color = Color.red;
            //    break;
            case roomState.forbidden:
                    roomImage.color = Color.gray;
                break;
            case roomState.selected:
                roomImage.color = Color.white;
                break;
        }

        if(currentState == roomState.available && locked)
        {
            roomImage.color = Color.yellow;
        }
        //text.text = roomID.ToString();
    }
}
