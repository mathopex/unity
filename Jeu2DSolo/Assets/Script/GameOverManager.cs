using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverManager : MonoBehaviour
{

    public GameObject gameOverUI;

    public static GameOverManager instance;
    private void Awake()
    {
        if (instance != null)
        {
            Debug.LogWarning("il y a plus d'un instance de GameOverManager dans cette scene");
            return;
        }

        instance = this;
    }

    public void OnPlayerDeath()
    {

       //active le menu GameOver
        gameOverUI.SetActive(true);
    }

    //recommencer le niveau
    public void RetryButton()
    {

        Inventory.instance.RemoveCoin(CurrentSceneManager.instance.coinsPickeUPCount);

        //on recherche le scene du joueur
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);

        //on replace le joueur
        PlayerHealth.instance.Respawn();

        //on desactive le menu GameOver
        gameOverUI.SetActive(false);
    }

    // allez au menu principal
    public void MenuButton()
    {
       
        SceneManager.LoadScene("MainMenu");
    }

    // quitter le jeu
    public void ExitButton()
    {
        Application.Quit();
    }
}
