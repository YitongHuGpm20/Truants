using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Scrollbar_CreatePanel : MonoBehaviour
{
    public GameObject scroll_Bar;

    private void Awake()
    {
        scroll_Bar.GetComponent<Scrollbar>().interactable = false;
    }
}
