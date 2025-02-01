using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class GameManager : MonoSingleton<GameManager>
{
    [Header("Managers")]
    public DataManager dataManager;
    public MoneyManager moneyManager;


    public static byte BET_RESULT_NUMBER;
    public static GameStatus GAME_STATUS;

    [Header("Roulette")]
    public RouletteTableManager rouletteTableManager;

    [SerializeField] GameObject BetTable;
    [SerializeField] ButtonSelectPanel buttonSelectPanel;

    private void Awake()
    {
        Application.targetFrameRate = 60;
        dataManager.Initalize();
        moneyManager.Initalize();
    }

    public void StartSpin()
    {
        GAME_STATUS = GameStatus.WHELLING;
        BetManager.Instance.CalculateBetResultBalance();

        ChipManager.Instance.gameObject.SetActive(false);
        BetTable.SetActive(false);
        rouletteTableManager.StartWhelling();
    }

    public void Betting()
    {
        PoolManager.Instance.HideAllPool();
        ChipManager.Instance.Initalize();
        buttonSelectPanel.CreateResultNumber();
        BetManager.Instance.Initalize();

        rouletteTableManager.CloseWhelling();
        ChipManager.Instance.gameObject.SetActive(true);
        BetTable.SetActive(true);
        GAME_STATUS = GameStatus.BETTING;
    }

}
