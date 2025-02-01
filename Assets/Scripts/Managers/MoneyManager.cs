using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoneyManager : MonoBehaviour
{
    PlayerData playerData;
    
    public void Initalize()
    {
        playerData = GameManager.Instance.dataManager.GetPlayerData();
    }

    public int GetMoneyCount() => this.playerData.moneyCount;

    private void Start()
    {
        ActionManager.ChangeMoneyValue?.Invoke(playerData.moneyCount);
    }

    public void AddMoney(int value)
    {
        playerData.moneyCount += value;
        ActionManager.ChangeMoneyValue?.Invoke(playerData.moneyCount);
    }

    public void DecMoney(int value)
    {
        playerData.moneyCount -= value;
        ActionManager.ChangeMoneyValue?.Invoke(playerData.moneyCount);
    }
}
