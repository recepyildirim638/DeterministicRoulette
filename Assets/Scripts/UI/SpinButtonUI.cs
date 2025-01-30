using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpinButtonUI : BaseButton
{
    private void Spin()
    {
        SetButtonInteractive(false);
        GameManager.Instance.StartSpin();
    }

    public override void BaseStart()
    {
        SetButtonInteractive(false);
    }

    private void OnEnable()
    {
        ActionManager.ChangeBetValue += Action_ChangeBetValue;
    }

    private void OnDisable()
    {
        ActionManager.ChangeBetValue -= Action_ChangeBetValue;
    }

    private void Action_ChangeBetValue(int val)
    {
        if (val <= 0)
            SetButtonInteractive(false);
        else
            SetButtonInteractive(true);
    }

    public override void ButtonOnClick()
    {
        Spin();
    }
}
