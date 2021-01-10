using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
*   Created: 18/11/2020, By Finn Dudley
*   Last Edited: 21/11/2020, By Finn Dudley
*/


public enum ObjectTypes
{
    Task,
    Item,
    Equipment
}


public class ObjectType : MonoBehaviour
{
    [Header("Object Type")]
    public ObjectTypes selectedObjectType_e;
    public ShipLocations selectedLocationInShip_class;

    public ShipLocations GetLocation()
    {
        return selectedLocationInShip_class;
    }
}
