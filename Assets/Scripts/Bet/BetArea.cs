using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BetArea : MonoBehaviour, ISelectiable
{
    public BetType BetType;

    [SerializeField] public int[] winNumbers;

    public void Hover()
    {
        TableHighlighter.Instance.Hover(this);
    }
}
