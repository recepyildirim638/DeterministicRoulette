using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameSelectMenuUI : MonoBehaviour
{
    public void UEButtonClick()
    {
        GameManager.Instance.LoadGame(GameType.EUROPA);
    }

    public void USAButtonClick()
    {
        GameManager.Instance.LoadGame(GameType.AMERICAN);
    }
}
