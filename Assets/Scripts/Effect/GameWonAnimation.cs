using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameWonAnimation : MonoBehaviour
{

    public Animator animator;
    public AudioClip dialogueClip;
    public AudioClip scottPhone;
    public AudioSource thisSource;
    public GameObject scottVO;
    public GameObject tinaVO;

    public bool alldocsOpened;
    public bool startPlaying = false;

    public float timer = 0.0f;
    public float waitTime = 5.5f;
    Image fadetoBlackImage;
    public void Start()
    {
        thisSource = GetComponent<AudioSource>();
        scottVO = GameObject.FindGameObjectWithTag("scottVO");
        tinaVO = GameObject.FindGameObjectWithTag("tinaVO");
        fadetoBlackImage = this.gameObject.GetComponent<Image>();
    }

    public void Update()
    {
        fadetoBlackImage = this.gameObject.GetComponent<Image>();
        triggerFade();
        if (alldocsOpened == true)
        {
            timer += Time.deltaTime;

            if(timer >= waitTime)
            {
                SettingsManager.instance.bgmVolume = .05f;
                FadetoBlack(1);
                scottVO.GetComponent<AudioSource>().enabled = true;
                tinaVO.GetComponent<AudioSource>().enabled = true;
                dialogueManager.Instance.BeginDialogue(dialogueClip);
                fadetoBlackImage.enabled = false;
                alldocsOpened = false;
            }


        }
    }

    public void FadetoBlack (int levelState)
    {
        animator.SetTrigger("fadeOut");
    }

    public void triggerFade()
    {
        if (!startPlaying)
        {
            if (GameManager.gameWonAnimation)
            {
                alldocsOpened = true;
                startPlaying = true;
                thisSource.PlayOneShot(scottPhone, 0.7f);
                GameManager.gameWonAnimation = false;
            }
        }
    }
}
