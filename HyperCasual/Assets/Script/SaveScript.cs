using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SaveScript : MonoBehaviour
{
    private int buildIndex;
    public int UnLock;

    public static SaveScript instance;


    private void Awake()
    {
        if (instance != null)
        {
            Debug.LogWarning(" il y a plus d'une instance de GameOverManager dans le jeu");
            return;
        }

        instance = this;
    }

    void Start()
    {
        buildIndex = SceneManager.GetActiveScene().buildIndex;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            SaveData();
            
        }
    }


    public void SaveData()
    {

        //sauvegarde des pieces et des etoiles gagné a la fin du niveau
        PlayerPrefs.SetInt("coins", GameObject.Find("Inventory").GetComponent<Inventory>().coinCount);
        PlayerPrefs.SetInt("star", GameObject.Find("Inventory").GetComponent<Inventory>().starCount);

        //sauvegarde de la scene ou ce trouve le joueur au moment ou il quitte le jeu
        PlayerPrefs.SetInt("CurrentScene",buildIndex);

        //la scene 0 c'est l'affiche de demarrage du jeux 
        if(buildIndex > PlayerPrefs.GetInt("CurrentScene", 1))
        {
            PlayerPrefs.SetInt("CurrentScene", buildIndex);
        }

        //la scene 1 et le level selector
        if (UnLock > PlayerPrefs.GetInt("levelUnlock"))
        {
            PlayerPrefs.SetInt("levelUnlock", UnLock);
        }
    }

}
