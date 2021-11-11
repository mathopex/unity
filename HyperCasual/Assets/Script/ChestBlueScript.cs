﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChestBlueScript : MonoBehaviour
{
    private Animator animator;
    private bool isRange = false;
    public GameObject ancre;
    public GameObject image;
    public Sprite newSprite;
    public Toggle toggle;


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
            int random = Random.Range(100, 501);
            //instancie la popup du nombre de pièce
            animator.SetTrigger("Chest");
            GameObject.Find("Inventory").GetComponent<AddStar>().AddStars(1);
            GeneractionGameObject(ancre.transform.position, 1);
            GeneractionImage(image.transform.position);
            GetComponent<BoxCollider2D>().enabled = false;
            toggle.isOn = true;
            isRange = false;

            Victory.instance.VictoryScript();

        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            isRange = true;
        }
     
    }



    public GameObject GeneractionGameObject(Vector3 pos, int starChest)
    {
        //creation du gameObject parent qui affichera le texte
        GameObject go = new GameObject("textStar");

        //definie la position
        go.transform.position = pos;

        //ajoute du textMesh comme componant
        TextMesh text = go.AddComponent<TextMesh>();
        text.text = "+ " + starChest.ToString();

        Destroy(go, 1f);
        return gameObject;
    }


    public GameObject GeneractionImage(Vector3 pos)
    {
        //creation du gameObject parent qui affichera le texte
        GameObject image = new GameObject("imageStar");

        //definie la position
        image.transform.position = pos;

        //ajoute du textMesh comme componant
        SpriteRenderer spriteRenderer = image.AddComponent<SpriteRenderer>();
        spriteRenderer.sprite = newSprite;

        Destroy(image, 1f);
        return gameObject;
    }


}