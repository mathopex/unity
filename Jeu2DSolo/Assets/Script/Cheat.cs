using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cheat : MonoBehaviour
{
    public bool piece;

    void Start()
    {
        
        TricheCoin(99999999);

    }

    //infinity coin
    private void TricheCoin(int infinity)
    {
        if (piece == true)
        {
            Inventory.instance.AddCoins(infinity);
        }
    }

}