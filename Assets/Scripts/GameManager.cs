using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    [Header("Class Variables")]
    public static GameManager instance_class;
    public bool gameActive_b;
    private GameEventSystem p_eventSystem_class;

    private double p_money_d;
    private int p_score_i;

    [Header("Task Variables")]
    public GameObject[] gameTasks_go_arr;
    public ITask[] gameTask_class_arr;

#region Get Set Variables

    public double Money_d
    {
        get { return p_money_d; }
        set { p_money_d = value;}
    }
#endregion

#region Unity Functions

    private void Start()
    {
        instance_class = this;
        p_eventSystem_class = gameObject.GetComponent<GameEventSystem>();
        gameTask_class_arr = FindObjectsOfType<MonoBehaviour>().OfType<ITask>().ToArray();
    }

    private void Update()
    {

    }
#endregion

    IEnumerator GameProcess()
    {

        while(gameActive_b)
        {
            if(!GameEventSystem.eventActive_b)
            {
                p_eventSystem_class.InvokeRandomEvent();
            }

            int ranInt_i = Random.Range(0, gameTask_class_arr.Length - 1);
            gameTask_class_arr[ranInt_i].ActivateTask();
            Debug.Log("Task Num Activated: " + ranInt_i);

            yield return new WaitForSeconds(30);
        }
    }
}
