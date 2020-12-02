using UnityEngine;

public class Weakspot : MonoBehaviour
{
    public GameObject graphic;
    public Rigidbody2D rb;



    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.CompareTag("Player"))
        {
            rb.AddForce(new Vector2(0f, 100f));
            Destroy(graphic);
        }
    }
}
