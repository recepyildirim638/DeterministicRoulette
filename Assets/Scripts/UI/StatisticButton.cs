using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatisticButton : BaseButton
{
    [SerializeField] GameObject statisticPanel;
    public override void ButtonOnClick()
    {
        statisticPanel.SetActive(true);
    }
}
