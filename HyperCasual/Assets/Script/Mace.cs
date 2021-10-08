using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mace : MonoBehaviour
{
        
    public float speed;
    private float range = 10;
    private float checkDelay;
    public LayerMask playerLayer;
    private Vector3 destination;
    public float checkTimer;
    private bool attacking;
    public Vector3 originPoint;
    public GameObject pupilleFixe;
    public GameObject pupilleMobile;

    public Transform groundCheck;
    public float groundCheckRadius = 0.2f;
    public LayerMask collisionLayer;
    public bool isGrounded;
    private Transform target;
    public Transform[] waypoints;


    private void Start()
    { 
        target = waypoints[0];
        collisionLayer = 0;
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

        if (isGrounded)
        {
            Vector3 dir = target.position - transform.position;
            transform.Translate(dir.normalized * speed * Time.deltaTime, Space.World);

            //on met le layermask a everything
            collisionLayer = ~0;
        }

        if (Vector3.Distance(transform.position, target.position) < 0.3f)
        {
            //nothing
            collisionLayer = 0;
            range = 10;
            
        } 
        
    }

    private void FixedUpdate()
    {
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius,collisionLayer);
    }


    private void CheckForPlayer()
    {
        //Debug.DrawRay(transform.position, Vector2.down * range, Color.red);
        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.down , range, playerLayer);

        if (hit.collider != null && !attacking)
        {

            pupilleMobile.GetComponent<Animator>().enabled = false;
            pupilleMobile.SetActive(false);
            pupilleFixe.SetActive(true);
            attacking = true;
            destination = -transform.up * range;
            checkTimer = 0;

        }
            
    }
       
    private void Stop()
    {
        
        attacking = false;
        pupilleMobile.GetComponent<Animator>().enabled = true;
        pupilleMobile.SetActive(true);
        pupilleFixe.SetActive(false);
        collisionLayer = 1;
        range = 0;

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.transform.CompareTag("Player"))
        {

            GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerHealth>().RemoveHeart(1);
            PlayerDeath.instance.Die();
            range = 1;
            
        }

        Stop();
    }


    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(groundCheck.position, groundCheckRadius);
    }
}






