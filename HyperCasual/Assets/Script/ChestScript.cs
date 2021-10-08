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
        if (Input.GetKeyDown(KeyCode.F))
        {
            Chest();
        }
    }



    private void Chest()
    {
        if (isRange)
        {
            animator.SetTrigger("Chest");
            GameObject.Find("Inventory").GetComponent<AddCoin>().AddCoins(100);
            GetComponent<BoxCollider2D>().enabled = false;
            isRange = false;
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
