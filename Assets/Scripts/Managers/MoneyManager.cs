using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoneyManager : MonoSingleton<MoneyManager>
{
    int MoneyCount = 100;

    public int GetMoneyCount() => this.MoneyCount;

    private void Start()
    {
        ActionManager.ChangeMoneyValue?.Invoke(MoneyCount);
    }

    public void AddMoney(int value)
    {
        MoneyCount += value;
        ActionManager.ChangeMoneyValue?.Invoke(MoneyCount);
    }

    public void DecMoney(int value)
    {
        MoneyCount -= value;
        ActionManager.ChangeMoneyValue?.Invoke(MoneyCount);
    }
}
