using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CurrentSceneManager : MonoBehaviour
{ 
    public int coinsPickeUPCount;
    public Vector3 respawnPoint;
    public int levelToUnlock;
    public int build;
    

    public static CurrentSceneManager instance;

    private void Awake()
    {
        if (instance != null)
        {
            Debug.LogWarning("il y a plus d'un instance de CurrentSceneManager dans cette scene");
            return;
        }

        instance = this;

        respawnPoint = GameObject.FindGameObjectWithTag("Player").transform.position;
    }
}
