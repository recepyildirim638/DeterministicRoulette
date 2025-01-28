using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BetTypeUI : MonoBehaviour
{
    [SerializeField] Text betCountTextUI;

    public void SetBetTypeText(BetArea refObject)
    {
        string winNumbersText = string.Join(", ", refObject.winNumbers); 
        betCountTextUI.text = refObject.BetType.ToString() + ": " + winNumbersText;
    }
   
}
