using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "GameData", menuName = "ScriptableObjects/GameData", order = 2)]
public class MyGameData : ScriptableObject
{
    [Header("Main Data")]
    public MainData mainData = new MainData();

    [Header("Player Data")]
    public PlayerData playerData = new PlayerData();

    [Header("Statistic Data")]
    public List<SpinData> spinData = new List<SpinData>();



    [ContextMenu("ResetData")]
    public void ResetData()
    {
        mainData.vibration = true;
        mainData.sound = true;
        mainData.music = true;


        playerData.moneyCount = 1000;
        spinData.Clear();


        PlayerPrefs.DeleteAll();
        SaveManager.SaveGameData(this);
    }

    [ContextMenu("SaveData")]
    public void Save()
    {
        SaveManager.SaveGameData(this);
    }
}
