using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardSwipeTask : ObjectType, ITask
{
    [Header("General Variables")]
    public bool taskActive_b;
    
    private Vector3 keycardScaleAnimationSize_v3 = new Vector3(1.2f, 2.2f, 0.16f);

    [Header("GameObject Variables")]
    public GameObject keycardSlotCover_go;
    public GameObject keycard_go;

    private void Awake()
    {
        ActivateTask();
    }

    public void ActivateTask()
    {
        taskActive_b = true;
    }    

    public void InteractTask()
    {   
        if(taskActive_b)
        {   
            LeanTween.rotateAroundLocal(keycardSlotCover_go, Vector3.right, -190.0f, 2f)
                .setOnStart( () => LeanTween.scale(keycard_go, keycardScaleAnimationSize_v3, 0.3f))
                .setOnComplete( () => LeanTween.moveLocalZ(keycard_go, 0.15f, 0.5f));

            Debug.Log("LINE BEFORE RAN");
            CompleteTask();
        }
    }

    public void CompleteTask()
    {
        taskActive_b = false;

        LeanTween.moveLocalZ(keycard_go, 0.4f, 0.3f).setDelay(1f).setOnComplete(() => LeanTween.rotateAround(keycardSlotCover_go, Vector3.right, 0.0f, 0.3f));   
    }
}
