using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AideMenu : MonoBehaviour
{
    public GameObject menuAide;
    public GameObject boutonClose;

    public static AideMenu instance;

    private void Awake()
    {
        if(instance != null)
        {
            Debug.Log("il y a plus d'une instance de aideMenu dans la scene");
        }

        instance = this;

        
    }

    public void OpenAideMenu()
    {
        //si le la sauvegarde du tuto et diffrente de 1 on deseactive le bouton fermer
        if(PlayerPrefs.GetInt("tuto") !=1)
        {
            boutonClose.SetActive(false);
        }
  
            StartCoroutine(LoadMenuAide());
        
    }

    private IEnumerator LoadMenuAide()
    {
        yield return new WaitForSeconds(.5f);
        menuAide.SetActive(true);
        yield return new WaitForSeconds(1f);
        boutonClose.SetActive(true);
       //a la fin du tuto on sauvegarde le fait que le joueur est vue au moins 1 fois le tuto
        PlayerPrefs.SetInt("tuto", 1);

    }


    public void Close()
    {
        menuAide.SetActive(false);
    }

 
}
