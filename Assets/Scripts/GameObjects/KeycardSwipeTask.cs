using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeycardSwipeTask : ObjectType, ITask
{
    [Header("General Variables")]
    public bool taskActive_b;
    
    private Vector3 keycardScaleAnimationSize_v3 = new Vector3(0.95f, 2f, 0.1f);

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
        LeanTween.rotateAroundLocal(keycardSlotCover_go, Vector3.down, 0.0f, 0.4f);
    }    

    public void InteractTask()
    {   
        if(taskActive_b)
        {   
            LeanTween.rotateAroundLocal(keycardSlotCover_go, Vector3.down, -190.0f, 1.5f)
                .setOnStart( () => LeanTween.scale(keycard_go, keycardScaleAnimationSize_v3, 0.3f).setDelay(0.5f))
                .setOnComplete( () =>  LeanTween.moveLocalZ(keycard_go, 0.15f, 0.4f ).setOnComplete(CompleteTask))
                .setEaseOutBounce();
        }
    }

    public void CompleteTask()
    {
        taskActive_b = false;

        LeanTween.moveLocalZ(keycard_go, 0.4f, 0.3f).setOnStart(() => LeanTween.scale(keycard_go, new Vector3(0, 0, 0), 0.3f));
    }
}
