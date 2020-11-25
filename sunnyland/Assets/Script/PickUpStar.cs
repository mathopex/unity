using UnityEngine;
using System.Collections;

public class PickUpStar : MonoBehaviour
{

    private Animator animator;


    private void Start()
    {

        animator = GetComponent<Animator>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            PlayerInfo.instance.GetStar();
            StartCoroutine("DestroyStar");
        }
    }

    public IEnumerator DestroyStar()
    {
        gameObject.GetComponent<BoxCollider2D>().enabled = false;
        animator.SetBool("Destroy", true);
        yield return new WaitForSeconds(0.41f);
        Destroy(gameObject);
    }

}
