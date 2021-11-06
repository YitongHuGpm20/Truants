using UnityEngine;

//Created in 11/10/2019 by Zijie Zhang
//---<Purpose>---
//The purpose of this script is to create a fade in/out effect so that players know where to click apparently.
//---</Purpose>---

//---<LOGS>---
//11/10/2019
//Added test

//01/09/2019
//This script is not in used
//---</LOGS>---

//---<Bugs or Questions in Mind>---
//---</Bugs or Questions in Mind>---
//behaviour which should lie on the same gameobject as the main camera
public class PostprocessingBlur : MonoBehaviour
{
    //material that's applied when doing postprocessing
    [SerializeField]
    private Material postprocessMaterial;

    //method which is automatically called by unity after the camera is done rendering
    void OnRenderImage(RenderTexture source, RenderTexture destination)
    {
        //draws the pixels from the source texture to the destination texture
        var temporaryTexture = RenderTexture.GetTemporary(source.width, source.height);
        Graphics.Blit(source, temporaryTexture, postprocessMaterial, 0);
        Graphics.Blit(temporaryTexture, destination, postprocessMaterial, 1);
        RenderTexture.ReleaseTemporary(temporaryTexture);
    }
}
