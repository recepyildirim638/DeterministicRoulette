using System;
using System.Collections.Generic;
using UnityEngine;

public class GameDatas
{
   
}

[Serializable]
public class MainData
{
    [Header("GENERAL DATA")]
    public bool music;
    public bool sound;
    public bool vibration;
}

[Serializable]
public class PlayerData
{
    [Header("PLAYER DATA")]
    public int moneyCount;
}



[Serializable]
public class SpinData
{
    public byte winNumber;
    public int totalBet;
    public int wonMoney;
    public GameType gameType;
    public List<BetSpinData> data = new List<BetSpinData>();
}

[Serializable]
public class BetSpinData
{
    public int betValue;
    public BetType betType;
    public byte[] numbers;
}