using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private static GameManager _instance;

    public static GameManager Instance
    {
        get
        {
            return _instance;
        }
            
    }
    

    private void Awake()
    {
        if(_instance == null)
        {

            _instance = this;
        }
        else
        {
            Destroy(this);
        }
                
    }

    /* caracteristique du personnage*/
    public int xp = 0;
    public int or = 0;

    //Loot

    public GameObject[] lootGolem;
    public GameObject oeil;



    //sauvegarde des données

    public void SaveData()
    {
        PlayerPrefs.SetInt("xp", xp);
        PlayerPrefs.SetInt("or", or);
    }

    public void LoadData()
    {
        xp = PlayerPrefs.GetInt("xp");
        or = PlayerPrefs.GetInt("or");
    }
}
