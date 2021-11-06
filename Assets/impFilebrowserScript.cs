using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class impFilebrowserScript : MonoBehaviour
{
    public GameObject thispcWindow;
    

    public void closeBrowser()
    {
        
        thispcWindow.SetActive(false);
    }
}
