using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class MoveManager : MonoBehaviour
{
    private Camera _cam;
    private Vector3 _rayDirection = Vector3.forward;

    IMoveable moveObject;

    private void Start()
    {
        _cam = Camera.main;
    }

    private Vector3 GetScreenToWorldPosition()
    {
        return _cam.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, _cam.transform.position.z + 15f));
    }

    private void SetMoveableObject()
    {
        RaycastHit hit;

        Vector3 worldPos = GetScreenToWorldPosition();

        if (Physics.Raycast(worldPos, _rayDirection, out hit, 100f))
        {
            moveObject = hit.collider.gameObject.GetComponent<IMoveable>();
        }
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            SetMoveableObject();

            if (moveObject != null)
                moveObject.MoveStart();
        }

        if (moveObject == null)
            return;

        if (Input.GetMouseButton(0))
        {
            MoveToMoveableObject();
        }

        if (Input.GetMouseButtonUp(0))
        {
            moveObject.MoveEnd(GetScreenToWorldPosition());
            moveObject = null;
        }
    }

    private void MoveToMoveableObject()
    {
        Vector3 worldPos = GetScreenToWorldPosition();
        moveObject.Move(worldPos);
    }
}
