using System.Collections.Generic;
using UnityEngine;

public class BaseGameData : MonoBehaviour
{
    [Header("Game Data")]
    [SerializeField] protected MyGameData gameData;

    [Header("Behaviour")]
    protected MainData mainData;
    protected PlayerData playerData;
    protected List<SpinData> spinData;


    protected void LoadGameData()
    {
        SaveManager.LoadGameData(gameData);

        mainData = gameData.mainData;
        playerData = gameData.playerData;
        spinData = gameData.spinData;


    }
    protected void SaveGameData()
    {
        gameData.playerData = playerData;
        gameData.mainData = mainData;
        gameData.spinData = spinData;

        SaveManager.SaveGameData(gameData);
    }

    private void OnApplicationPause(bool pause)
    {
        if (pause)
        {
            SaveGameData();
        }
    }

    private void OnApplicationQuit()
    {
        SaveGameData();
    }
}