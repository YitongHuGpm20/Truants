using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class videoClick : MonoBehaviour
{
    public GameObject video;
    public GameObject videoline;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void clickVideo()
    {
        video.SetActive(true);
        videoline.SetActive(true);
    }
}
