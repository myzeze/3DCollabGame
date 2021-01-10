using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FixElectricTask : ObjectType, ITask
{
    [Header("General Variables")]
    public bool taskActive_b;
    private int p_taskPriority_i;

    [Header("GameObject Variables")]
    public GameObject electricalBoxBroken_go;
    public GameObject electricalBoxFixed_go;

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
       electricalBoxBroken_go.SetActive(true);
       electricalBoxFixed_go.SetActive(false);
    }

    public void InteractTask()
    {
        electricalBoxBroken_go.SetActive(false);
        electricalBoxFixed_go.SetActive(true);
        CompleteTask();
    }

    public void CompleteTask()
    {
        Debug.Log("Electrical Task Finished");      // --- REMOVE
    }
}
