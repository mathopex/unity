using UnityEngine;

public class EnemiPatrol : MonoBehaviour
{
    public float speed;
    public Transform[] waipoint;
    private Transform target;
    private int distPoint = 0;

    public SpriteRenderer spriteRenderer;


    private void Start()
    {
        target = waipoint[0];
    }

    private void Update()
    {
        Vector3 dir = target.position - transform.position;
        transform.Translate(dir.normalized * speed * Time.deltaTime, Space.World);

        if( Vector3.Distance(transform.position, target.position) < 0.2f)
        {
            distPoint = (distPoint + 1) % waipoint.Length;
            target = waipoint[distPoint];

            if (!gameObject.CompareTag("Eagle"))
            {
                spriteRenderer.flipX = !spriteRenderer.flipX;
            }
        }
    }
}
