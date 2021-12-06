using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AfficheMenu : MonoBehaviour
{
    public GameObject menuAide;
    //menu pause

    private void Awake()
    {
        //avant le lancement du jeu on regarde si le tuto a deja été lancé ou pas, si c'est le cas on desactiv le scrip du tuto
        if (PlayerPrefs.GetInt("tuto") == 1)
        {
            GetComponent<AideMenu>().enabled = false;
        }

    }


    private void Start()
    {
        //si on a pas regardé le tuto on le lance, sinon on le lance (cette condition est la au cas ou le tuto ce lance malgré le script desactivé )
        if (PlayerPrefs.GetInt("tuto") != 1)
        {
            AideMenu.instance.OpenAideMenu();
        }
       
        
    }


    // Update is called once per frame
    void Update()
    {
        OpenAide();
    }


    private void OpenAide()
    {
        //si il est deja actif on le desactive
        if (menuAide.activeSelf)
        {
            if (Input.GetKeyDown(KeyCode.Tab))
            {
                menuAide.SetActive(false);
                Time.timeScale = 1;
            }

        }
        else
        {
            //si il est pas actif on l'active 
            if (Input.GetKeyDown(KeyCode.Tab))
            {
                menuAide.SetActive(true);
                Time.timeScale = 0;
            }

        }
    }

    public void Close()
    {
        menuAide.SetActive(false);
        Time.timeScale = 1;
    }
}
