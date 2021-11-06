using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.EventSystems;

/// <summary>
/// This script handles sound management and other settings
/// </summary>

public class SettingsManager : MonoBehaviour
{
    public static SettingsManager instance; // instance for singleton

    [Header("Sound Management")]
    public AudioClip[] bgmClips; 
    public AudioClip[] sfxClips;
    public List<AudioSource> current_PlayingSFX = new List<AudioSource>();
    public AudioSource current_PlayingBGM;
    public AudioClip[] keyPress;
    public float sfxVolume = 1;
    public float bgmVolume = 0.3f;
    public delegate void SFXStarted(AudioSource snd);
    public static event SFXStarted OnSFXStarted;
    public delegate void SFXFinished(AudioSource snd);
    public static event SFXFinished OnSFXFinished;
    public GameObject musicPlayer;
    public GameObject lsMenu;
    public GameObject[] SFXButton;
    public GameObject[] BGMButton;
    public GameObject[] SFXSlider;
    public GameObject[] BGMSlider;
    public Sprite SFXOnIcon;
    public Sprite SFXOffIcon;
    public Sprite BGMOnIcon;
    public Sprite BGMOffIcon;
    bool lsMenuOn;
    bool SFXOn;
    bool BGMOn;
    public bool fadeOutDone;

    float preSFXVolume;
    float preBGMVolume;

    [Header("Typing Effect")]
    public Text[] teOption;

    private void Update()
    {
        SetSFXVolume(sfxVolume);
        SetBGMVolume(bgmVolume);
    }

    public void play_Random_KeyPress()
    {
        PlaySFX2D(SettingsManager.instance.keyPress[Random.Range(0, 9)]); //play random keypress for keyboard typing
    }

    private void Awake()
    {
        if (instance == null)
            instance = this;
        else if (instance != this)
            Destroy(this.gameObject);
        DontDestroyOnLoad(this.gameObject); //for singleton
        
        PlayBGM(SettingsManager.instance.bgmClips[0]); //start bgm
        SetBGMVolume(0.3f); //set volume

        lsMenuOn = false;
        SFXOn = true;
        BGMOn = true;
        fadeOutDone = false;
        preSFXVolume = sfxVolume;
        preBGMVolume = bgmVolume;
        for(int i = 0; i < 3; ++i)
        {
            SFXSlider[i].GetComponent<Slider>().value = sfxVolume;
            BGMSlider[i].GetComponent<Slider>().value = bgmVolume;
        }
    }

    public void SetSFXVolume(float volume)
    {
        this.sfxVolume = volume;
        if (current_PlayingSFX.Count > 0)
        {
            //foreach (AudioSource playingSFX in current_PlayingSFX)
            //    playingSFX.volume = volume;
        } //if there are playing sfx, change their volumes too
    }

    public void playSFXByID(int ID)
    {
        Debug.Log("hello");
        PlaySFX2D(SettingsManager.instance.sfxClips[ID]); //play SFX by array index
        Debug.Log(SettingsManager.instance.sfxClips[ID]);
    }

    public void SetBGMVolume(float volume)
    {
        this.bgmVolume = volume;
        current_PlayingBGM.volume = volume; //set bgm volume
    }

    public void PlayBGM(AudioClip bgmClip, bool looping = true, float pitch = 1.0f, float pan = 0.0f)
    {
        Destroy(current_PlayingBGM);
        AudioSource newBGM = this.gameObject.AddComponent<AudioSource>();
        if (bgmClip != null)
            newBGM.clip = bgmClip;
        newBGM.loop = looping;
        newBGM.pitch = pitch;
        newBGM.panStereo = pan;
        newBGM.Play();
        current_PlayingBGM = newBGM; 
        //TODO: fade in fade out effect
    } //function for playing BGM by parameter

    public void PlayBGM()
    {
        if (current_PlayingBGM != null && !current_PlayingBGM.isPlaying)
            current_PlayingBGM.Play();
    } //function for playing BGM without parameter

    public void PlaySFX2D(AudioClip sfxClip, bool looping = false, float pitch = 1.0f, float pan = 0.0f)
    {
        AudioSource newSFX = this.gameObject.AddComponent<AudioSource>();

        newSFX.clip = sfxClip;
        newSFX.loop = looping;
        newSFX.pitch = pitch;
        newSFX.panStereo = pan;
        newSFX.Play();
        current_PlayingSFX.Add(newSFX);
        if (OnSFXStarted != null)
            OnSFXStarted(newSFX);
        StartCoroutine(destroy_Audiosource(newSFX));
        //add to current play sfx
    } //function for playing SFX in 2D by parameter

    public void PlaySFX3D(Vector3 position, AudioClip sfx)
    {
        GameObject audioObj = new GameObject();
        audioObj.transform.position = position;
        audioObj.AddComponent<AudioSource>();
        audioObj.GetComponent<AudioSource>().clip = sfx;
        audioObj.GetComponent<AudioSource>().loop = false;
        audioObj.GetComponent<AudioSource>().Play();
        current_PlayingSFX.Add(audioObj.GetComponent<AudioSource>());
        if (OnSFXStarted != null)
            OnSFXStarted(audioObj.GetComponent<AudioSource>());
        StartCoroutine(destroy_Audiosource(audioObj.GetComponent<AudioSource>()));
    } //function for playing SFX in 3D

    public void PlaySFX3D(Vector3 position, AudioClip sfx, bool looping = false, float pitch = 1.0f, float pan = 0.0f)
    {
        GameObject audioObj = new GameObject();
        audioObj.transform.position = position;
        audioObj.AddComponent<AudioSource>();
        audioObj.GetComponent<AudioSource>().pitch = pitch;
        audioObj.GetComponent<AudioSource>().panStereo = pan;
        audioObj.GetComponent<AudioSource>().clip = sfx;
        audioObj.GetComponent<AudioSource>().loop = looping;
        audioObj.GetComponent<AudioSource>().Play();
        current_PlayingSFX.Add(audioObj.GetComponent<AudioSource>());
        if (OnSFXStarted != null)
            OnSFXStarted(audioObj.GetComponent<AudioSource>());
        StartCoroutine(destroy_Audiosource(audioObj.GetComponent<AudioSource>()));
    }//function for playing SFX in 3D

    public void PauseBGM()
    {
        if (current_PlayingBGM != null)
            current_PlayingBGM.Pause();
    } //pause the BGM that is currently playing

    public void StopBGM()
    {
        if (current_PlayingBGM != null)
            current_PlayingBGM.Stop();
    } //Stop the BGM

    IEnumerator destroy_Audiosource(AudioSource this_Source)
    {
        if (this_Source.isPlaying)
        {
            yield return new WaitForSeconds(this_Source.clip.length);
        }
        if (OnSFXFinished != null)
            OnSFXFinished(this_Source);
        current_PlayingSFX.Remove(this_Source);
        Destroy(this_Source);
        yield return null;
    } //Destroy the audiosource after it finished.

    public static class AudioController
    {
        public static IEnumerator FadeOut(AudioSource BGM, float FadeTime)
        {
            float startVolume = BGM.volume;
            while (BGM.volume > 0)
            {
                BGM.volume -= startVolume * Time.deltaTime / FadeTime;
                Debug.Log(BGM.volume);
                yield return null;
            }

            BGM.Stop();
            SettingsManager.instance.fadeOutDone = true;
        }

        public static IEnumerator FadeIn(AudioSource BGM, float FadeTime)
        {
            BGM.Play();
            BGM.volume = 0f;
            while (BGM.volume < SettingsManager.instance.bgmVolume)
            {
                BGM.volume += Time.deltaTime / FadeTime;
                yield return null;
            }
        }
    }

    public void ToggleSettingsMenu_LoginScreen()
    {
        if (lsMenuOn)
        {
            lsMenu.SetActive(false);
            lsMenuOn = false;
        }
        else
        {
            lsMenu.SetActive(true);
            lsMenuOn = true;
        }   
    }  //Toggle the setting menu in LoginScreen

    public void ToggleSFX()
    {
        if (SFXOn)
        {
            SFXOn = false;
            preSFXVolume = sfxVolume;
            for (int i = 0; i < 3; ++i)
            {
                SFXButton[i].GetComponent<Image>().sprite = SFXOffIcon;
                SFXSlider[i].GetComponent<Slider>().value = 0;
            }
        }
        else
        {
            SFXOn = true;
            sfxVolume = preSFXVolume;
            for (int i = 0; i < 3; ++i)
            {
                SFXButton[i].GetComponent<Image>().sprite = SFXOnIcon;
                SFXSlider[i].GetComponent<Slider>().value = preSFXVolume;
            }
        }
    }

    public void ToggleBGM()
    {
        if (BGMOn)
        {
            BGMOn = false;
            preBGMVolume = bgmVolume;
            for (int i = 0; i < 3; ++i)
            {
                BGMButton[i].GetComponent<Image>().sprite = BGMOffIcon;
                BGMSlider[i].GetComponent<Slider>().value = 0;
            }
        }
        else
        {
            BGMOn = true;
            bgmVolume = preBGMVolume;
            for (int i = 0; i < 3; ++i)
            {
                BGMButton[i].GetComponent<Image>().sprite = BGMOnIcon;
                BGMSlider[i].GetComponent<Slider>().value = preBGMVolume;
            }
        }
    }

    public void SFXslider(Slider thisSlider)
    {
        float sfx = thisSlider.GetComponent<Slider>().value;
        sfxVolume = sfx;
        if (SFXOn && sfx == 0)
        {
            SFXOn = false;
            for (int i = 0; i < 3; ++i)
                SFXButton[i].GetComponent<Image>().sprite = SFXOffIcon;
            preSFXVolume = 0.1f;
        }
        else if (!SFXOn && sfx > 0)
        {
            SFXOn = true;
            for (int i = 0; i < 3; ++i)
                SFXButton[i].GetComponent<Image>().sprite = SFXOnIcon;
        }
        for (int i = 0; i < 3; ++i)
            SFXSlider[i].GetComponent<Slider>().value = sfxVolume;
    }

    public void BGMslider(Slider thisSlider)
    {
        float bgm = thisSlider.GetComponent<Slider>().value;
        bgmVolume = bgm;
        if(BGMOn && bgm == 0)
        {
            BGMOn = false;
            for (int i = 0; i < 3; ++i)
                BGMButton[i].GetComponent<Image>().sprite = BGMOffIcon;
            preBGMVolume = 0.1f;
        }
        else if(!BGMOn && bgm > 0)
        {
            BGMOn = true;
            for (int i = 0; i < 3; ++i)
                BGMButton[i].GetComponent<Image>().sprite = BGMOnIcon;
        }
        for (int i = 0; i < 3; ++i)
            BGMSlider[i].GetComponent<Slider>().value = bgmVolume;
    }

    public void ToggleTypingEffect()
    {
        if (GameManager.typingEffectOn)
        {
            GameManager.typingEffectOn = false;
            teOption[0].text = "Off";
            teOption[1].text = "Off";
        }
        else
        {
            GameManager.typingEffectOn = true;
            teOption[0].text = "On";
            teOption[1].text = "On";
        }
    }

    private void FixedUpdate()
    {
        if (musicPlayer.activeInHierarchy && musicPlayer.GetComponent<AudioSource>().isPlaying)
            PauseBGM();

        if (!musicPlayer.activeInHierarchy)
            PlayBGM();
    }
}

