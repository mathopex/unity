using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;


public class PickupCoin : MonoBehaviour
{
   
    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        //ajout des pieces
        if (collision.transform.CompareTag("Player"))
        {

           GameObject.Find("Inventory").GetComponent<AddCoin>().AddCoins(1);
            Destroy(gameObject);

            

        }
    }
}
