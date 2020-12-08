using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [Header("Class Variables")]
    public EventSystem eventSystem_class;

    private double p_money_d;
    private int p_score_i;

#region Get Set Variables

    public double Money_d
    {
        get { return p_money_d; }
        set { p_money_d = value;}
    }
    public int Score_i
    {
        get { return p_score_i; }
        set { p_score_i = value; }
    }
#endregion

#region Unity Functions

    private void Start()
    {
        eventSystem_class = GetComponent<EventSystem>();
    }

    private void Update()
    {

    }
#endregion

    IEnumerator GameProcess()
    {
        yield return new WaitForSeconds(1);

        if(!EventSystem.eventActive_b)
        {
            eventSystem_class.InvokeRandomEvent();
        }
    }
}
