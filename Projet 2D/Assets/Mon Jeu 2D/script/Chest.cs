using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Chest : MonoBehaviour
{
   private bool isInRange;
    private Text interactUI;
    public Animator animator;
    private int coinToAdd = 300;
    public AudioClip chestSound;

    
    

    private void Awake()
    {
        interactUI = GameObject.FindGameObjectWithTag("InteractUI").GetComponent<Text>();
    }

    private void Start()
    {
        
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            OpenChest();
        }

    }

    private void OpenChest()
    {
        if (isInRange)
        {
            animator.SetTrigger("OpenChest");
            Inventory.instance.AddCoins(coinToAdd);
            AudioManager.instance.PlayClipAt(chestSound, transform.position);
            GetComponent<BoxCollider2D>().enabled = false;
            interactUI.enabled = false; 

        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            interactUI.enabled = true;
            isInRange = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            interactUI.enabled = false;
            isInRange = false;
        }
    }
}
