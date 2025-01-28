using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChipManager : MonoSingleton<ChipManager>
{
    public ChipSlot[] chipSlot;

    private void Start()
    {
        CreateChips(120);
    }

    private int GetPlayerCoinCount() => 132;

    public void CollectChip(POOL_TYPE type)
    {
        for (int i = 0; i < chipSlot.Length; i++)
        {
            if (chipSlot[i].value > GetPlayerCoinCount()) continue;

            if (chipSlot[i].poolType == type)
            {
                GameObject chip = PoolManager.Instance.GetPoolItem(chipSlot[i].poolType);
                chip.transform.position = chipSlot[i].GetPosition();
            }
        }
    }

    public void CreateChips(int playerCoinCount)
    {
        for (int i = 0; i < chipSlot.Length; i++)
        {
            if (chipSlot[i].value > playerCoinCount) continue;

            GameObject chip = PoolManager.Instance.GetPoolItem(chipSlot[i].poolType);
            chip.transform.position = chipSlot[i].GetPosition();
        }
    }

    public Vector3 GetChipSlotPos(int index) => chipSlot[index].GetPosition();
}
