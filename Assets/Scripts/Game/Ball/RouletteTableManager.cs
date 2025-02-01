using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RouletteTableManager : MonoBehaviour
{
    [SerializeField] GameObject Roulette;
    [SerializeField] Ball ball;
    public void StartWhelling()
    {
        Roulette.gameObject.SetActive(true);
        ball.StartWheel();
    }

    public void CloseWhelling()
    {
        Roulette.gameObject.SetActive(false);
     
    }
}
