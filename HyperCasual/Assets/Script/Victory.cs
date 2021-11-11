using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Victory : MonoBehaviour
{


    public Sprite newSprite;
    public GameObject porteDeSortie;
    public GameObject barriere;

    public static Victory instance;


    private void Awake()
    {
        if(instance != null) 
        {
            Debug.Log("il y a plus d'un instance de victory dans la scene");
        }

        instance = this;
    }



    public void VictoryScript()
    {
        //on reactive le box collider et on desactive les barrière
        porteDeSortie.GetComponent<BoxCollider2D>().enabled = true;
        barriere.SetActive(false);

        //on change le haut de la porte en jaune pour signifier que le niveau est fini
       SpriteRenderer  spriteRenderer = GetComponent<SpriteRenderer>();
       spriteRenderer.sprite = newSprite;

       


    }
}
