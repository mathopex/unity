using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class weakSpot : MonoBehaviour
{

    public GameObject objectToDestroy;
    public GameObject graphics;
    public AudioClip killSound;
    public Animator animator;
   


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            AudioManager.instance.PlayClipAt(killSound, transform.position);
            StartCoroutine(DeathEnemie());
            
        }
    }

    public IEnumerator DeathEnemie()
    {
        graphics.GetComponent<EnemyPatrol>().enabled = false;
        graphics.GetComponent<BoxCollider2D>().enabled = false;
        animator.SetBool("SnakeDead",true);
        yield return new WaitForSeconds(0.45f);
        Destroy(objectToDestroy);
    }
}
