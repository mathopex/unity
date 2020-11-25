using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Ladder : MonoBehaviour
{
    private bool isInRange;

    private MovePlayer movePlayer;
    public BoxCollider2D topCollider;
    private Text interactUI;
    void Awake()
    {
        movePlayer = GameObject.FindGameObjectWithTag("Player").GetComponent<MovePlayer>();
        interactUI = GameObject.FindGameObjectWithTag("InteractUI").GetComponent<Text>();
    }

    void Update()
    {

        if ( isInRange && movePlayer.isClimbing && Input.GetKeyDown(KeyCode.F))
        {
            movePlayer.isClimbing = false;
            topCollider.isTrigger = false;
            return;
        }
        if ( isInRange && Input.GetKeyDown(KeyCode.F))
        {
            movePlayer.isClimbing = true;
            topCollider.isTrigger = true;
            
        }
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
       
            interactUI.enabled = true;
            isInRange = true;
            movePlayer.rb.velocity = Vector3.zero;
            movePlayer.rb.gravityScale = 0f;

        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            isInRange = false;
            movePlayer.isClimbing = false;
            topCollider.isTrigger = false;
            interactUI.enabled = false;
            movePlayer.rb.gravityScale = 1;
            


        }
    }
}
