using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrapScript : MonoBehaviour
{

    //variable pour la fonction saw
    public float speed;
    public Transform[] waypoints;
    private Transform target;
    private int destPoint = 0;
    private float rotateSpeed = 3f;
    private SpriteRenderer spriteRenderer;


  
    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();


            target = waypoints[0];

    }

    void Update()
    {

        //deplacement entre 2 points
        Vector3 dir = target.position - transform.position;
        transform.Translate(dir.normalized * speed * Time.deltaTime, Space.World);

        // si l'enemi est quasiment arrivé a sa destination
        if (Vector3.Distance(transform.position, target.position) < 0.3f)
        {
            destPoint = (destPoint + 1) % waypoints.Length;
            target = waypoints[destPoint];

            
            spriteRenderer.flipX = !spriteRenderer.flipX;
        }

        //rotation de la sci en fonction du flip
        if (spriteRenderer.flipX)
        {

            transform.Rotate(new Vector3(0, 0, rotateSpeed));
        }
        else
        {

            transform.Rotate(new Vector3(0, 0, -rotateSpeed));
        }


    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //detecttion de trigger
        if (collision.CompareTag("Player"))
        {
            GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerHealth>().RemoveHeart(1);

            PlayerDeath.instance.Die();

        }
    }

}