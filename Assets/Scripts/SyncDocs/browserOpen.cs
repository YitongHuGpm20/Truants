using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class browserOpen : MonoBehaviour
{
    public GameObject browser;
    public GameObject SDConv;
    public GameObject browserTab;
    public GameObject SDBMTab;
    public Brovo browserScript;
    public GameObject TypingManager1;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void clickBrowser()
    {
        browser.SetActive(true);
        browser.transform.SetAsLastSibling();
        browserTab.SetActive(true);
        SDConv.SetActive(true);
        TypingManager1.SetActive(true);
        browserScript.OpenTabWebsite(1);
        SDBMTab.SetActive(true);
        
    }
}
