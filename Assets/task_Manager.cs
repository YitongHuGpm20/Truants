using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using UnityEngine.UI;
public class task_Manager : MonoBehaviour
{
    [SerializeField]
    public static List<task_Property> task_List;
    public static Button to_DoButton;
    public static Button finished_Button;

    private GameObject task_Prefab;
    public static GameObject task_obj;
    

    private void Awake()
    {
        task_List = new List<task_Property>();
        to_DoButton = this.transform.Find("To-Do").gameObject.GetComponent<Button>();
        finished_Button = this.transform.Find("Done").gameObject.GetComponent<Button>();
        task_Prefab = Resources.Load("task_Prefab") as GameObject;
        task_obj = this.gameObject;
    }

    public static void add_Task(task_Property new_Task)
    {
        GoodPoint_Manager.goodpoint.GetComponent<GoodPoint_Manager>().tasks_Onclick();
        task_Property target = task_List.FirstOrDefault(n => n.task_ID == new_Task.task_ID);
        if (target == null)
            task_List.Add(new_Task);
        else
            return;
        to_DoButton.onClick.Invoke();
        Destroy(new_Task);

    }

    public void try_FinishTask(int task_ID)
    {
        GoodPoint_Manager.goodpoint.GetComponent<GoodPoint_Manager>().tasks_Onclick();
        if (task_List.Any(n => n.task_ID == task_ID))
        {
            task_List.Find(n => n.task_ID == task_ID).reference_Obj.GetComponent<task_Property>().try_Finishtask_Task();
        }
    }

    public void onclick_Todo()
    {
        if (task_List.Count <= 0) return;
        task_List = task_List.OrderBy(n => n.is_Finished ? 1 : 0).ToList();
        foreach (task_Property temp in task_List)
        {
            Debug.Log(temp.is_Finished);
        }
        foreach (task_Property temp in task_List)
        {
           
            if(temp.reference_Obj)
                Destroy(temp.reference_Obj);
            if (!temp.is_Finished)
            {
                GameObject obj = Instantiate(task_Prefab, GoodPoint_Manager.Keyword_Area.transform);
                temp.reference_Obj = obj;
                task_Property new_Property = obj.GetComponent<task_Property>();
                //new_Property = temp;
                new_Property.is_Finished = temp.is_Finished;
                new_Property.reference_Obj = temp.reference_Obj;
                new_Property.task_Description = temp.task_Description;
                new_Property.task_ID = temp.task_ID;
                new_Property.finished_Counter = temp.finished_Counter;
                new_Property.mission_Counter = temp.mission_Counter;
                obj.transform.Find("task").Find("goal").GetComponent<Text>().text = temp.task_Description;
                obj.GetComponent<task_Property>().check_Status();
            }
        }
    }

    public void onclick_Finished()
    {
        if (task_List.Count <= 0) return;
        task_List = task_List.OrderBy(n => n.is_Finished ? 0 : 1).ThenBy(n=>n.task_ID).ToList();
        foreach (task_Property temp in task_List)
        {
            Debug.Log(temp.is_Finished);
        }
        foreach (task_Property temp in task_List)
        {
            if (temp.reference_Obj)
                Destroy(temp.reference_Obj);
            if (temp.is_Finished && GoodPoint_Manager.Keyword_Area.transform.childCount<=6)
            {
                GameObject obj = Instantiate(task_Prefab, GoodPoint_Manager.Keyword_Area.transform);
                temp.reference_Obj = obj;
                task_Property new_Property = obj.GetComponent<task_Property>();
                //new_Property = temp;
                new_Property.is_Finished = temp.is_Finished;
                new_Property.reference_Obj = temp.reference_Obj;
                new_Property.task_Description = temp.task_Description;
                new_Property.task_ID = temp.task_ID;
                new_Property.finished_Counter = temp.finished_Counter;
                new_Property.mission_Counter = temp.mission_Counter;
                obj.transform.Find("task").Find("goal").GetComponent<Text>().text = temp.task_Description;
                obj.GetComponent<task_Property>().check_Status();
            }
        }
    }
   

    private void distribute_TaskProperty(task_Property input)
    {

    }

}
