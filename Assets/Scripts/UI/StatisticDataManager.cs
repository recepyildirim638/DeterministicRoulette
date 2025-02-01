using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class StatisticDataManager : MonoBehaviour
{
    [SerializeField] Text spinCountText;
    [SerializeField] Text betAmountText;
    [SerializeField] Text betWonNumberText;
    [SerializeField] Text betWonMoneyText;
    [SerializeField] Text betWonTypeText;
    [SerializeField] Text spinIndexText;
    List<SpinData> data;

    List<GameObject> betNumberList = new List<GameObject>();
    [SerializeField] GameObject betNumberPrefab;
    [SerializeField] Transform content;

    [SerializeField] Button nextButton, preButton;
    private int index;

    private void Start()
    {
        nextButton.onClick.AddListener(() => NextButtonClick());
        preButton.onClick.AddListener(() => PreButtonClick());
    }

    private void NextButtonClick()
    {

        if (data.Count - 1 > index)
        {
            index++;
            SetData(data[index]);
        }
    }

    private void PreButtonClick()
    {
        if (0 < index)
        {
            index--;
            SetData(data[index]);
        }
    }

    private void OnEnable()
    {
        data = GameManager.Instance.dataManager.GetSprinData();
        spinCountText.text = "Spin Count: " + data.Count.ToString();
        index = 0;
        SetData(data[index]);
    }

    public void PanelClose() => gameObject.SetActive(false);


    private void SetData(SpinData data)
    {
        betAmountText.text= "Amount: " + data.totalBet.ToString() + "$";
        betWonMoneyText.text ="Won: " + data.wonMoney.ToString();
        betWonNumberText.text = "Won Number: " + data.winNumber.ToString();
        betWonTypeText.text = data.gameType.ToString();
        spinIndexText.text = "Spin: " + (index + 1) ;

        for (int i = 0; i < data.data.Count; i++)
        {
            SetBetNumber(data.data[i], i, data.winNumber);
        }
        //10$ >> Red  >>  1 ,3, <color=green>5</color>, 7
    }

    private void SetBetNumber(BetSpinData data, int index, byte wonNumber)
    {
        Text numberText = GetTextNumber(index);
        string winNumbersText = string.Join(", ", data.numbers.Select(n => SetColor(n, wonNumber)));
        // string winNumbersText = string.Join(", ", data.numbers);
        numberText.text = data.betValue + " >> " + data.betType.ToString() + " >> " + winNumbersText; 
    }

    private string SetColor(byte number, byte wonNumber)
    {
        if (number == wonNumber) return $"<color=green>{number}</color>";
        else return number.ToString();
    }

    private Text GetTextNumber(int index)
    {
        if(betNumberList.Count <= index)
        {
            GameObject createObj = Instantiate(betNumberPrefab, content);
            betNumberList.Add(createObj);
            return createObj.GetComponent<Text>();
        }
        return betNumberList[index].GetComponent<Text>();
    }
}
