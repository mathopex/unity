﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PickupCoin : MonoBehaviour
{

    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.CompareTag("Player"))
        {
           
            Destroy(gameObject);
        }
    }
}
