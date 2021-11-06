using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BouquetLogin : MonoBehaviour
{
    //IMMA USERNAME
    public GameObject loginUser;
    public InputField userName;
    public GameObject wrongname;
    public GameObject entername;
    //IMMA PASSWORD
    public GameObject ImmaLoginPassword;
    public InputField passWord;
    public GameObject wrongpassword;
    public GameObject enterpassword;
    //IMMA FORGOT
    public GameObject ImmaForgot;
    public InputField ImmasecurityAnswer;
    public GameObject wronganswer;
    public GameObject enteranswer;

    //IMMA EMAIL
    public GameObject bqEmailPanel;
    public InputField bqEmail;
    public GameObject enteranswer1;
    //IMMA PANEL
    public GameObject ImmaPanel;
    //IMMA DM
    public GameObject ImmaDM;
    public GameObject newDMdot;
    int voCount = 0;
    bool once = true;

    //messenger
    //public GameObject messenger;

    //IMMA Time system
    float time;
    float loadingTime;
    bool notfilledTime;
    bool incorrectTime;
    bool userpageoff;
    bool passwordpageOff;
    bool securityOff;
    bool panelOff;
    bool forgotPanelOff1;
    bool forgotPanelOff2;
    bool forgotPanelOff = false;
    //enter bools
    bool allowEnterUser;
    bool allowEnterAnswer;
    // Start is called before the first frame update
    void Start()
    {
        notfilledTime = false;
        incorrectTime = false;
        userpageoff = false;
        forgotPanelOff1 = false;
        forgotPanelOff2 = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (incorrectTime)
            time += Time.deltaTime;

        if (notfilledTime)
            time += Time.deltaTime;



        if (time > 3.0f)
        {
            //entergf.SetActive(false);
           // nogf.SetActive(false);
            entername.SetActive(false);
            wrongname.SetActive(false);
            enteranswer.SetActive(false);
            //enterEmail.SetActive(false);
            wronganswer.SetActive(false);
            enterpassword.SetActive(false);
            wrongpassword.SetActive(false);
            notfilledTime = false;
            incorrectTime = false;
            time = 0;
        }

        if (userpageoff)
        {

            loginUser.SetActive(false);
            //animation of new panel
            ImmaLoginPassword.SetActive(true);
            userpageoff = false;
            //end animation
        }

        if (passwordpageOff)
        {
            ImmaForgot.SetActive(true);
            ImmaLoginPassword.SetActive(false);
            passwordpageOff = false;
        }

        if (securityOff)
        {
            ImmaPanel.SetActive(true);
            ImmaLoginPassword.SetActive(false);
   
            //messenger.SetActive(true);

        }

        if (forgotPanelOff)
        {
            
           
            
            
                bqEmailPanel.SetActive(true);
           
                ImmaForgot.SetActive(false);
                forgotPanelOff = false;
               
            

        }

        if (forgotPanelOff1)
        {
            if (once)
            {
                GameManager.fourthmail = true;
                once = false;
            }
            ImmaLoginPassword.SetActive(true); 
            bqEmailPanel.SetActive(false);
            forgotPanelOff1 = false;
        }

        if (forgotPanelOff2)
        {
            ImmaLoginPassword.SetActive(true);
            bqEmailPanel.SetActive(false);
            forgotPanelOff2 = false;
        }

        if (panelOff)
        {
            ImmaDM.SetActive(true);
            ImmaPanel.SetActive(false);
            GameManager.bouquetButton = true;

            voCount++;
            if (voCount == 1)
            {
                SettingsManager.instance.PlaySFX2D(SettingsManager.instance.sfxClips[18]);
            }
        }
        else
        {
            ImmaDM.SetActive(false);
            //ImmaPanel.SetActive(true);
            GameManager.bouquetButton = false;
        }

        if (userName.text != "" && Input.GetKey(KeyCode.Return) && allowEnterUser)
        {
            ImmaUserName();
            allowEnterUser = false;
        }
        else
        {
            allowEnterUser = userName.isFocused;
        }

        if (ImmasecurityAnswer.text != "" && Input.GetKey(KeyCode.Return) && allowEnterAnswer)
        {
            ImmaSecurityAnswer();
            allowEnterAnswer = false;
        }
        else
        {
            allowEnterAnswer = ImmasecurityAnswer.isFocused;
        }
    }

    public void ImmaUserName()
    {
        string username = userName.text;

        if (username == "")
        {
            SettingsManager.instance.playSFXByID(1);
            entername.SetActive(true);
            notfilledTime = true;
        }

        else if (username == "the.kwan.and.only" || username == "The.kwan.and.only" || username == "THE.KWAN.AND.ONLY")
        {

            //soundManager.instance.playSFXByID(6);
            //login.SetActive(false);
            userpageoff = true;
            username = "";
            //Animator Screen Loading
            //Loading.SetActive(true);
            //end animation

        }
        else
        {
            SettingsManager.instance.playSFXByID(1);
            wrongname.SetActive(true);
            incorrectTime = true;
        }
    }

    public void ImmaPassword()
    {
        string password = passWord.text;

        if (password == "")
        {
            enterpassword.SetActive(true);
            notfilledTime = true;
        }

        else if (password == "kwan181293")
        {
            //login.SetActive(false);
            //passwordpageOff = true;
            securityOff = true;
            password = "";
            //Animator Screen Loading
            //Loading.SetActive(true);
            //end animation

        }
        else
        {
            wrongpassword.SetActive(true);
            incorrectTime = true;
        }
    }

    public void immasecurity()
    {
        passwordpageOff = true;
    }

    public void ImmaSecurityAnswer()
    {
        string answer = ImmasecurityAnswer.text;
        //string email = EmailAddress.text;
        if (answer == "")
        {
            SettingsManager.instance.playSFXByID(1);
            enteranswer.SetActive(true);
            notfilledTime = true;
        }

        

        else if ((answer == "Miong" || answer == "miong" || answer == "MIONG"))
        {
            //planner_Manager.Destroy_Task();
            //planner_Manager.Destroy_Task();
            //Gameobj_Manager.Planner.GetComponent<planner_Manager>().initialize_Newtask("Confront Rena on Haiyoo about her affair.");
            //soundManager.instance.playSFXByID(6);
            //login.SetActive(false);

            forgotPanelOff = true;
            answer = "";
            //Animator Screen Loading
            //Loading.SetActive(true);
            //end animation

        }
        
        else
        {
            SettingsManager.instance.playSFXByID(1);
            wronganswer.SetActive(true);
            incorrectTime = true;
        }
    }

    public void bqEmailAnswer()
    {
        string answer = bqEmail.text;
        //string email = EmailAddress.text;
        if (answer == "")
        {
            SettingsManager.instance.playSFXByID(1);
            enteranswer1.SetActive(true);
            notfilledTime = true;
        }



        else if ((answer == "sbowers@scrumu.edu"))
        {
            //planner_Manager.Destroy_Task();
            //planner_Manager.Destroy_Task();
            //Gameobj_Manager.Planner.GetComponent<planner_Manager>().initialize_Newtask("Confront Rena on Haiyoo about her affair.");
            //soundManager.instance.playSFXByID(6);
            //login.SetActive(false);

            forgotPanelOff1 = true;
            answer = "";
            //Animator Screen Loading
            //Loading.SetActive(true);
            //end animation

        }

        else
        {
            forgotPanelOff2 = true;
            answer = "";
        }
    }

    public void DMopen()
    {
        panelOff = true;
        newDMdot.SetActive(false);
    }

    public void DMclose()
    {
        panelOff = false;
    }
}
