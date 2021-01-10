using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EmptyTrashTask : ObjectType, ITask
{
    [Header("General Variables")]
    public bool taskActive_b;
    private float p_trahbagPositionYStart_f;
    private Vector3 p_trashbagStartScale_v3;

    [Header("Trashbag Variables")]
    public GameObject trashbag_go;
    
    private void Awake()
    {
        p_trahbagPositionYStart_f = trashbag_go.transform.position.y;
        p_trashbagStartScale_v3 = trashbag_go.transform.localScale;
    }

    public void ActivateTask()
    {
        trashbag_go.transform.LeanMoveY(p_trahbagPositionYStart_f, 0).setOnStart(() => trashbag_go.SetActive(true));
        LeanTween.scaleY(trashbag_go, p_trashbagStartScale_v3.y, 0.15f);

        taskActive_b = true;
    }

    public void InteractTask()
    {
        if(taskActive_b){
            LeanTween.moveY(trashbag_go, p_trahbagPositionYStart_f + 0.4f, 0.2f).setOnComplete(() => trashbag_go.SetActive(false));
            LeanTween.scale(trashbag_go, new Vector3( p_trashbagStartScale_v3.x - 0.1f, p_trashbagStartScale_v3.y + 0.2f, p_trashbagStartScale_v3.z - 0.1f), 0.10f);

            CompleteTask();
        }
    }

    public void CompleteTask()
    {
        taskActive_b = false;
        PlayerScoreSystem.instance_class.scoreIncrease(10);   
    }
}
