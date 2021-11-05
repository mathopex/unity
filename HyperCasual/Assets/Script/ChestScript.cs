using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChestScript : MonoBehaviour
{
    private Animator animator;
    private bool isRange = false;

    private void Start()
    {
        animator = GetComponent<Animator>();
    }


    private void Update()
    {
        //appuyer sur F
        if (Input.GetKeyDown(KeyCode.F))
        {
            Chest();
        }
    }



    private void Chest()
    {
        //si le joueur est a portez 
        if (isRange)
        {
            animator.SetTrigger("Chest");
            GameObject.Find("Inventory").GetComponent<AddCoin>().AddCoins(100);
            GetComponent<BoxCollider2D>().enabled = false;
            isRange = false;
            Destroy(GetComponent<BoxCollider2D>());
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            isRange = true;
        }
     
    }
}
