using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class change_xPloit : MonoBehaviour
{
    public GameObject background;
    public GameObject installButton;
    public GameObject downloadBar;
    public GameObject messenger;
    private GameObject xPloitShortcut;
    public Sprite BGPlain;
    public float waitTime;

    private void Awake()
    {

        messenger = GameObject.Find("Canvas").transform.Find("Desktop1").Find("TaskBar").Find("Apps").gameObject ;

    }
    void Update()
    {
        if (loadingbar.ifFinished)
        {
            waitTime += Time.deltaTime;
            if (waitTime > 11)
            {
                messenger.SetActive(true);
                GameManager.sd4 = true;
                Component[] temp = messenger.GetComponentsInChildren(typeof(xPloit), true);
                foreach (xPloit vs in temp)
                    vs.gameObject.SetActive(true);
                this.gameObject.SetActive(false);
                waitTime = 0;
                loadingbar.ifFinished = false;
                
            }
        }
    }

    public void InstallButton()
    {
        background.GetComponent<Image>().sprite = BGPlain;
        installButton.SetActive(false);
        downloadBar.SetActive(true);
    }
}
