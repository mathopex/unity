using UnityEngine;

public class Weakspot : MonoBehaviour
{
    public GameObject graphic;
    public Rigidbody2D rb;
    public SpriteRenderer spriteRenderer;
    public Animator animator;
    public BoxCollider2D boxCollider2D;



    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.CompareTag("Player"))
        {
            rb.AddForce(Vector2.up * 450);
            spriteRenderer.enabled = false;
            boxCollider2D.enabled = false;
            animator.SetTrigger("Die");
            Destroy(graphic, 0.26f);
        }
    }
}
