 using UnityEngine;
using System.Collections;
using System.Runtime.Serialization;

public class PlayerHealth : MonoBehaviour
{


    public int maxHealth = 100;
    public int currentHealth;
    public float invicibilityTimeAfterHit = 0f;
    public float invicibilityFlashDelay = 0f;


    public HealthBar healthBar;
    public SpriteRenderer graphics;
    public AudioClip hitSound;

    public bool isInvincible = false; 

    public static PlayerHealth instance;
    private void Awake()
    {
        if (instance != null)
        {
            Debug.LogWarning("il y a plus d'un instance de PlayerHealth dans cette scene");
            return;
        }

        instance = this;
    }




    void Start()
    {
        //initialisation de la barre de vie max
        currentHealth = maxHealth;
        healthBar.setMaxHealth(maxHealth);
       
    }

 
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.H))

        {
        TakeDamage(20);

        }
    }
    public void HealPlayer (int heal)
    {

        if ( (currentHealth + heal) > maxHealth)
        {
            currentHealth = maxHealth;
        }
        else
        {
            currentHealth += heal;
        }
        
        healthBar.SetHealth(currentHealth);
    }

    public void TakeDamage(int damage)
    {
        // on verifie si le joueur est invincible
        if (!isInvincible)
        {

            AudioManager.instance.PlayClipAt(hitSound, transform.position); 
            currentHealth -= damage;

            // mise a jour de la barre de vie apres degat
            healthBar.SetHealth(currentHealth);

            // on verifie si le joueur est toujour vivant
            if (currentHealth <= 0)
            {
                Die();
                return;
            }
            isInvincible = true;

            // mise en pause du code pour la periode d'invincibilité du joueur
            StartCoroutine(InvincibilityFlash());
            StartCoroutine(HandleInvicibilityDelay());
        }
    }


    public void Die()
    {

        
        //bloquer les mouvements du personnages,on desactive le scrip MovePlayer
        MovePlayer.instance.enabled = false;

        // empecher les interaction physiques avec les autre element de la scene, on passe le rigibody en kinematic et on desactive le collider
        MovePlayer.instance.rb.bodyType = RigidbodyType2D.Kinematic;

        //a la mort du joueur, le joueur n'est plus affecté par la gravité
        MovePlayer.instance.rb.simulated = false;

        //on desactive le collider du joueur pour eviter les collisions avec les enemis
        MovePlayer.instance.playerCollider.enabled = false;
       
        // voir ligne 161
        StartCoroutine(DeathPlayer());  
    }


    public void Respawn()
    {
        
        MovePlayer.instance.enabled = true;
        MovePlayer.instance.animator.SetTrigger("Respawn");
        MovePlayer.instance.rb.bodyType = RigidbodyType2D.Dynamic;
        MovePlayer.instance.rb.simulated = true;
        MovePlayer.instance.playerCollider.enabled = true;
        currentHealth = maxHealth;
        healthBar.SetHealth(currentHealth);
    }


    //faire clignoté le "player"
   public IEnumerator InvincibilityFlash()
    {
        // invincibilité visuel du joueur, clignotement du joueur
        while (isInvincible)
        {
            //on passe de l'oppacité a la transparence
            graphics.color = new Color(1f, 1f, 1f, 0f);
            yield return new WaitForSeconds(invicibilityFlashDelay);

            //on passe de la transparence a l'oppacité
            graphics.color = new Color(1f, 1f, 1f, 1f);
            yield return new WaitForSeconds(invicibilityFlashDelay);
        }
    }

    // temps d'invincibilité apres des degats
    public IEnumerator HandleInvicibilityDelay()
    {
        //periode d'invincibilité du joueur
        yield return new WaitForSeconds(invicibilityTimeAfterHit);
        isInvincible = false;
             
    }

    //permet de jouer l'animation de mort avant l'ecran de gameOver
    public IEnumerator DeathPlayer()
    {
        MovePlayer.instance.animator.SetTrigger("Die");
        yield return new WaitForSeconds(1.3f);
       GameOverManager.instance.OnPlayerDeath();

    }

}


