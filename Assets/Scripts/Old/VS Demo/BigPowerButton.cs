using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
//using UnityEngine.EventSystems;

public class BigPowerButton : MonoBehaviour
{
    public Sprite buttonOff;
    public Sprite buttonPress;
    public Sprite buttonOn;
    public GameObject openScreen;
    private float loadTime;
    private bool isOn;
    private bool isPressed;

    /*private void OnPointerDown()
    {
        gameObject.GetComponent<Image>().sprite = buttonPress;
        Debug.Log("jjjjjj");
    }

    private void OnMouseUp()
    {
        gameObject.GetComponent<Image>().sprite = buttonOn;
        //wait a few seconds to load next screen
        //play computer power on sound
    }*/

    private void Start()
    {
        loadTime = 0;
        isOn = false;
        isPressed = false;
    }

    private void Update()
    {
        if (isOn)
            loadTime += Time.deltaTime;

        if (loadTime > 0.5)
            openScreen.SetActive(false);
    }

    public void TurnOnPC()
    {
        gameObject.GetComponent<Image>().sprite = buttonPress;
        isOn = true;
    }
}
