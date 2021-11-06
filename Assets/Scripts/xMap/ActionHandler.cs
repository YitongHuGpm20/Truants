using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ActionHandler : MonoBehaviour
{
    public Button wait;
    public Button search;
    public Button openDoor;
    public xMapManager xmapManager;
    public Inventory inventory;

    [Header("Popup management")]
    public Transform popup_location;
    public string key_msg, tranquilizer_msg, taser_msg, no_item_msg;
    public PopupText popup;

    // Start is called before the first frame update
    void Start()
    {
        wait.onClick.AddListener(waitAction);
        search.onClick.AddListener(searchAction);
        openDoor.onClick.AddListener(openDoorAction);
    }

    private void waitAction()
    {
        Debug.Log("wait");
        xmapManager.rooms[xmapManager.player_in_roomID].currentState = roomState.available;
        xmapManager.NextTurn(xmapManager.player_in_roomID);
    }

    private void searchAction()
    {
        Debug.Log("search");
        PopupText clone;
        // tranquilizer
        if(xmapManager.player_in_roomID == 10)
        {
            clone = Instantiate(popup, popup_location);
            clone.text.text = taser_msg;
            inventory.has_taser++;
            clone.BeginPopup();
        }
        else if(xmapManager.player_in_roomID == 6)
        {
            clone = Instantiate(popup, popup_location);
            clone.text.text = taser_msg;
            inventory.has_taser++;
            clone.BeginPopup();
        }
        else if(xmapManager.player_in_roomID == 4)
        {
            clone = Instantiate(popup, popup_location);
            clone.text.text = key_msg;
            inventory.has_key = true;
            clone.BeginPopup();
        }
        else
        {
            // No item found
            clone = Instantiate(popup, popup_location);
            clone.text.text = no_item_msg;
            clone.BeginPopup();
        }
        search.enabled = false;
        // Deactivate the button before removing it
        xmapManager.rooms[xmapManager.player_in_roomID].actions[1].gameObject.SetActive(false);
        xmapManager.rooms[xmapManager.player_in_roomID].actions.RemoveAt(1);
        xmapManager.rooms[xmapManager.player_in_roomID].currentState = roomState.available;
        xmapManager.NextTurn(xmapManager.player_in_roomID);
    }

    private void openDoorAction()
    {
        Debug.Log("open");
    }
}
