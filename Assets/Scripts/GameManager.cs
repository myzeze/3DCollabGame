using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [Header("Class Variables")]
    public EventSystem eventSystem;

    private double money;
    private int score;

#region Get Set Variables

    public double Money
    {
        get { return money; }
        set { money = value;}
    }
    public int Score
    {
        get { return score; }
        set { score = value; }
    }
#endregion

#region Unity Functions

    private void Start()
    {
        eventSystem = GetComponent<EventSystem>();
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
            eventSystem.InvokeRandomEvent();
        }


    }

}
