using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IMoveable 
{
    void MoveStart();
    void Move(Vector3 pos);
    void MoveEnd(Vector3 pos);
}
