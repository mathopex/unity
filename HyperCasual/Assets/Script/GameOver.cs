using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{

    public GameObject gameOver;


    public static GameOver instance;


    private void Awake()
    {
        if (instance != null)
        {
            Debug.LogWarning(" il y a plus d'une instance de GameOverManager dans le jeu");
            return;
        }

        instance = this;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            gameOver.SetActive(true);
        }
    }



   public void Retry()
    {
        //on recherche le scene du joueur
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);

        //on replace le joueur
        PlayerDeath.instance.Respawn();

        //on desactive le menu GameOver
        gameOver.SetActive(false);
    }


    public void Quit()
    {
        Application.Quit();
    }

}
