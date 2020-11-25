using UnityEngine;

public class PickUpCherry : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Healing(1);
            Destroy(gameObject);
        }
    }



    public void Healing(int Hp)
    {
        PlayerInfo.instance.heal += Hp;

        if (PlayerInfo.instance.heal == 3)
        {
            PlayerInfo.instance.vie3.SetActive(true);
        }
        else if (PlayerInfo.instance.heal == 2)
        {
            PlayerInfo.instance.vie2.SetActive(true);
        }

    }
}
