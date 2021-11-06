using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class conv5StartScript : MonoBehaviour
{
    bool file1 = false;
    bool file2 = false;
    bool file3 = false;
    bool file4 = false;
    int voCount = 0;
   
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       ;
        if (file1 && file2 && file3 && file4)
        {
            task_Manager.task_obj.GetComponent<task_Manager>().try_FinishTask(13);
            this.GetComponent<task_Property>().add_Task();
            GameManager.sd5 = true;
            voCount++;
            if (voCount == 1)
            {
                SettingsManager.instance.PlaySFX2D(SettingsManager.instance.sfxClips[21]);
            }
            file1 = false;
            file2 = false;
            file3 = false;
            file4 = false;
        }
    }

    public void openfile1()
    {
        
        file1 = true;
    }

    public void openfile2()
    {
        file2 = true;
    }

    public void openfile3()
    {
        file3 = true;
    }

    public void openfile4()
    {
        file4 = true;
    }
}
