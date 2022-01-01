using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DebloquelvlScript: MonoBehaviour
{
    public GameObject[] barriereLvl;
    public GameObject[] hautDePorte;
    public GameObject player;
    public Sprite newSprite;


    private int debloquelvl, debloqueHautDePorte;




    private void Start()
    {
        DebloqueLvl();
        HautDePorte();

    }

    //on recupère la valeur du playerPref levlUnlock et on le compare a l'index du tableau pour debloquer la bonne porte
    private void DebloqueLvl()
    { 
        debloquelvl = PlayerPrefs.GetInt("levelUnlock");

        for (int i = 0; i < barriereLvl.Length; i++)
        {
            if (i <= debloquelvl)
            {
                barriereLvl[i].SetActive(false);
                barriereLvl[i].transform.parent.gameObject.GetComponent<BoxCollider2D>().enabled = true;
            }

        }
    
    }

    //on recupère la valeur du playerPref levlUnlock et on le compare a l'index du tableau si il est inferieure on change le haut de la porte du niveau précédent pour signifié qu'il est terminé
    private void HautDePorte()
    {
        debloqueHautDePorte = PlayerPrefs.GetInt("levelUnlock");

        for (int j = 0; j < hautDePorte.Length; j++)
        {
            if (j < debloqueHautDePorte)
            {
                SpriteRenderer spriteRenderer = hautDePorte[j].GetComponentInChildren<SpriteRenderer>();
                spriteRenderer.sprite = newSprite;
                player.transform.position = hautDePorte[j].transform.parent.transform.position;
            }

        }
    }
   


}
