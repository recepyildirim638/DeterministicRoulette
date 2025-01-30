using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ResultButtonUI : BaseButton
{
    byte number;
    [SerializeField] Text numberText;

    public override void ButtonOnClick()
    {
        ActionManager.SelectResultNumber?.Invoke(number);
    }

    public void SetNumber(byte number, Color color)
    {
        numberText.text = number.ToString();
        this.number = number;
        GetComponent<Image>().color = color;
    }

  
}
