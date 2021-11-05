using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectPlayer : MonoBehaviour
{
    public float range;

    private void Update()
    {

        Debug.DrawRay(transform.position, transform.TransformDirection(Vector2.down) * range, Color.red);

        //envio unb raycats vers le bat pour detecter si le joueur est bien là ou non
        RaycastHit2D hit = Physics2D.Raycast(transform.position, transform.TransformDirection (Vector2.down) , range);

        if (hit)
        {
            Debug.Log("hit");
        }

    }

}
