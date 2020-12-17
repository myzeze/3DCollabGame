using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EquipmentObject : ObjectType, IEquipment
{
    public void StartEquipment()
    {
        Debug.Log("Starting Equipment Stuff");
    }
}
