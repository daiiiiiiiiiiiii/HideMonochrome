using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ground : MonoBehaviour,IHitObject
{
    public ObjectType GetObjectType(Collider2D col)
    {
        return ObjectType.Ground;
    }
}
