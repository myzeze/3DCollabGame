using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CleanUpTask : ObjectType, ITask 
{   
    [Header("General Variables")]
    public bool taskActive_b;
<<<<<<< HEAD
=======
    private int p_taskPriority_i;

    [Header("GameObject Variables")]
>>>>>>> parent of 320ca43... Keycard Half Working
    public GameObject[] cleanableObjects_arr;

    public void InteractTask()
    {
        Debug.Log("Initiating Task: Clean-Up");
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

    public void CompleteTask()
    {
        foreach (GameObject cleanableObject in cleanableObjects_arr)
        {
            cleanableObject.SetActive(false);
        }
<<<<<<< HEAD
    }

    private void OnTriggerEnter(Collider col){
        CompleteTask();
=======
        Debug.Log("Finished Clean-Up Task");    // --- REMOVE
>>>>>>> parent of 320ca43... Keycard Half Working
    }
}
