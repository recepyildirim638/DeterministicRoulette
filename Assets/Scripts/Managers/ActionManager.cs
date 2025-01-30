using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActionManager 
{
    public static Action GameLoaded {  get; set; }

    public static Action<int> ChangeBetValue { get; set;}

    public static Action<int> ChangeMoneyValue{ get; set; }
    public static Action<byte> SelectResultNumber { get; set; }
}
