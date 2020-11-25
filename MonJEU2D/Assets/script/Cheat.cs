using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cheat : MonoBehaviour
{
    public bool piece;

    private void start()
    {
        if (piece == true)
        {
            Inventory.instance.AddCoins(999999);
        }
    }

}