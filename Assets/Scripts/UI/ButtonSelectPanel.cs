using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ButtonSelectPanel : MonoBehaviour
{
    [SerializeField] GameObject resultButton;

    [SerializeField] Transform panel;
    [SerializeField] Transform content;

    [SerializeField] BetArea redArea;
    [SerializeField] BetArea blackArea;

    [SerializeField] Color red , black ,blue;

    [SerializeField] SelectResultButtonUI resultUI;

    private void Start()
    {
        CreateResultNumber();

        int numberCnt = 37;

        if (GameManager.Instance.gameLevel.GameType == GameType.AMERICAN)
        {
            numberCnt = 38;
        }

        for (byte i = 0; i < numberCnt; i++)
        {
            GameObject create = Instantiate(resultButton, content);
            create.GetComponent<ResultButtonUI>().SetNumber(i, GetNumberColor(i));
        }
    }

    public void CreateResultNumber()
    {
        byte rnd = (byte)Random.Range(0, 37);
        SeltResultNumber(rnd);

    }

    private void OnEnable()
    {
        ActionManager.SelectResultNumber += SeltResultNumber;
    }
    private void OnDisable()
    {
        ActionManager.SelectResultNumber -= SeltResultNumber;
    }

    private void SeltResultNumber(byte val)
    {
        resultUI.SetNumber(val, GetNumberColor(val));
        ExitPanel();
    }

    public void OpenPanel()
    {
        panel.gameObject.SetActive(true);
    }

    public void ExitPanel()
    {
        panel.gameObject.SetActive(false);
    }

    public Color GetNumberColor(byte val)
    {
        if (val == 37 || val == 0)
            return blue;

        for(byte i = 0;i < redArea.winNumbers.Length;i++)
        {
            if (val == redArea.winNumbers[i])
                return red;
        }

        for (byte i = 0; i < blackArea.winNumbers.Length; i++)
        {
            if (val == blackArea.winNumbers[i])
                return black;
        }

        return Color.white;
    }
}
