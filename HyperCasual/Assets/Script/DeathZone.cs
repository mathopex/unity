using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathZone : MonoBehaviour
{


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.CompareTag("Player"))
        { 
            GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerHealth>().RemoveHeart(1);
            PlayerDeath.instance.Die();

        
        }
    }
   

}
