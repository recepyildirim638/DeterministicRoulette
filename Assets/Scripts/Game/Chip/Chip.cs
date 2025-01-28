using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chip : MonoBehaviour, IMoveable
{
    [SerializeField] int value;
    BetArea betArea = null;
    public POOL_TYPE poolType;
    public int GetValue() => value;

    public void MoveStart()
    {
        ChipManager.Instance.CollectChip(poolType);
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
           
        }
        else
        {
            StartCoroutine(BackChipArea());
        }

        TableHighlighter.Instance.OnObjectExit();
    }

    IEnumerator BackChipArea()
    {
        yield return null;
        Vector3 targetPos = ChipManager.Instance.GetChipSlotPos((int)poolType);
        Vector3 direction = targetPos - transform.position;

        while( direction.sqrMagnitude > 0.2f )
        {
            direction = targetPos - transform.position;
            transform.position += direction * Time.deltaTime * 6f;
            yield return null;
        }
        transform.position = targetPos;
        gameObject.SetActive(false);
    }


    private void SetBetArea(Vector3 pos)
    {
        RaycastHit hit;

        if (Physics.Raycast(pos, Vector3.forward, out hit, 100f))
        {
            this.betArea = hit.collider.gameObject.GetComponent<BetArea>();
            return;
        }
        this.betArea = null;
    }
}
