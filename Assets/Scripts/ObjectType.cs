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
    public ObjectTypes selectedObjectType_e;
}
