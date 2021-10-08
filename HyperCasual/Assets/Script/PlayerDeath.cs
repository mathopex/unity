using System.Collections;
using UnityEngine;

public class PlayerDeath : MonoBehaviour
{

    public bool isDie;
    public Vector3 reset;
    public static PlayerDeath instance;


    private void Awake()
    {
        if(instance != null)
        {
            Debug.LogWarning(" il y a plus d'une instance de PlayerDeath dans le jeu");
            return;
        }

        instance = this;
    }

    private void Start()
    {
        reset = GameObject.FindGameObjectWithTag("Player").transform.position;
 
    }

    public  void Die()
    {
        if (PlayerHealth.instance.heartCount > 0)
        {
            GetComponent<Animator>().SetTrigger("Death");
            GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Kinematic;
            GetComponent<Rigidbody2D>().simulated = false;

            StartCoroutine(Resp());

        }
        else
        {
            isDie = true;

            GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Kinematic;
            GetComponent<Rigidbody2D>().simulated = false;
            GetComponent<CircleCollider2D>().enabled = false;
            GetComponent<Animator>().SetTrigger("Death");
           
            GameOver.instance.gameOver.SetActive(true);
        }

    }

    public void Respawn()
    {
        transform.position = Respawner.instance.respawn;

        GetComponent<Animator>().SetTrigger("Respawn");
        GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Dynamic;
        GetComponent<Rigidbody2D>().simulated = true;
        GetComponent<PlayerMouvement>().enabled = true;
        
    }



   private IEnumerator Resp()
    {
        yield return new WaitForSeconds(0.25f);
        Respawn();

        
    }
}
