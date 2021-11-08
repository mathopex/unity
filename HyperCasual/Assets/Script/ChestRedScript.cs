using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChestRedScript : MonoBehaviour
{
    private Animator animator;
    private bool isRange = false;
    public GameObject ancre;
    public GameObject image;
    public Sprite newSprite;

    private void Start()
    {
        animator = GetComponent<Animator>();

        int childcoint = GameObject.Find("CoinMgr").transform.childCount;
        Debug.Log(childcoint / 2);
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
            GameObject.Find("Inventory").GetComponent<AddCoin>().AddCoins(random);
            GeneractionGameObject(ancre.transform.position, random);
            GeneractionImage(image.transform.position);
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



    public GameObject GeneractionGameObject(Vector3 pos, int coinChest)
    {
        //creation du gameObject parent qui affichera le texte
        GameObject go = new GameObject("textCoins");

        //definie la position
        go.transform.position = pos;

        //ajoute du textMesh comme componant
        TextMesh text = go.AddComponent<TextMesh>();
        text.text = "+ " + coinChest.ToString();

        Destroy(go, 1f);
        return gameObject;
    }


    public GameObject GeneractionImage(Vector3 pos)
    {
        //creation du gameObject parent qui affichera le texte
        GameObject image = new GameObject("imageCoins");

        //definie la position
        image.transform.position = pos;

        //ajoute du textMesh comme componant
        SpriteRenderer spriteRenderer = image.AddComponent<SpriteRenderer>();
        spriteRenderer.sprite = newSprite;

        Destroy(image, 1f);
        return gameObject;
    }


}
