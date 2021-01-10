using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FixElectricTask : ObjectType, ITask
{
    [Header("General Variables")]
    public bool taskActive_b;

    [Header("GameObject Variables")]
    public GameObject electricalBoxBroken_go;
    public GameObject electricalBoxFixed_go;

    private ParticleSystem p_electricEffect_ps;

    private void Awake()
    {
        p_electricEffect_ps = electricalBoxBroken_go.GetComponentInChildren<ParticleSystem>();
        ActivateTask();
    }

    public void ActivateTask()
    {
        electricalBoxFixed_go.SetActive(false);

        electricalBoxBroken_go.SetActive(true);
        p_electricEffect_ps.Play();
    }

    public void InteractTask()
    {
        if(taskActive_b)
        {
            CompleteTask();
        }   
    }

    public void CompleteTask()
    {        
        electricalBoxBroken_go.SetActive(false);
        electricalBoxFixed_go.SetActive(true);
        p_electricEffect_ps.Stop();
        PlayerScoreSystem.instance_class.scoreIncrease(10);
    }
}
