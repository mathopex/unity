
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class DialogueTrigger : MonoBehaviour
{
    public bool isInRange;
    private Text interactUI;
    public SpriteRenderer spriteRenderer;







    public Dialogue dialogue;

    private void Awake()
    {
        interactUI = GameObject.FindGameObjectWithTag("InteractUI").GetComponent<Text>();
    }
    void Update()
    {
        if(isInRange && Input.GetKeyDown(KeyCode.F)){
            TriggerDialogue();
            
        }

        if (isInRange && DialogueManager.instance.isDialogue && Input.GetKeyDown(KeyCode.Mouse0))
         {
            DialogueManager.instance.DisplayNextSentence();
        }

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            isInRange = true;
            interactUI.enabled = true;

        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            isInRange = false;;
            interactUI.enabled = false;

        }

    }

    public void TriggerDialogue()
    {
        DialogueManager.instance.StatDialogue(dialogue);
    }
}
