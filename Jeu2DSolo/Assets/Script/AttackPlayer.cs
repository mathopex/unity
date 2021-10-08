using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackPlayer : MonoBehaviour
{
    public int DamageWeapon;
    private bool isAttack;


    

    // Update is called once per frame
    void Update()
        
    {
        
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.CompareTag("enemie"))
        {
            

        }
    }
}


