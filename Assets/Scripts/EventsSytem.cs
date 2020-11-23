﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
*   Created: 18/11/2020, By Finn Dudley
*   Last Edited: 21/11/2020, By Finn Dudley
*/

public class EventsSytem : MonoBehaviour
{
    public static bool eventActive;

    // Event Types - most likely require delegates
    public static event System.Action LightsOut;
    public static event System.Action OxygenOff;
    public static event System.Action SpawnEnemyShip; 
    public static event System.Action SpawnFriendlyShip; // Trader Ship.
    public static event System.Action SpawnSpaceMonster;    
    public static event System.Action SpawnAsteriodField;
    public static event System.Action StartEMPBlast; // Could just invoke Lights and Oxygen Off.

    /// <summary>
    /// Invokes a random  game event.
    ///</summary>
    public void InvokeRandomEvent(){
        int ranNum = Random.Range(0,7);
        switch (ranNum)
        {
            case 0: // Lights Out Event
                LightsOut?.Invoke();
                break;

            case 1: // Oxygen Out Event
                OxygenOff?.Invoke();
                break;

            case 2: // Spawn Enemy Ship.
                SpawnEnemyShip?.Invoke();
                break;

            case 4: // Spawn Friendly Ship
                SpawnFriendlyShip?.Invoke();
                break;
            
            case 5: // Spawn Space Monster
                SpawnSpaceMonster?.Invoke();
                break;

            case 6: // Spawn Asteriod Field
                SpawnAsteriodField?.Invoke();
                break;

            case 7: // EMP Blast
                StartEMPBlast?.Invoke();
                break;
            default:
                break;
        }
        eventActive = true;
    }
}
