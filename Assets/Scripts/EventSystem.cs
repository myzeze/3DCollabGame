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
    public static event System.Action LightsOut_ac;
    public static event System.Action OxygenOff_ac;
    public static event System.Action SpawnEnemyShip_ac; 
    public static event System.Action SpawnFriendlyShip_ac; // Trader Ship.
    public static event System.Action SpawnSpaceMonster_ac;    
    public static event System.Action SpawnAsteriodField_ac;
    public static event System.Action StartEMPBlast_ac; // Could just invoke Lights and Oxygen Off.

    /// <summary>
    /// Invokes a random game event.
    ///</summary>
    public void InvokeRandomEvent()
    {
        if (!eventActive_b)
        {
            int ranNum_i = Random.Range(0, 7);
            switch (ranNum_i)
            {
                case 0: // Lights Out Event
                    LightsOut_ac?.Invoke();
                    Debug.Log("Lights Out Event Occured");
                    break;

                case 1: // Oxygen Out Event
                    OxygenOff_ac?.Invoke();
                    Debug.Log("Oxygen Out Event Occured");
                    break;

                case 2: // Spawn Enemy Ship.
                    SpawnEnemyShip_ac?.Invoke();
                    Debug.Log("Enemy Ship Event Occured");
                    break;

                case 4: // Spawn Friendly Ship
                    SpawnFriendlyShip_ac?.Invoke();
                    Debug.Log("Friendly Ship Event Occured");
                    break;

                case 5: // Spawn Space Monster
                    SpawnSpaceMonster_ac?.Invoke();
                    Debug.Log("Space Monster Event Occured");
                    break;

                case 6: // Spawn Asteriod Field
                    SpawnAsteriodField_ac?.Invoke();
                    Debug.Log("Asteriod Field Event Occured");
                    break;

                case 7: // EMP Blast
                    StartEMPBlast_ac?.Invoke();
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
