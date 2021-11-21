using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupStar : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.CompareTag("Player"))
        {

            GameObject.Find("Inventory").GetComponent<Inventory>().AddStars(1);
            Destroy(gameObject);
        }
    }
}
