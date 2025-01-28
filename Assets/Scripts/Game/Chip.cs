using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chip : MonoBehaviour, IMoveable
{
    BetArea betArea = null;

    public void MoveStart()
    {
       
    }
    public void Move(Vector3 pos)
    {
        transform.position = pos;
        SetBetArea(pos);
        betArea?.Hover();
    }

    public void MoveEnd(Vector3 pos)
    {
        SetBetArea(pos);

        if(betArea != null)
        {
            transform.position = betArea.transform.position.With(z: 0f);
            TableHighlighter.Instance.OnObjectExit();
        }
        else
        {

        }
    }


    private void SetBetArea(Vector3 pos)
    {
        RaycastHit hit;

        if (Physics.Raycast(pos, Vector3.forward, out hit, 100f))
        {
            this.betArea = hit.collider.gameObject.GetComponent<BetArea>();
        }
    }
}
