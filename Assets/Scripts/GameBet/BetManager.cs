using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

public class BetManager : MonoBehaviour
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

    public async void CalculateBetResultBalance()
    {
        await CalculateBetResultBalanceAsync();
        AddStatistic();
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

   

    private void AddStatistic()
    {
        SpinData spinData = new SpinData();
        spinData.winNumber = GameManager.BET_RESULT_NUMBER;
        spinData.wonMoney = BetWonAmount;
        spinData.totalBet = GetAddedChipValue();
        spinData.gameType = GameManager.Instance.gameLevel.GameType;
        
        for (int i = 0;i < BetChipList.Count; i++)
        {
            BetSpinData betData = new();
            betData.betValue = BetChipList[i].GetValue();
            betData.betType = BetChipList[i].betArea.BetType;
            betData.numbers = BetChipList[i].betArea.winNumbers;
            spinData.data.Add(betData);
        }

        GameManager.Instance.dataManager.AddStatisticData(spinData);

    }

   

    async Task CalculateBetResultBalanceAsync()
    {
        int wonMoney = 0;

        for (int i = 0; i < BetChipList.Count; i++)
        {
            if (IsWinNumber(BetChipList[i].betArea.winNumbers))
            {
                wonMoney += (BetChipList[i].GetValue() * (36 / BetChipList[i].betArea.winNumbers.Length));
            }
            await Task.Yield();
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
