using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mace : MonoBehaviour
{
        
    public float speed;
    public float range;
    private float checkDelay;
    public LayerMask playerLayer;
    private Vector3 destination;
    public float checkTimer;
    private bool attacking;
    public Vector3 originPoint;

    //private Rigidbody2D rb;

    private void Start()
    {
        //rb = GetComponent<Rigidbody2D>();
        

       
    }
    private void OnEnable()
    {
        Stop();
    }

    private void Update()
    {
           
        if (attacking)
            transform.Translate(destination * Time.deltaTime * speed);

        else
        {
            checkTimer += Time.deltaTime;

            if (checkTimer > checkDelay)
                CheckForPlayer();
        }
    }


    private void CheckForPlayer()
    {
        //Debug.DrawRay(transform.position, Vector2.down * range, Color.red);
        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.down , range, playerLayer);

        if (hit.collider != null && !attacking)
        {
            
            attacking = true;
            destination = -transform.up * range;
            checkTimer = 0;

        }
            
    }
       
    private void Stop()
    {
        
        attacking = false;
        destination = transform.up * range;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.transform.CompareTag("Player"))
        {
            Debug.Log("je touche le joueur");
            GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerHealth>().RemoveHeart(1);
            PlayerDeath.instance.Die();
            destination = transform.up * range;
            Debug.Log(" et je remonte");
            range = 1;
            
        }

        Stop();
    }
}






  