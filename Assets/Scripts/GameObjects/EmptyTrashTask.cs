using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EmptyTrashTask : ObjectType, ITask
{
    [Header("General Variables")]
    public bool taskActive_b;
    private float p_trahbagPositionYStart_f;
    private float p_trashbagRotationXStart_f;
    private int p_taskPriority_i;
    

    [Header("Trashbag Variables")]
    public GameObject trashbag_go;

    private void Awake()
    {
        p_trahbagPositionYStart_f = trashbag_go.transform.position.y;
        p_trashbagRotationXStart_f = transform.rotation.x;
    }

    public int GetPriority()
    {
        return p_taskPriority_i;
    }

    public void ActivateTask()
    {
        trashbag_go.transform.LeanMoveY(p_trahbagPositionYStart_f, 0);
        trashbag_go.transform.LeanRotateX(p_trashbagRotationXStart_f, 0);
        trashbag_go.SetActive(true);
        taskActive_b = true;
    }

    public void InteractTask()
    {
        if(taskActive_b){
            LeanTween.rotateX(trashbag_go, p_trashbagRotationXStart_f + 90f, 0.15f);
            LeanTween.moveY(trashbag_go, trashbag_go.transform.position.y + 0.6f, 0.15f).setOnComplete(() => { trashbag_go.SetActive(false); });
            CompleteTask();
        }
    }

    public void CompleteTask()
    {
        Debug.Log("Task Completed - Empty Trash");
        taskActive_b = false;
    }
}
