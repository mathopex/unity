using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TutoScript : MonoBehaviour
{
    private Queue<string> sentences;
    public Text dialogueText;
    public GameObject dialogueUI;
    public Dialogue dialogue;
    public int count;
   
    private void Awake()
    {
        sentences = new Queue<string>();
    }

    private void Start()
    {
        StartDialogue();
    }


    public void StartDialogue()
    {
        sentences.Clear();

       foreach(string sentence in dialogue.sentences)
        {
            sentences.Enqueue(sentence);
        }

        DisplayNextSentence();
    }

    public void DisplayNextSentence()
    {
        if(sentences.Count == 0)
        {
            EndDialogue();
            return;
        }

        string textTuto = sentences.Dequeue();
        dialogueText.text = textTuto;
    }

    public void EndDialogue()
    {

    }

}
