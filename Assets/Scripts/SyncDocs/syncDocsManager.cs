using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class syncDocsManager : MonoBehaviour
{
    //public GameObject SDTab1;
    public GameObject SDConv1;
    public GameObject SDConv2;
    public GameObject SDTab2;
    //public GameObject SDBM2;
    public GameObject sd2Manager;

    public GameObject SDConv3;
    public GameObject SDTab3;
    //public GameObject SDBM3;
    public GameObject sd3Manager;

    public GameObject SDConv4;
    public GameObject SDTab4;
    //public GameObject SDBM4;
    public GameObject sd4Manager;

    public GameObject SDConv5;
    public GameObject SDTab5;
   // public GameObject SDBM5;
    public GameObject sd5Manager;

    public GameObject SDConv6;
    public GameObject SDTab6;
    //public GameObject SDBM6;
    public GameObject sd6Manager;
    public GameObject Notification;
    bool once = true;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log("sdend1: " + GameManager.sdend1);
        //Debug.Log("sd2: " + GameManager.sd2);

        //sd2
        if (GameManager.sd2 && GameManager.sdend[0])
        {
            SDConv2.SetActive(true);
            SDConv1.SetActive(false);
            sd2Manager.SetActive(true);
            SDTab2.SetActive(true);
            Notification.SetActive(true);
            SettingsManager.instance.playSFXByID(7);
            //SDBM2.SetActive(true);
            GameManager.sdScroll2 = true;
            GameManager.sd2 = false;
            GameManager.sdend[1] = false;
            once = false;
        }

        //sd3
        if (GameManager.sd3 && GameManager.sdend[1])
        {
            Debug.Log("khulja bc");
            SDConv3.SetActive(true);
            SDConv2.SetActive(false);
            sd3Manager.SetActive(true);
            SDTab3.SetActive(true);
            Notification.SetActive(true);
            SettingsManager.instance.playSFXByID(7);
            // SDTab1.SetActive(false);
            //SDBM3.SetActive(true);
            GameManager.sdScroll3 = true;
            GameManager.sd3 = false;
            GameManager.sdend[2] = false;
        }

        //sd4
        if (GameManager.sd4 && GameManager.sdend[2])
        {
            SDConv4.SetActive(true);
            SDConv3.SetActive(false);
            sd4Manager.SetActive(true);
            SDTab4.SetActive(true);
            Notification.SetActive(true);
            SettingsManager.instance.playSFXByID(7);
            GameManager.sdScroll4 = true;
            //SDBM4.SetActive(true);
            GameManager.sd4 = false;
            GameManager.sdend[3] = false;
        }

        //sd5
        if (GameManager.sd5)
        {
            //Debug.Log("sd5 khulja bc");
            SDConv5.SetActive(true);
            SDConv4.SetActive(false);
            sd5Manager.SetActive(true);
            SDTab5.SetActive(true);
            Notification.SetActive(true);
            SettingsManager.instance.playSFXByID(7);
            GameManager.sdScroll5 = true;
            // SDBM5.SetActive(true);
            GameManager.sd5 = false;
            GameManager.sdend[4] = false;
        }


        //sd6
        if (GameManager.sd6)
        {
            SDConv6.SetActive(true);
            SDConv5.SetActive(false);
            sd6Manager.SetActive(true);
            //Debug.Log("sd6 khulja bc");
            SDTab6.SetActive(true);
            Notification.SetActive(true);
            SettingsManager.instance.playSFXByID(7);
            GameManager.sdScroll6 = true;
            // SDBM6.SetActive(true);
            GameManager.sd6 = false;
            //GameManager.sdend5 = false;
        }

    }

    //sd2
    public void sd2conv()
    {
        if (once)
        {
            GameManager.sd2 = true;
            SettingsManager.instance.playSFXByID(15);
        }
        
        Debug.Log("sd2: " + GameManager.sd2);
    }

    //public void startsd2()
    //{
    //    //SDConv2.SetActive(true);
    //    //sd2Manager.SetActive(true);
        
    //}

    ////sd3
    //public void startsd3()
    //{
    //    SDConv3.SetActive(true);
    //    sd3Manager.SetActive(true);

    //}

    ////sd4
    //public void startsd4()
    //{
    //    SDConv4.SetActive(true);
    //    sd4Manager.SetActive(true);
    //}

    ////sd5
    //public void startsd5()
    //{
    //    SDConv5.SetActive(true);
    //    sd5Manager.SetActive(true);
    //}

    ////sd6
    //public void startsd6()
    //{
    //    SDConv6.SetActive(true);
    //    sd6Manager.SetActive(true);
    //}
}
