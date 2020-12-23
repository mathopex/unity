using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyPatrol : MonoBehaviour
{

    public float speed;
    public Transform[] waypoints;
    public int damageOnCollision = 20;

    private Transform target;
    private int destPoint = 0;
    public int life = 100;


    public SpriteRenderer graphics;

    void Start()
    {
        target = waypoints[0];
    }

    void Update()
    {
        Vector3 dir = target.position - transform.position;
        transform.Translate(dir.normalized * speed * Time.deltaTime, Space.World);

        //si l'enemi est quasiment arrivé a sa destination
        if (vector3.distance(transform.position, target.position) < 0.3f)
        {
            destpoint = (destpoint + 1) % waypoints.length;
            target = waypoints[destpoint];
            graphics.flipx = !graphics.flipx;
        }


    }
    
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.CompareTag("Player"))
        {

            Destroy(gameObject.transform.parent.gameObject);
        }
    }
    
    public void ApplyDammage(int TheDammage)
    {
       
            life = life - TheDammage;
            print(gameObject.name + "a subit " + TheDammage + " points de dégâts.");
        
    }
}



