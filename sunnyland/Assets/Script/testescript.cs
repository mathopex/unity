using UnityEngine;

public class testescript : MonoBehaviour
{
    public GameObject graphic
        ;

   
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.CompareTag("Player"))
        {
            Destroy(graphic);
        }
    }
}
