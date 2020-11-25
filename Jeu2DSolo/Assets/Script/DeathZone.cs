using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathZone : MonoBehaviour
{


    private void Awake()
    {

    }

    public void OnTriggerEnter2D(Collider2D collision)
    {

    
        if (collision.CompareTag("Player"))
        {
            PlayerHealth playerHealth = collision.transform.GetComponent<PlayerHealth>();
            playerHealth.TakeDamage(33);

            //si le joueur et a 0 point de vie il n'est plus repositionné au PlayerSpawn/checkpoint
            if (PlayerHealth.instance.currentHealth <= 0)
            {
                return;
            }

            collision.transform.position = CurrentSceneManager.instance.respawnPoint;
        
            

        }

        
    }

   


}
