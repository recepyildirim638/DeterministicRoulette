using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chip : MonoBehaviour, IMoveable
{
    [SerializeField] int value;
    public BetArea betArea = null;
    public POOL_TYPE poolType;

    public int GetValue() => value;

    private bool isAdded = false;

    public void MoveStart()
    {
        if (isAdded)
        {
            GameManager.Instance.gameLevel.betManager.RemoveChip(this);
            isAdded = false;
            return;
        }

        GameManager.Instance.gameLevel.chipManager.CollectChip(poolType);
    }
    public void Move(Vector3 pos)
    {
        transform.position = pos;
        SetBetArea(pos);
        betArea?.Hover();
    }

    public void MoveEnd(Vector3 pos)
    {
      //  SetBetArea(pos);

        if(betArea != null)
        {
            isAdded = true;
            transform.position = betArea.transform.position.With(z: 0f);

            GameManager.Instance.gameLevel.betManager.AddChip(this);
            GameManager.Instance.gameLevel.chipManager.ControlSlotMoneyValue();
        }
        else
        {
            StartCoroutine(BackChipArea());
        }

         GameManager.Instance.gameLevel.tableHighlighter.OnObjectExit();
    }

    IEnumerator BackChipArea()
    {
        yield return null;
        Vector3 targetPos = GameManager.Instance.gameLevel.chipManager.GetChipSlotPos((int)poolType);
        Vector3 direction = targetPos - transform.position;

        while( direction.sqrMagnitude > 0.2f )
        {
            direction = targetPos - transform.position;
            transform.position += direction * Time.deltaTime * 6f;
            yield return null;
        }
        transform.position = targetPos;
        GameManager.Instance.gameLevel.chipManager.BehindChip(poolType);
        gameObject.SetActive(false);
    }

    private void SetBetArea(Vector3 pos)
    {
        RaycastHit hit;

        if (Physics.Raycast(pos, Vector3.forward, out hit, 100f, GameManager.Instance.gameLevel.chipManager.BetAreaLayer))
        {
            this.betArea = hit.collider.gameObject.GetComponent<BetArea>();

            if (hit.collider.gameObject.GetComponent<OutSideArea>())
            {
                this.betArea = null;
                GameManager.Instance.gameLevel.tableHighlighter.OnObjectExit();
            }
        }
    }
}
