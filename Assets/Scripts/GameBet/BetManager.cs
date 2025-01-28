using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BetManager : MonoSingleton<BetManager>
{
    List<Chip> BetChipList = new List<Chip>();

    public void AddChip(Chip chip)
    {
        BetChipList.Add(chip);
        MoneyManager.Instance.DecMoney(chip.GetValue());
        ActionManager.ChangeBetValue?.Invoke(GetAddedChipValue());
    }

    public void RemoveChip(Chip chip)
    {
        BetChipList.Remove(chip);
        MoneyManager.Instance.AddMoney(chip.GetValue());
        ActionManager.ChangeBetValue?.Invoke(GetAddedChipValue());
    }

    public int GetAddedChipValue()
    {
        int value = 0;

        for (int i = 0; i < BetChipList.Count; i++)
            value += BetChipList[i].GetValue();

        return value;
    }
}
