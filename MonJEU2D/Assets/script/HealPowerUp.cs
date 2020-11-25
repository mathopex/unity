using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealPowerUp : MonoBehaviour
{

    public int healPoint;
    public AudioClip healSound;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            if (PlayerHealth.instance.currentHealth < PlayerHealth.instance.maxHealth)
            {
                AudioManager.instance.PlayClipAt(healSound, transform.position);
                PlayerHealth.instance.HealPlayer(healPoint);
                Destroy(gameObject);
            }
            
        }
    }
}
