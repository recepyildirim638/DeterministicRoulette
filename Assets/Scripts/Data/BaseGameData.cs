using UnityEngine;

public class BaseGameData : MonoBehaviour
{
    [Header("Game Data")]
    [SerializeField] protected MyGameData gameData;

    [Header("Behaviour")]
    protected MainData mainData;
    protected PlayerData playerData;



    protected void LoadGameData()
    {
        SaveManager.LoadGameData(gameData);

        mainData = gameData.mainData;
        playerData = gameData.playerData;


    }
    protected void SaveGameData()
    {
        gameData.playerData = playerData;
        gameData.mainData = mainData;


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