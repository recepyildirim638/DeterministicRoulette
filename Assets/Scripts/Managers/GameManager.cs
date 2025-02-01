using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class GameManager : MonoSingleton<GameManager>
{
    [Header("Managers")]
    public DataManager dataManager;
    public MoneyManager moneyManager;
    public MoveManager moveManager;
    [SerializeField] ScaneLoader scaneLoader;

    public static byte BET_RESULT_NUMBER;
    public static GameStatus GAME_STATUS;

    [Header("Game")]
    [SerializeField] public GameLevel gameLevel;

    private void Awake()
    {
        Application.targetFrameRate = 60;
        dataManager.Initalize();
        moneyManager.Initalize();
        scaneLoader.LoadMainMenu();
    }

    public void LoadGame(GameType gameType) => scaneLoader.loadLevel(gameType);

    public void LoadedLevel()
    {
        gameLevel = FindAnyObjectByType<GameLevel>();
        moveManager.Initalize();
    }

    public void StartSpin()
    {
        GAME_STATUS = GameStatus.WHELLING;
        GameManager.Instance.gameLevel.betManager.CalculateBetResultBalance();

        GameManager.Instance.gameLevel.chipManager.gameObject.SetActive(false);
        gameLevel.BetTable.SetActive(false);
        gameLevel.rouletteTableManager.StartWhelling();
    }

    public void Betting()
    {
        PoolManager.Instance.HideAllPool();
        GameManager.Instance.gameLevel.chipManager.Initalize();
        gameLevel.buttonSelectPanel.CreateResultNumber();
        GameManager.Instance.gameLevel.chipManager.Initalize();

        gameLevel.rouletteTableManager.CloseWhelling();
        GameManager.Instance.gameLevel.chipManager.gameObject.SetActive(true);
        gameLevel.BetTable.SetActive(true);
        GAME_STATUS = GameStatus.BETTING;
    }

}
