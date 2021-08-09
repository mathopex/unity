using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestScript : MonoBehaviour
{
    public float range;

    private void Update()
    {

        Debug.DrawRay(transform.position, transform.TransformDirection(Vector2.down) * range, Color.red);

        RaycastHit2D hit = Physics2D.Raycast(transform.position, transform.TransformDirection (Vector2.down) , range);

        if (hit)
        {
            Debug.Log("hit");
        }

    }

}
