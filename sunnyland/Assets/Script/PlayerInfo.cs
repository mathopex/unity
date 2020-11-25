using UnityEngine;
using UnityEngine.UI;

public class PlayerInfo : MonoBehaviour
{
    public int heal = 3;
    public GameObject vie1, vie2, vie3;
    public int NbStar;
    public Text starTexte;
    public int NbGem;
    public Text GemTexte;

    public static PlayerInfo instance;


    private void Awake()
    {
        {
            instance = this;
        }
    }

    public void HealPlayer(int hp)
    {
        heal += hp;
        
        if ( heal > 3)
        {
            heal = 3;
        }

        if (heal < 0)
        {
            heal = 0;
        }
       
    }

    public void GetStar()
    {
        NbStar++;
        starTexte.text = NbStar.ToString();

    }
    public void GetGem()
    {
        NbGem++;
        GemTexte.text = NbGem.ToString();

    }
}
