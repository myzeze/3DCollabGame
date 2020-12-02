using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
*   Created: 18/11/2020, By Finn Dudley
*   Last Edited: 21/11/2020, By Finn Dudley
*/

public class EventSystem : MonoBehaviour
{
    [Header("Event Variables")]
    public static bool eventActive_b = false;

    // Event Types - most likely require delegates
    public static event System.Action LightsOut;
    public static event System.Action OxygenOff;
    public static event System.Action SpawnEnemyShip; 
    public static event System.Action SpawnFriendlyShip; // Trader Ship.
    public static event System.Action SpawnSpaceMonster;    
    public static event System.Action SpawnAsteriodField;
    public static event System.Action StartEMPBlast; // Could just invoke Lights and Oxygen Off.

    /// <summary>
    /// Invokes a random game event.
    ///</summary>
    public void InvokeRandomEvent(){
        if (!eventActive_b)
        {
            int ranNum = Random.Range(0, 7);
            switch (ranNum)
            {
                case 0: // Lights Out Event
                    LightsOut?.Invoke();
                    Debug.Log("Lights Out Event Occured");
                    break;

                case 1: // Oxygen Out Event
                    OxygenOff?.Invoke();
                    Debug.Log("Oxygen Out Event Occured");
                    break;

                case 2: // Spawn Enemy Ship.
                    SpawnEnemyShip?.Invoke();
                    Debug.Log("Enemy Ship Event Occured");
                    break;

                case 4: // Spawn Friendly Ship
                    SpawnFriendlyShip?.Invoke();
                    Debug.Log("Friendly Ship Event Occured");
                    break;

                case 5: // Spawn Space Monster
                    SpawnSpaceMonster?.Invoke();
                    Debug.Log("Space Monster Event Occured");
                    break;

                case 6: // Spawn Asteriod Field
                    SpawnAsteriodField?.Invoke();
                    Debug.Log("Asteriod Field Event Occured");
                    break;

                case 7: // EMP Blast
                    StartEMPBlast?.Invoke();
                    Debug.Log("EMP Blast Event Occured");
                    break;
                default:
                    break;
            }
            eventActive_b = true;
        }
        else Debug.Log("Event Currently Active");
        
    }
}
