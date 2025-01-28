using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChipSlot : MonoBehaviour
{
    public int value;

    public POOL_TYPE poolType;
    public Vector3 GetPosition() => transform.position;
}
