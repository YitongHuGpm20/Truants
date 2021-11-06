using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class faceMatchLogin : MonoBehaviour
{
    [SerializeField]
    private InputField Password;


    public static bool checkmail = false;
    public GameObject notFilled;
    public GameObject incorrect;
   // public GameObject login;
    public GameObject initiallogin;
    public GameObject security;
    public GameObject facematch;
    public GameObject mailMessage;
    //public GameObject Loading;
    float time;
    float loadingTime;
    bool notfilledTime;
    bool incorrectTime;
    bool loginoff;

    //security elements

    [SerializeField]
    private InputField gfName;

    [SerializeField]
    private InputField eMail;

    public GameObject entergf;
    public GameObject nogf;
    public GameObject goback;

    // Start is called before the first frame update
    public void Start()
    {
        notfilledTime = false;
        incorrectTime = false;
        loginoff = false;
    }

   

    public void LoginInfo()
    {
        //string username = Username.text;
        string password = Password.text;

        if (password == "")
        {
            notFilled.SetActive(true);
            notfilledTime = true;
        }

        else if (password == "truants")
        {
            //login.SetActive(false);
            loginoff = true;
            password = "";
            //Animator Screen Loading
            //Loading.SetActive(true);
            //end animation

        }
        else
        {
            incorrect.SetActive(true);
            incorrectTime = true;
        }
    }

    public void Securityinfo()
    {
        initiallogin.SetActive(false);
        security.SetActive(true);
    }

    public void Update()
    {


        if (incorrectTime)
            time += Time.deltaTime;

        if (notfilledTime)
            time += Time.deltaTime;

        

        if (time > 3.0f)
        {
            entergf.SetActive(false);
            nogf.SetActive(false);
            incorrect.SetActive(false);
            notFilled.SetActive(false);
            notfilledTime = false;
            incorrectTime = false;
            time = 0;
        }

        if (loginoff)
        {

            initiallogin.SetActive(false);
            //animation of new panel
            facematch.SetActive(true);
            //end animation
        }

        Debug.Log(checkmail);

    }

    public void gfInfo()
    {
        string gfname = gfName.text;
        string email = eMail.text;

        if (gfname == "" || email == "")
        {
            entergf.SetActive(true);
            notfilledTime = true;

        }

        else if (gfname == "bridget" && email == "scottbowers@yeemeow.com")
        {
            //login.SetActive(false);
            gfname = "";
            checkmail = true;
            goback.SetActive(true);
            mailMessage.SetActive(true);
            //Animator Screen Loading
            //Loading.SetActive(true);
            //end animation

        }
        else
        {
            nogf.SetActive(true);
            incorrectTime = true;
        }
    }

    public void refresh()
    {
        security.SetActive(false);
        initiallogin.SetActive(true);
    }
}
