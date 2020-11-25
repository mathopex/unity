using System.Collections;
using System.Collections.Generic;
using System.Data;
using UnityEngine;
using UnityEngine.UI;

public class PlayerInfo : MonoBehaviour
{
    public static PlayerInfo pI;
    public Image[] heart;
    public int PlayerHealth = 3;
    public int  NbCoin;

    private void Awake()
    {
        pI = this;
    }


    public void SetHealth(int val)
    {
        PlayerHealth += val;
         
            if (PlayerHealth > 3)
        {
            PlayerHealth = 3;
        }
            if (PlayerHealth < 0)
        {
            PlayerHealth = 0;
        }
    }

    public void GetCoin() 
    {

        NbCoin++;
    }
        
    
}
