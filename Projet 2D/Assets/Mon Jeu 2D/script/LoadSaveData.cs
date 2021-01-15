﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadSaveData : MonoBehaviour
{
    public static LoadSaveData instance;
    private void Awake()
    {
        if (instance != null)
        {
            Debug.LogWarning("il y a plus d'un instance de LoadSaveData dans cette scene");
            return;
        }

        instance = this;
    }

    private void Start()
    {
        Inventory.instance.coinsCount = PlayerPrefs.GetInt("coins",0);
        Inventory.instance.UpdateTextUI();

        /*
        int currentHealth = PlayerPrefs.GetInt("currentHeal", PlayerHealth.instance.maxHealth);
        PlayerHealth.instance.currentHealth = currentHealth;
        PlayerHealth.instance.healthBar.SetHealth(currentHealth);*/

    }

    public void SaveData()
    {
        PlayerPrefs.SetInt("coins", Inventory.instance.coinsCount);
        PlayerPrefs.SetInt("levelReach",CurrentSceneManager.instance.levelToUnlock);
        PlayerPrefs.SetInt("idCurrentScene", LoadSpecificScene.instance.idCurrentScene);

        if (CurrentSceneManager.instance.levelToUnlock > PlayerPrefs.GetInt("levelReach", 1))
        {
            PlayerPrefs.SetInt("levelReach", CurrentSceneManager.instance.levelToUnlock);
        }
        if(LoadSpecificScene.instance.idCurrentScene > PlayerPrefs.GetInt("idCurrentScene", 0))
        {
            PlayerPrefs.SetInt("idCurrentScene", LoadSpecificScene.instance.idCurrentScene);
        }
       // PlayerPrefs.SetInt("currentHeal", PlayerHealth.instance.currentHealth);
    }

}