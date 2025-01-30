using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChipManager : MonoSingleton<ChipManager>
{
    public ChipSlot[] chipSlot;
    public LayerMask BetAreaLayer;

    [SerializeField] GameObject[] creatChips;
    
    private void Start()
    {
        creatChips = new GameObject[chipSlot.Length];
        CreateChips();
    }

    private int GetPlayerCoinCount() => MoneyManager.Instance.GetMoneyCount();

    public void CollectChip(POOL_TYPE type)
    {
        creatChips[(int)type] = null;
 
        CreateChip(type);
    }

    public void BehindChip(POOL_TYPE type)
    {
       
        for (int i = 0; i < creatChips.Length; i++)
        {
            if (creatChips[i] == null)
            {
                CreateChip(chipSlot[i].poolType);
            }
        }
    }

    public void CreateChips()
    {
        for (int i = 0; i < chipSlot.Length; i++)
        {
            CreateChip(chipSlot[i].poolType);
        }
    }

    public void ControlSlotMoneyValue()
    {
        int price = GetPlayerCoinCount();

        for (int i = 0; i < chipSlot.Length; i++)
        {
            if (creatChips[i] == null)
                continue;

            if (chipSlot[i].value > price)
            {
                creatChips[i].gameObject.SetActive(false);
                creatChips[i] = null;
            }
        }
    }

    private void CreateChip(POOL_TYPE type) 
    {
        int index = (int)type;

        if (chipSlot[index].value > GetPlayerCoinCount()) 
            return;

        GameObject chip = PoolManager.Instance.GetPoolItem(chipSlot[index].poolType);
        chip.transform.parent = transform;
        chip.transform.position = chipSlot[index].GetPosition();
        creatChips[index] = chip;
    }



    public Vector3 GetChipSlotPos(int index) => chipSlot[index].GetPosition();
}
