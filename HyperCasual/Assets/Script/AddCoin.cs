using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class AddCoin : MonoBehaviour
{
    private int coinCount;
    public Text coin;

    public void AddCoins(int coin)
    {
        coinCount += coin;
        UpdateCoinUi();

    }

    public void UpdateCoinUi()
    {
        coin.text = coinCount.ToString();
    }
}
