using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class ScaneLoader : MonoBehaviour
{

    public const string MAIN_SCANE = "MainMenu"; 
    public const string EUROPA_LEVEL = "EURoulette";
    public const string USA_LEVEL = "USARoulette";

    public void LoadMainMenu()
    {
         SceneManager.LoadSceneAsync(MAIN_SCANE);
    }

    public void loadLevel(GameType gameType)
    {
        AsyncOperation operation;

        switch (gameType)
        {
            case GameType.EUROPA:
                operation = SceneManager.LoadSceneAsync(EUROPA_LEVEL);
                break;
            case GameType.AMERICAN:
                operation = SceneManager.LoadSceneAsync(USA_LEVEL);
                break;
            default:
                operation = SceneManager.LoadSceneAsync(EUROPA_LEVEL);
                break;

        }

        operation.completed += LevelLoaded;
    }

    private void LevelLoaded(AsyncOperation operation)
    {
        if (operation.isDone)
        {
            GameManager.Instance.LoadedLevel();
        }
    }

   
}
