using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CleanUpTask : ObjectType, ITask 
{   
    [Header("General Variables")]
    public bool taskActive_b;
    private int p_taskPriority_i;

    [Header("GameObject Variables")]
    public GameObject[] cleanableObjects_arr;

    private void Awake()
    {
        ActivateTask();
    }

    public int GetPriority()
    {
        return p_taskPriority_i;
    }

    public void ActivateTask()
    {
        foreach (GameObject cleanableObject in cleanableObjects_arr)
        {
            cleanableObject.SetActive(true);
        }
    }

    public void InteractTask()
    {
        if(taskActive_b)
        {
            Debug.Log("Started Clean-Up Task");     // --- REMOVE
            CompleteTask();            
        }
    }

    public void CompleteTask()
    {
        foreach (GameObject cleanableObject in cleanableObjects_arr)
        {
            cleanableObject.SetActive(false);
        }
        Debug.Log("Finished Clean-Up Task");    // --- REMOVE
    }
}
