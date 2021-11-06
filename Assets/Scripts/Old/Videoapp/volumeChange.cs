using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;

public class volumeChange : MonoBehaviour
{
    [SerializeField]
    private AudioSource videoPlayer;
    //private float musicVolume = 1.0f;
    Slider audiovolume;
    // Start is called before the first frame update
    void Start()
    {
        videoPlayer = GameObject.Find("videoplayer1").GetComponent<AudioSource>();
        audiovolume = GetComponent<Slider>();
    }

    // Update is called once per frame
    void Update()
    {
       // videoPlayer.volume = musicVolume;
    }

    public void SetVolume()
    {
        videoPlayer.volume = audiovolume.value;
    }
}
