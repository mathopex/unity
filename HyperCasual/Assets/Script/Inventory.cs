using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Inventory : MonoBehaviour
{
    public int coinCount,starCount;
    public Text coin, star;

    private void Start()
    {
        AddCoins(PlayerPrefs.GetInt("coins"));
        AddStars(PlayerPrefs.GetInt("star"));
    }



    public void AddCoins(int coin)
    {
        coinCount += coin;
        UpdateCoinUi();

    }

    public void UpdateCoinUi()
    {
        coin.text = coinCount.ToString();
    }


   

    public void AddStars(int count)
    {
        starCount += count;
        UpdateStarUi();

    }

    public void UpdateStarUi()
    {
        star.text = starCount.ToString();
    }
}
