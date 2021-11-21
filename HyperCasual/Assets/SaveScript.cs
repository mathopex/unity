using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SaveScript : MonoBehaviour
{
    private int buildIndex;
    private int buildUnLock;
   
    void Start()
    {
        buildIndex = SceneManager.GetActiveScene().buildIndex;
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void SaveData()
    {
        //sauvegarde des pieces et des etoiles gagné 
        PlayerPrefs.SetInt("coins", GameObject.Find("inventory").GetComponent<Inventory>().coinCount);
        PlayerPrefs.SetInt("star", GameObject.Find("inventory").GetComponent<Inventory>().starCount);

        //sauvegarde de la scene ou ce trouve le joueur au moment ou il quitte le jeu
        PlayerPrefs.SetInt("CurrentScene",buildIndex);

        //la scene 0 c'est l'affiche de demarrage du jeux 
        if(buildIndex > PlayerPrefs.GetInt("CurrentScene", 0))
        {
            PlayerPrefs.SetInt("CurrentScene", buildIndex);
        }

        //a la fin du niveau on sauvegare le prochaine niveau debloqué id scene actuel + 1
        PlayerPrefs.SetInt("levelUnlock", buildUnLock + 1);

        //la scene 1 et le level selector on peut veut debloqué la scene des levels 
        if(buildUnLock > PlayerPrefs.GetInt("levelUnlock", 1))
        {
            PlayerPrefs.SetInt("levelUnlock", buildUnLock + 1);
        }
    }
}
