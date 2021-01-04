using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Inventory : MonoBehaviour
{
    public int coinsCount;
    public static Inventory instance;
    public Text coinsCountTexte;
    public List<Item> content = new List<Item>();
    private int index = 0;
    public Image itemUIimage;
    public Sprite emptyUIimage;
    public Text ItemNameUI;

    public PlayerEffet playerEffet;
    private void Awake()
    {
        if (instance != null)
        {
            Debug.LogWarning("il y a plus d'un instance de inventory dans cette scene");
            return;
        }

        instance = this;
    }

    private void Start()
    {
        UpdateInventoryUI();
    }


    public void UseItem()
    {
        if (content.Count == 0)
        {
            return;
        }
        Item currentItem = content[index];
        PlayerHealth.instance.HealPlayer(currentItem.potionHeal);
        playerEffet.AddSpeed(currentItem.speedBoost, currentItem.speedDuration);
        content.Remove(currentItem);
        GetNextItem();
        UpdateInventoryUI();
    }

    public void GetNextItem()
    {

        if (content.Count == 0)
        {
            return;
        }
        index++;

        if (index > content.Count - 1)
        {
            index = 0;
        }
        UpdateInventoryUI();
    }

    public void GetPreviousItem()
    {
        if (content.Count == 0)
        {
            return;
        }
        index--;
        if (index < 0)
        {
            index = content.Count - 1;
        }
        UpdateInventoryUI();
    }

    public void UpdateInventoryUI()
    {
        if( content.Count > 0)
        {
            itemUIimage.sprite = content[index].image;
            ItemNameUI.text = content[index].name;
        }
        else
        {
            itemUIimage.sprite = emptyUIimage;
            ItemNameUI.text = "";
        }
    }

    public void AddCoins(int count)
    {
        coinsCount += count;
        UpdateTextUI();
    }

    public void RemoveCoin(int count)
    {
        coinsCount -= count;
        UpdateTextUI();
    }

    public void UpdateTextUI()
    {
        coinsCountTexte.text = coinsCount.ToString();
    }
    
    public void ItemNull()
    {
        if (content.Count == 0)
        {
            return;
        }
    }
}
