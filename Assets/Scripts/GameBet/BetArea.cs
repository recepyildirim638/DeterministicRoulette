using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BetArea : MonoBehaviour, ISelectiable
{
    public BetType BetType;

    [SerializeField] public byte[] winNumbers;

    public void Hover()
    {
        GameManager.Instance.gameLevel.tableHighlighter.Hover(this);
    }
}
