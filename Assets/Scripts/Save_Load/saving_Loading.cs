using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.IO;

//Created in 09/26/2019 by Zijie Zhang
//---<LOGS>---

//09/26/2019
//Creating a simple save/load system, but not finished yet;

//09/27/2019
//createed a simple save function where save information in json files and tested, the load functions need to hold on to see what game objects in the game need save/load

//09/28/2019
//created base class for saving files, added comments in it
//---</LOGS>---

//---<Bugs or Questions in Mind>---
//1.Multiple saving datas
//2.corrupted saving datas
//3.If saved files not existed
//4.saving and laoding path
//---</Bugs or Questions in Mind>---

public class saving_Loading : MonoBehaviour
{
    public static saving_Datas saved_Datas; //things that need to save
    private void Start()
    {
        DontDestroyOnLoad(this);
        saved_Datas = new saving_Datas(); //create new save data
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.F1))
        {
            Debug.Log("start saving");
            saved_Datas.save_CurrentData();
        }

        if (Input.GetKeyDown(KeyCode.F2))
        {
            Debug.Log("start loading");
            saved_Datas.load_CurrentData();
        } //F1 and F3 to save and load
    }


    [System.Serializable] //serilizable class
    public class base_Save
    {
        public Vector3 location; //where is this object in the scene
        public int chapter; //which chapter is this object in
        public string name; //this object's name
    } //base class for saving files;

    [System.Serializable]
    public class saving_Datas
    {
        public List<base_Save> saved_Objects = new List<base_Save>(); //list of saved objects in the data

        public saving_Datas create_Savingdatas()
        {
            saving_Datas new_saving_Datas = new saving_Datas();//create a new saving data for returning
            GameObject[] objects = GameObject.FindGameObjectsWithTag("saves");//WARNINNG, might change to hierrachy later
            for (int i = 0; i < objects.Length; i++)
            {
                base_Save temp = new base_Save();
                temp.chapter = 1;
                temp.location = objects[i].transform.position;
                temp.name = objects[i].name;
                Debug.Log(temp.name);
                new_saving_Datas.saved_Objects.Add(temp); //save all game objects later
            }
            return new_saving_Datas; 
        }
        public void save_CurrentData()
        {
            saved_Datas = create_Savingdatas(); //create a save data
            string json_Data = JsonUtility.ToJson(saved_Datas, true); 
            File.WriteAllText(Application.dataPath + "/save1.json", json_Data); //convert and write them to json
        }

        public void load_CurrentData()
        {
            string json_String = File.ReadAllText(Application.dataPath + "/save1.json");
            saving_Datas temp = JsonUtility.FromJson<saving_Datas>(json_String); //load json file
        }
    }

}