using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class changeImage : MonoBehaviour
{
    public GameObject background;
    public GameObject installButton;
    public GameObject downloadBar;
    public GameObject messenger;

    public Sprite BGPlain;
    public float waitTime;

    void Update()
    {
       if (loadingbar.ifFinished)
        {
            waitTime += Time.deltaTime;
            if(waitTime > 11)
            {
                messenger.SetActive(true);
                this.gameObject.SetActive(false);
                loadingbar.ifFinished = false;
                waitTime = 0;
            }
        }
    }

    public void InstallButton()
    {
        background.GetComponent<Image>().sprite = BGPlain;
        installButton.SetActive (false);
        downloadBar.SetActive(true);
    }
}
