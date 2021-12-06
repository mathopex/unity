using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{

    public int heartCount;
    public Text heart;


    public static PlayerHealth instance;


    private void Awake()
    {
        if(instance != null)
        {
            Debug.LogWarning("Il y a plus d'une instance de playerHealth");

        }

        instance = this;
    }

    private void Start()
    {
        heartCount = 3;
        UpdateTextUI();
            
    }
    public void RemoveHeart(int count)
    {
        heartCount -= count;
        UpdateTextUI();
    }

    public void UpdateTextUI()
    {
        heart.text = heartCount.ToString();
    }
}
