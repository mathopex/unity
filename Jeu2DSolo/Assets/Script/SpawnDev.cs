using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnDev : MonoBehaviour
{
    public float speed = 150;
    public GameObject Dev;
    public Transform waipoint;
    private Transform target;

    private void Awake()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Dev.SetActive(true);
            Waipoint();
        }
    }


    public void Waipoint()
    {
        Vector3 dir = target.position - transform.position;
        transform.Translate(dir.normalized * speed * Time.deltaTime, Space.World);

    }
}
