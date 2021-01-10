using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CleanUpTask : ObjectType, ITask 
{   
    [Header("General Variables")]
    public bool taskActive_b;
    public GameObject[] cleanableObjects_arr;

    public void InteractTask()
    {
        Debug.Log("Initiating Task: Clean-Up");
    }

    public void ActivateTask()
    {
        foreach (GameObject cleanableObject in cleanableObjects_arr)
        {
            cleanableObject.SetActive(true);
        }
    }

    public void CompleteTask()
    {
        foreach (GameObject cleanableObject in cleanableObjects_arr)
        {
            cleanableObject.SetActive(false);
        }
    }
}
