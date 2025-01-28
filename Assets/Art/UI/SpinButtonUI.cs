using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpinButtonUI : MonoBehaviour
{
    Button spinButton;

    private void Start()
    {
        spinButton = GetComponent<Button>();
        spinButton.onClick.AddListener(() => Spin());
        spinButton.interactable = false;
    }

    private void Spin()
    {
        
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
            spinButton.interactable = false;
        else 
            spinButton.interactable = true;
    }
}
