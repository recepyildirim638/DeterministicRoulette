using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BetManager : MonoSingleton<BetManager>
{
    List<Chip> BetChipList = new List<Chip>();

    private int BetWonAmount = 0;

    public void Initalize()
    {
        BetWonAmount = 0;
      
        BetChipList.Clear();
        ActionManager.ChangeBetValue?.Invoke(GetAddedChipValue());
    }

    public float GetBetWonAmount() => BetWonAmount;

    private void OnEnable()
    {
        ActionManager.WheelEnd += WheelEndFunc;
    }
    private void OnDisable()
    {
        ActionManager.WheelEnd -= WheelEndFunc;
    }

    private void WheelEndFunc()
    {
        GameManager.Instance.moneyManager.AddMoney(BetWonAmount);
    }

    public void AddChip(Chip chip)
    {
        BetChipList.Add(chip);
        GameManager.Instance.moneyManager.DecMoney(chip.GetValue());
        ActionManager.ChangeBetValue?.Invoke(GetAddedChipValue());
    }

    public void RemoveChip(Chip chip)
    {
        BetChipList.Remove(chip);
        GameManager.Instance.moneyManager.AddMoney(chip.GetValue());
        ActionManager.ChangeBetValue?.Invoke(GetAddedChipValue());
    }

    public int GetAddedChipValue()
    {
        int value = 0;

        for (int i = 0; i < BetChipList.Count; i++)
            value += BetChipList[i].GetValue();

        return value;
    }

    public void CalculateBetResultBalance()
    {
       StartCoroutine(CalculateBetResultBalanceEnumerator());
    }

    IEnumerator CalculateBetResultBalanceEnumerator()
    {
        int wonMoney = 0;

        for (int i = 0; i < BetChipList.Count; i++)
        {
            
            if (IsWinNumber(BetChipList[i].betArea.winNumbers))
            {
                wonMoney += (BetChipList[i].GetValue() * (36 / BetChipList[i].betArea.winNumbers.Length));
            }
            yield return null;
        }

        BetWonAmount = wonMoney;


    }

    private bool IsWinNumber(byte[] numberList)
    {
        for (int i = 0; i < numberList.Length ; i++)
        {
            if (numberList[i] == GameManager.BET_RESULT_NUMBER) 
                return true;
        }

        return false;
    }
}
