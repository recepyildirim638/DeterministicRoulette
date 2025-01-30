using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoSingleton<GameManager>
{
    public static byte BET_RESULT_NUMBER;
    public static GameStatus GAME_STATUS;
    public RouletteTableManager rouletteTableManager;

    [SerializeField] GameObject BetTable;

    private void Awake()
    {
        Application.targetFrameRate = 60;
    }

    public void StartSpin()
    {
        GAME_STATUS = GameStatus.WHELLING;

        ChipManager.Instance.gameObject.SetActive(false);
        BetTable.SetActive(false);
        rouletteTableManager.StartWhelling();

    }
}
