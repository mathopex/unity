using UnityEngine;


public class PickupCoin : MonoBehaviour
{

    public AudioClip sound;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //ajout des pieces
        if (collision.transform.CompareTag("Player"))
        {
            AudioManager.instance.PlayClipAt(sound, transform.position);
            GameObject.Find("Inventory").GetComponent<Inventory>().AddCoins(1);
            Destroy(gameObject); 
        }
    }
}
