using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DownloadVisager : MonoBehaviour
{

    public GameObject downloadPanel;
    public GameObject visagerButton;
    
    

    public void OpenDownload()
    {
        downloadPanel.SetActive(true);
    }

    public void CloseDownload()
    {
        downloadPanel.SetActive(false);
    }

    public void MessageButton()
    {
        if (visagerButton.activeInHierarchy == false)
        {
            //visagerScreen.SetActive(true);
            ////visagerScreen.transform.localScale = new Vector3(1, 1, 1);
            //slider.SetActive(true);
            //slider.GetComponent<Slider>().value = 1;
            //visagerScreen.transform.SetAsLastSibling();
            OpenDownload();
        }
        else
        {
            Messenger_Manager.messenger_Obj.GetComponent<Messenger_Manager>().On_Click_Icon();
        }

    }
}
