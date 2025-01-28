using UnityEngine;
using UnityEngine.UI;

public class BetValueUI : MonoBehaviour
{
    [SerializeField] Text betCountTextUI;

    private void Start()
    {
        Action_ChangeBetValue(0);
    }

    private void OnEnable()
    {
        ActionManager.ChangeBetValue += Action_ChangeBetValue;
    }


    private void OnDisable()
    {
        ActionManager.ChangeBetValue -= Action_ChangeBetValue;
    }

    private void Action_ChangeBetValue(int value)
    {
        betCountTextUI.text = "BET: " + value.ToString();
    }

}
