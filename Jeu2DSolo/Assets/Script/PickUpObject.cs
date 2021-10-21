﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PickUpObject : MonoBehaviour
{
   
    public AudioClip sound;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.CompareTag("Player"))
        {
            AudioManager.instance.PlayClipAt(sound, transform.position);
            Inventory.instance.AddCoins(1);
            CurrentSceneManager.instance.coinsPickeUPCount++;
            Destroy(gameObject);
        }
    }
}