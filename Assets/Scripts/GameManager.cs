using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    [Header("Class Variables")]
    public static GameManager instance_class;
    private GameEventSystem eventSystem_class;

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
        instance_class = this;
        eventSystem_class = gameObject.GetComponent<GameEventSystem>();
    }

    private void Update()
    {

    }
#endregion

    IEnumerator GameProcess()
    {
        yield return new WaitForSeconds(1);

        if(!GameEventSystem.eventActive_b)
        {
            eventSystem_class.InvokeRandomEvent();
        }
    }

    public void AddMoney(double _moneyToAdd_d)
    {
        Money_d += _moneyToAdd_d;
    }

    public void AddScore(int _scoreToAdd_i)
    {
        Score_i += _scoreToAdd_i;
    }
}
