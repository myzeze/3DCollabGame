using System.Collections;
using System.Collections.Generic;
using UnityEngine;
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
}