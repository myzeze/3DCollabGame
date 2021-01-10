using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CleanUpTask : ObjectType, ITask 
{   
    [Header("General Variables")]
    public bool taskActive_b;

    [Header("GameObject Variables")]
    public GameObject[] cleanableObjects_arr;

    private void Awake()
    {
        ActivateTask();
    }

    public void ActivateTask()
    {
        taskActive_b = true;
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
            LeanTween.moveY(cleanableObject, cleanableObject.transform.position.y + 0.5f, Random.Range(0.1f, 0.5f)).setOnComplete(() => cleanableObject.SetActive(false));
        }
        taskActive_b = false;
        Debug.Log("Finished Clean-Up Task");    // --- REMOVE
    }
}
