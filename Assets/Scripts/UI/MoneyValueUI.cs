using UnityEngine;
using UnityEngine.UI;

public class MoneyValueUI : MonoBehaviour
{
    [SerializeField] Text moneyCountTextUI;

    private void OnEnable()
    {
        ActionManager.ChangeMoneyValue += Action_ChangeMoneyValue;
    }


    private void OnDisable()
    {
        ActionManager.ChangeMoneyValue -= Action_ChangeMoneyValue;
    }

    private void Action_ChangeMoneyValue(int value)
    {
        moneyCountTextUI.text = "MONEY: " + value.ToString();
    }
}
