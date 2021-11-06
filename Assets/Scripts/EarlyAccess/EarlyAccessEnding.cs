using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EarlyAccessEnding : MonoBehaviour
{
    public Animator animator;
    AudioSource thisSource;
    bool startPlaying = false;
    public float timer = 0.0f;
    public float waitTime = 5.5f;
    public GameObject earlyAccessEnding;

    public void Start()
    {
        thisSource = GetComponent<AudioSource>();
    }

    public void Update()
    {
        triggerFade();
        if (startPlaying && animator.GetCurrentAnimatorStateInfo(0).normalizedTime > 1 && !animator.IsInTransition(0))
            earlyAccessEnding.SetActive(true);
    }

    public void FadetoBlack (int levelState)
    {
        
    }

    public void triggerFade()
    {
        if (GameManager.earlyAccessEnding)
        {
            startPlaying = true;
            GameManager.earlyAccessEnding = false;
            animator.SetTrigger("fadeOut");
            
        }
                //startPlaying = true;
                //thisSource.PlayOneShot(scottPhone, 0.7f);
    }
}
