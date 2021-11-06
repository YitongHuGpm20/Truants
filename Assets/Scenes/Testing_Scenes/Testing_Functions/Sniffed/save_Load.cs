using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.IO;

public class save_Load : MonoBehaviour
{
    void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }

    public void SaveScene()
    {
        object[] obj = Object.FindObjectsOfType(typeof(GameObject));
        foreach(object o in obj)
        {
            GameObject temp = (GameObject)o;
            string json_Data = JsonUtility.ToJson(temp);
            File.WriteAllText(Application.dataPath + "/save1.json", json_Data);
        }
    }

    public void LoadScene()
    {
        int activeScene = PlayerPrefs.GetInt("ActiveScene");

        //SceneManager.LoadScene(activeScene);

        //Note: In most cases, to avoid pauses or performance hiccups while loading,
        //you should use the asynchronous version of the LoadScene() command which is: LoadSceneAsync()

        //Loads the Scene asynchronously in the background
        StartCoroutine(LoadNewScene(activeScene));
    }

    public void hello()
    {

    }

    IEnumerator LoadNewScene(int sceneBuildIndex)
    {
        AsyncOperation asyncOperation = SceneManager.LoadSceneAsync(sceneBuildIndex);
        asyncOperation.allowSceneActivation = false;

        while (asyncOperation.progress < 0.9f)
        {
            yield return null;
        }

        asyncOperation.allowSceneActivation = true;

    }
}
