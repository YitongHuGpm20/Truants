using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InfoDisplay : MonoBehaviour
{
    public xMapManager xmapManager;
    private Text text;

    // Start is called before the first frame update
    void Start()
    {
        text = GetComponent<Text>();
        xmapManager = GameObject.Find("cctvManager").GetComponent<xMapManager>();
    }

    // Update is called once per frame
    void Update()
    {
        string pt1 = "Player in room: " + (xmapManager.player_in_roomID == 0 ? "0" : xmapManager.player_in_roomID.ToString());
        string pt2 = "Remaining Turn: " + xmapManager.remaining_turn;
        string pt3 = "Elapsed Turn: " + xmapManager.elapsed_turn;
        text.text = pt1 + "\n" + pt2 + "\n" + pt3;
    }
}
