 using UnityEngine;
using System.Collections;
using System.Runtime.Serialization;

public class EnemieHealth : MonoBehaviour
{


    public int maxHealth = 100;
    public int currentHealth;


    public HealthBarEnemie healthBarEnemie;
    public SpriteRenderer graphics;


    void Start()
    {
        //initialisation de la barre de vie max
        currentHealth = maxHealth;
        healthBarEnemie.setMaxHealth(maxHealth);
       
    }

 
    void Update()
    {
      
    }
  
}


