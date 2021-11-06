using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemUI : MonoBehaviour
{
    public Inventory inventory;
    private Text text;
    // Start is called before the first frame update
    void Start()
    {
        text = GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        string pt1 = "Has Key: " + (inventory.has_key ? "true" : "false");
        //string pt2 = "Has Tranquilizer: " + (inventory.has_tranquilizer ? "true" : "false");
        string pt3 = "Has Taser: " + (inventory.has_taser); //? "true" : "false");
        text.text = pt1 +   "\n" + pt3;
    }
}
