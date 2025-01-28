using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BetPool : MonoBehaviour
{
    public List<Bet> betList = new List<Bet>();
}




public class Bet
{
    public int number;
    public int price;
    public BetType type;
}