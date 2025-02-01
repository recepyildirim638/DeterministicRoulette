using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WhellEndPanelManager : MonoBehaviour
{
    [SerializeField] GameWinPanel winPanel;



    private void OnEnable()
    {
        ActionManager.WheelEnd += WhellEndFunc;
    }

  

    private void OnDisable()
    {
        ActionManager.WheelEnd -= WhellEndFunc;
    }

    private void WhellEndFunc()
    {
        if(BetManager.Instance.GetBetWonAmount() > 0)
            winPanel.OpenPanel();
    }
}
