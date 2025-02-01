using System;
using UnityEngine;

public class TableHighlighter : MonoBehaviour
{
    public TableNumber[] numberList;

    private BetArea _lastHighlightObject;


    [SerializeField] BetTypeUI betTypeUI;

    public void Hover(BetArea refObject)
    {
        if(_lastHighlightObject != null)
        {
            if(ReferenceEquals(refObject, _lastHighlightObject))
                return;
            else
                OnObjectExit();
        }

        OnObjectHover(refObject);
        _lastHighlightObject = refObject;
        betTypeUI.SetBetTypeText(refObject);
    }

    public void OnObjectHover(BetArea refObject)
    {
        for (int i = 0; i < refObject.winNumbers.Length; i++)
            SearhTableNumber(refObject.winNumbers[i])?.SetActive(true);
    }

    public void OnObjectExit()
    {
        if (_lastHighlightObject == null)
            return;

        for (int i = 0; i < _lastHighlightObject.winNumbers.Length; i++)
            SearhTableNumber(_lastHighlightObject.winNumbers[i])?.SetActive(false);

        betTypeUI.ClearText();
    }


    public GameObject SearhTableNumber(int number)
    {
        for (int i = 0; i < numberList.Length; i++)
        {
            if (numberList[i].number == number)
                return numberList[i].gameObject;
        }
        return null;
    }
}
