using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class GameWinPanel : MonoBehaviour
{
    [SerializeField] GameObject panel;
    [SerializeField] Text winAmound;
    [SerializeField] Text numberText;
    [SerializeField] Image numberTextImage;
    [SerializeField] ButtonSelectPanel buttonSelectPanel;
    [SerializeField] Button nextButton;

    private void Start()
    {
        nextButton.onClick.AddListener(() => NextButtonClick());
    }

    private void NextButtonClick()
    {
        GameManager.Instance.Betting();
        panel.SetActive(false);
    }

    public void OpenPanel()
    {
        panel.SetActive(true);
        winAmound.text = GameManager.Instance.gameLevel.betManager.GetBetWonAmount().ToString();
        SetNumber();
    }

    public void SetNumber()
    {
        numberText.text = GameManager.BET_RESULT_NUMBER.ToString();
        numberTextImage.color = buttonSelectPanel.GetNumberColor(GameManager.BET_RESULT_NUMBER);
    }
}
