using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOverAnimation : MonoBehaviour
{
    public Animator animator;
    AudioSource thisSource;
    bool startPlaying = false;
    public float timer = 0.0f;
    public float waitTime = 5.5f;
    public GameObject gameOverAnimation;

    public void Start()
    {
        thisSource = GetComponent<AudioSource>();
    }

    public void Update()
    {
        triggerFade();
        if (startPlaying && animator.GetCurrentAnimatorStateInfo(0).normalizedTime > 1 && !animator.IsInTransition(0))
            gameOverAnimation.SetActive(true);
    }

    public void FadetoBlack (int levelState)
    {
        
    }

    public void triggerFade()
    {
        if (GameManager.gameOverAnimation)
        {
            startPlaying = true;
            GameManager.gameOverAnimation = false;
            animator.SetTrigger("fadeOut");
            
        }
                //startPlaying = true;
                //thisSource.PlayOneShot(scottPhone, 0.7f);
    }
}
