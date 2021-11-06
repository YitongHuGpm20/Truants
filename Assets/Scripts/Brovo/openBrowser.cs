using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class openBrowser : MonoBehaviour
{
    public GameObject browserline;
    public GameObject browserWindow;
    public GameObject tabFaceMatch;
    public GameObject tabIMMA;
    public GameObject pageFaceMatch;
    public GameObject pageIMMA;
    public Sprite backgroundFaceMatch;
    public Sprite backgroundIMMA;
    public Color currentTabColor;
    public Color otherTabColor;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ClickBrowser()
    {
        browserline.SetActive(true);
        browserWindow.SetActive(true);

    }

    public void closeBrowser()
    {
        browserline.SetActive(false);
        browserWindow.SetActive(false);
    }

    public void minBrowser()
    {
        browserline.SetActive(true);
        browserWindow.SetActive(false);
    }
    
    public void OpenFaceMatch()
    {
        tabFaceMatch.gameObject.GetComponent<Image>().color = currentTabColor;
        tabIMMA.gameObject.GetComponent<Image>().color = otherTabColor;
        pageFaceMatch.SetActive(true);
        pageIMMA.SetActive(false);
        browserWindow.gameObject.GetComponent<Image>().sprite = backgroundFaceMatch;
    }

    public void OpenIMMA()
    {
        tabIMMA.gameObject.GetComponent<Image>().color = currentTabColor;
        tabFaceMatch.gameObject.GetComponent<Image>().color = otherTabColor;
        pageIMMA.SetActive(true);
        pageFaceMatch.SetActive(false);
        browserWindow.gameObject.GetComponent<Image>().sprite = backgroundIMMA;
    }
}
