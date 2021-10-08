using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlipRight : MonoBehaviour

{
    public SpriteRenderer SpriteRenderer;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {

            SpriteRenderer.flipX = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            SpriteRenderer.flipX = false; ;
        }
    }
}
