using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShopManager : MonoBehaviour
{
    public Text ShopName;
    public Animator animator;
    public GameObject ShopButtonPrefab;
    public GameObject shopUI;
    public Transform ShopButtonParent;

    public static ShopManager instance;
    // Start is called before the first frame update
    private void Awake()
    {
        if (instance != null)
        {
            Debug.LogWarning("il y a plus d'un instance de ShopManager dans cette scene");
            return;
        }

        instance = this;

    }


    public void OpenShop(Item[] items, string PnjName)
    {
        shopUI.SetActive(true);
        ShopName.text = PnjName;
        UptadeShopItem(items);
        animator.SetBool("IsOpen", true);
    }

    public void UptadeShopItem(Item[] items)
    {
        //supprime les potentielle bouton present par defaut
        for (int i = 0; i < ShopButtonParent.childCount; i++)
        {
            Destroy(ShopButtonParent.GetChild(i).gameObject);
        }

        //instancie un bouton pour chaque item et le configure
        for (int i = 0; i < items.Length; i++)
        {
            GameObject buton = Instantiate(ShopButtonPrefab, ShopButtonParent);
            ShopButtonItem butonScript = buton.GetComponent<ShopButtonItem>();
            butonScript.ItemName.text = items[i].name;
            butonScript.ItemImage.sprite = items[i].image;
            butonScript.ItemPrix.text = items[i].price.ToString();

            butonScript.item = items[i];

            //Creation d'un evenement OnClick pour le bouton avec la fontion "delegate"
            buton.GetComponent<Button>().onClick.AddListener(delegate { butonScript.BuyItem(); });
        }

    }

   public void CloseShop()
    {
        animator.SetBool("IsOpen", false);
    }
}
