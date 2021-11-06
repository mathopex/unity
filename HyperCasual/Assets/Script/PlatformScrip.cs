using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformScrip : MonoBehaviour
{
    
    
    //variable pour la fonction saw
    public float speed;
    public Transform[] waypoints;
    private Transform target;
    private int destPoint = 0;

    private void Start()
    {


        target = waypoints[0];

    }


    private void Update()
    {



        
        //deplacement entre 2 points
        Vector3 dir = target.position - transform.position;
        transform.Translate(dir.normalized * speed * Time.deltaTime, Space.World);

        // si l'objet est quasiment arrivé a sa destination
        if (Vector3.Distance(transform.position, target.position) < 0.3f)
        {
            destPoint = (destPoint + 1) % waypoints.Length;
            target = waypoints[destPoint];
        }

    }
}
