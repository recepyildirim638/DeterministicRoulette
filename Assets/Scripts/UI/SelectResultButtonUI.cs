using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class SelectResultButtonUI : BaseButton
{
    
    [SerializeField] Text numberText;

    [SerializeField] ButtonSelectPanel buttonSelectPanel;
    public override void ButtonOnClick()
    {
        if (GameManager.GAME_STATUS == GameStatus.WHELLING)
            return;

        buttonSelectPanel.OpenPanel();
    }

    public void SetNumber(byte number, Color color)
    {
        numberText.text = number.ToString();
        GameManager.BET_RESULT_NUMBER = number;
        GetComponent<Image>().color = color;
    }
}
