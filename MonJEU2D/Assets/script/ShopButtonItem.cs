using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShopButtonItem : MonoBehaviour
{
    public Text ItemName;
    public Image ItemImage;
    public Text ItemPrix;

    public Item item;


    public void BuyItem()
    {

        Inventory inventory = Inventory.instance;
        if( inventory.coinsCount >= item.price)
        {
            //ajoute l'item acheter dans l'inventaire
            inventory.content.Add(item);

            //mise a jour visuel de l'inventaire 
            inventory.UpdateInventoryUI();

            //on deduit le prix de l'item des pieces du joueur
            inventory.coinsCount -= item.price;

            //mise a jour du text des pieces
            inventory.UpdateTextUI();
        }
    }
}
