using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour
{
    public static DialogueManager instance;

    public Text nameText;
    public Text dialogueText;
    public GameObject dialogueUI;
    public GameObject player;
    public SpriteRenderer spriteRenderer;
    public Animator animator;
    private Dialogue dialogue2;


    public bool isDialogue;

    private Queue<string> sentences;
    private void Awake()
    {
        if (instance != null)
        {
            Debug.LogWarning("il y a plus d'un instance de DialogueManager dans cette scene");
            return;
        }

        instance = this;

        sentences = new Queue<string>();
    }

    private void Start()
    {
        
    }

    public void StatDialogue(Dialogue dialogue)
    {
        player.GetComponent<MovePlayer>().enabled = false;
        MovePlayer.instance.rb.velocity = Vector3.zero;
        isDialogue = true;
        spriteRenderer.flipX = true;
        nameText.text = dialogue.name;
        animator.SetBool("IsOpen", true);
        sentences.Clear();

        foreach (string sentence in dialogue.sentences)
        {
            sentences.Enqueue(sentence);
        }
        DisplayNextSentence();
    }

    public void DisplayNextSentence()
    {

        if (sentences.Count == 0)
        {
            EndDialogue();
            return;
        }

        string sentence = sentences.Dequeue();
        dialogueText.text = sentence;
        StopAllCoroutines();
        StartCoroutine(TypeSentence(sentence));
    }

     IEnumerator TypeSentence(string sentence)
    {
        
        MovePlayer.instance.animator.SetFloat("Speed", 0);
        {
            dialogueText.text = "";

            foreach (char letter in sentence.ToCharArray())
            {
                dialogueText.text += letter;
                yield return null;
            }
        }
    }


    void EndDialogue()
    {
        player.GetComponent<MovePlayer>().enabled = true;
        spriteRenderer.flipX = false;
        isDialogue = false;
        animator.SetBool("IsOpen", false);
    }
}
