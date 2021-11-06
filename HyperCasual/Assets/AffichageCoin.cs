using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AffichageCoin : MonoBehaviour
{


    public static AffichageCoin instance;
    public Sprite newSprite;

    public void Awake()
    {
        if(instance != null)
        {
            Debug.Log("il y a plus d'une instance  d'affichage Coin dans cette scene");
            return;
        }

        instance = this;
    }

}
