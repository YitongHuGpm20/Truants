using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class messenger : MonoBehaviour
{
    public GameObject messengerline;
    public GameObject messengerWindow;
    public GameObject slider;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (this.gameObject.activeInHierarchy)
            messengerWindow.GetComponent<scalePanel>().enabled = true;
    }

    //public void ClickBrowser()
    //{
    //    messengerline.SetActive(true);
    //    messengerWindow.transform.localScale = new Vector3(0.1f, 1, 1);
    //    messengerWindow.transform.SetAsLastSibling();

    //}

    public void closeBrowser()
    {
        messengerline.SetActive(false);
        slider.SetActive(false);
        messengerWindow.transform.localScale = new Vector3(0, 0, 0);
    }

    public void minBrowser()
    {
        messengerline.SetActive(true);
        slider.SetActive(false);
        messengerWindow.transform.localScale = new Vector3(0, 0, 0);
    }
}
