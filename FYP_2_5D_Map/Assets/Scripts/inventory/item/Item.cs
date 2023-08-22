using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Item 
{
    public int ID { get; set; }
    public string Name { get; set; }
    public ItemType Type { get; set; }
    public ItemQuality Quality { get; set; }
    public string Description { get; set; }
    public int Capacity { get; set; }
    public int BuyPrice { get; set; }
    public int SellPrice { get; set; }
    public string Sprite { get; set; }


    public Item()
    {
        this.ID = -1;
    }

    public Item(int id, string name, ItemType type, ItemQuality quality, string description, int capacity, int buyPrice,
        int sellPrice, string sprite)
    {
        this.ID = id;
        this.Name = name;
        this.Type = type;
        this.Quality = quality;
        this.Description = description;
        this.Capacity = capacity;
        this.BuyPrice = buyPrice;
        this.SellPrice = sellPrice;
        this.Sprite = sprite;
    }
    
    public enum ItemQuality
    {
        Normal,
        Rare,
        Legendary
    }
    
    public enum ItemType
    {
        Consumable,
        Equipment,
        Weapon,
        Material
    }

    public virtual string GetToolTipText()
    {
        string color = "";
        switch (Quality)
        {
            case ItemQuality.Legendary:
                color = "#CC5500";
                break;
            case ItemQuality.Normal:
                color = "green";
                break;
            case ItemQuality.Rare:
                color = "#00559A";
                break;
        }

        string text = string.Format("<color={3}>{0}</color>\n{1}\nSell Price: <color={4}>{2}</color>", Name,
            Description, SellPrice, color,"yellow");
        return text;
    }
    
}
