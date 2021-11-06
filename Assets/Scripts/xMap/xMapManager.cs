using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public enum roomState {available, forbidden, selected};

public class xMapManager : MonoBehaviour
{
    public int remaining_turn;
    public int elapsed_turn = 0;
    public int player_in_roomID;
    public RoomController[] rooms;
    public Inventory inventory;

    private int guardA_turn;
    private int guardB_turn;
    private int guardC_turn;

    [Header("Guard Rountine")]
    public int[] rountineA;
    public int[] rountineB;
    public int[] rountineC;

    [Header("Popup management")]
    public Transform popup_location;
    public string unlock_msg, no_key_msg;
    public PopupText popup;

    // Start is called before the first frame update
    void Start()
    {
        player_in_roomID = 2;
        rooms[2].currentState = roomState.selected;
        ChangeConnected(2);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void NextTurn(int roomID)
    {
        Debug.Log("the room you clicked is " + roomID);
        if (roomID == 19|| roomID == 20)
        {
            rooms[roomID].connected_rooms[0].transform.parent.localScale = new Vector3(1, 1, 1);
            rooms[roomID].connected_rooms[1].transform.parent.localScale = new Vector3(0, 0, 0);
            TakeTurn(rooms[roomID].connected_rooms[0].roomID);
            foreach (Button action in rooms[roomID].actions)
            {
                // Reset buttons
                action.enabled = true;
                action.gameObject.SetActive(false);
            }
            ResetAllRooms();
            UpdateGuard(rooms[roomID].connected_rooms[0].roomID);
            rooms[rooms[roomID].connected_rooms[0].roomID].currentState = roomState.selected;
            ChangeConnected(rooms[roomID].connected_rooms[0].roomID);
        }
        // Select an available room
        else if (rooms[roomID].currentState == roomState.available && !rooms[roomID].locked)
        {
            TakeTurn(roomID);
            // Room state management
            /*
            for (int i = 0; i < rooms.Length; ++i)
            {
                rooms[i].currentState = roomState.forbidden;
                rooms[i].guard.enabled = false;
                foreach (Button action in rooms[roomID].actions)
                {
                    // Reset buttons
                    action.enabled = true;
                    action.gameObject.SetActive(false);
                }
            }*/
            foreach (Button action in rooms[roomID].actions)
            {
                // Reset buttons
                action.enabled = true;
                action.gameObject.SetActive(false);
            }
            ResetAllRooms();
            UpdateGuard(roomID);
            rooms[roomID].currentState = roomState.selected;
            ChangeConnected(roomID);
        }
        // Select a locked room
        else if (rooms[roomID].currentState == roomState.available && rooms[roomID].locked)
        {
            PopupText clone;
            clone = Instantiate(popup, popup_location);
            // Unlocked successful
            if (inventory.has_key)
            {
                clone.text.text = unlock_msg;
                // actually take turn
                /*
                take_turn(player_in_roomID);
                foreach (Button action in rooms[roomID].actions)
                {
                    // Reset buttons
                    action.enabled = true;
                    action.gameObject.SetActive(false);
                }
                reset_all_rooms();
                update_guard(player_in_roomID);
                */
                rooms[roomID].currentState = roomState.available;
                rooms[roomID].locked = false;
                // Same as wait a turn
                rooms[player_in_roomID].currentState = roomState.available;
                NextTurn(player_in_roomID);
                // all the normal turn shit
            }
            else
                clone.text.text = no_key_msg;
            clone.BeginPopup();
        }
        // Further investigate the room player is in
        else if (rooms[roomID].currentState == roomState.selected)
        {
            foreach (Button action in rooms[roomID].actions)
            {
                action.gameObject.SetActive(true);
                // Reset buttons
                action.enabled = true;
            }
        }
    }

    void UpdateGuard(int roomID)
    {
        // Update Guard movement
        int guardA = rountineA[elapsed_turn];
        Debug.Log(guardA);
        // rooms[guardA].currentState = roomState.dangerous;
        rooms[guardA].guard.enabled = true;
        if (player_in_roomID == guardA)
        {
            Debug.Log("Encounter Guard");
            PopupText clone;
            if (inventory.has_taser > 0)
            {
                clone = Instantiate(popup, popup_location);
                clone.text.text = "The guard is put down by taser";
                clone.BeginPopup();
                inventory.has_taser--;
            }
            //else if (inventory.has_tranquilizer)
            //{
            //    clone = Instantiate(popup, popup_location);
            //    clone.text.text = "The guard is put down by tranquilizer";
            //    clone.begin_pop();
            //}
            else
            {
                clone = Instantiate(popup, popup_location);
                clone.text.text = "You are caught";
                clone.BeginPopup();
                //fail state
            }
        }       
    }

    void TakeTurn(int roomID)
    {
        player_in_roomID = roomID;
        // Turn management
        remaining_turn -= 1;
        elapsed_turn += 1;
    }

    void ResetAllRooms()
    {
        for (int i = 0; i < rooms.Length; ++i)
        {
            if (rooms[i].currentState != roomState.selected)
            {
                rooms[i].currentState = roomState.forbidden;
                rooms[i].guard.enabled = false;
            }
        }
    }

    void ChangeConnected(int roomID)
    {
        // Parse the Rooms connected to the current room
        for (int i = 0; i < rooms[roomID].connected_rooms.Length; ++i)
            rooms[roomID].connected_rooms[i].currentState = roomState.available;
    }
}
