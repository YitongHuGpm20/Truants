using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MusicPlayer : MonoBehaviour
{
    int musicActual = 0;
    AudioSource audioSource;
    public AudioClip[] clipNames;
    public Text musicName;
    public Slider musicLength;
    public Slider volumeAudio;
    private bool stop = false;
    private bool pause = false;
    public Sprite[] sprites;
    public Button play;
    float audioVolume = 1.0f;
    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        StartAudio();
    }

    // Update is called once per frame
    void Update()
    {
        
        if (!stop)
        {
            audioSource.volume = volumeAudio.value;
            musicLength.value = audioSource.time / audioSource.clip.length;
           // musicLength.value += Time.deltaTime;
            if(musicLength.value >= audioSource.clip.length)
            {
                musicActual++;
                if(musicActual >= clipNames.Length)
                {
                    musicActual = 0;
                }
                StartAudio();
            }
        }
    }

    public void StartAudio(int changeMusic = 0)
    {
        musicActual += changeMusic;
        if(musicActual >= clipNames.Length)
        {
            musicActual = 0;
        }

        else if(musicActual < 0)
        {
            musicActual = clipNames.Length - 1;
        }

        if(audioSource.isPlaying && changeMusic == 0)
        {
            return;
        }

        if (stop)
        {
            stop = false;
        }

        audioSource.clip = clipNames[musicActual];
        musicName.text = audioSource.clip.name;
        musicLength.maxValue = audioSource.clip.length;
        musicLength.value = 0;
        audioSource.Play();

    }

    public void RestartMusic()
    {
        audioSource.Stop();
        stop = true;
        StartAudio(0);
    }

    public void pauseMusic()
    {
        pause = !pause;

        if (pause)
        {
            if (audioSource != null)
            {
                audioSource.Pause();
                play.image.sprite = sprites[1];
            }
                

        }

        if (!pause)
        {
            if (audioSource != null)
            {
                audioSource.Play();
                play.image.sprite = sprites[0];
            }
            }
    }

    public void ChangeAudioTime()
    {
        audioSource.time = audioSource.clip.length * musicLength.value;
    }

    public void SetVolume(float vol)
    {
        audioVolume = vol;
    }
}
