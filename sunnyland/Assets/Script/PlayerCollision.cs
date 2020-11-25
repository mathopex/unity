using UnityEngine;
using System.Collections;

public class PlayerCollision : MonoBehaviour
{
    private Animator animator;
    public bool isInvincible;
    public float invicibilityTimeAfterHit = 1f;


    private void Start()
    {
        animator = GetComponent<Animator>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.CompareTag("Enemi") || collision.transform.CompareTag("Eagle"))
        {
            Damage(1);
        }
    }

    public void Damage(int damage)
    {
        if (!isInvincible)
        {


            PlayerInfo.instance.heal -= damage;

            if (PlayerInfo.instance.heal == 2)
            {
                PlayerInfo.instance.vie3.SetActive(false);
            }
            else if (PlayerInfo.instance.heal == 1)
            {
                PlayerInfo.instance.vie2.SetActive(false);
            }
            else if (PlayerInfo.instance.heal == 0)
            {
                PlayerInfo.instance.vie1.SetActive(false);
            }
            isInvincible = true;
            //StartCoroutine(HandleInvicibilityDelay());

        }
    }


    // temps d'invincibilité apres des degats
    public IEnumerator HandleInvicibilityDelay()
    {
        animator.SetBool("Hurt", true);
        gameObject.GetComponent<PLayerMovement>().enabled = false;

        //periode d'invincibilité du joueur
        yield return new WaitForSeconds(invicibilityTimeAfterHit);
        animator.SetBool("Hurt", false);
        isInvincible = false;
        gameObject.GetComponent<PLayerMovement>().enabled = true;

    }
}

