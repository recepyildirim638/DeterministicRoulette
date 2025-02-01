using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameLevel : MonoBehaviour
{
    public GameType GameType;


    public RouletteTableManager rouletteTableManager;
    public BetManager betManager;
    public ChipManager chipManager;
    public GameObject BetTable;
    public ButtonSelectPanel buttonSelectPanel;
    public TableHighlighter tableHighlighter;

    public Camera mainCamera;
}
