
using UnityEngine;

[CreateAssetMenu(fileName = "item",menuName ="Iventory/Item")]
public class Item : ScriptableObject
{

    public int id;
    public string names;
    public string description;
    public Sprite image;
    public int speedBoost;
    public int attaqueBoost;
    public float speedDuration;
    public float attaqueDuration;
    public int potionHeal;
    public int price;
}
