using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Consumable : Item
{
    public int HP { get; set; }
    public int SAN { get; set; }

    public Consumable(int id, string name, ItemType type, ItemQuality quality, string description, int capacity,
        int buyPrice, int sellPrice, string sprite, int hp,int san):base(id,name,type,quality,description,capacity,buyPrice,sellPrice,sprite)
    {
        this.HP = hp;
        this.SAN = san;
    }

    public override string GetToolTipText()
    {
        string text = base.GetToolTipText();
        string newText = string.Format("{0}\nRecoveryHP: <color=red>{1}</color>\nRecoverySAN: <color=#006400>{2}</color>",
            text, HP, SAN);

        return newText;
    }

    public override string ToString()
    {
        string s = "";
        s += ID.ToString();
        s += Type;
        s += Quality;
        s += Description;
        s += Capacity;
        s += BuyPrice;
        s += SellPrice;
        s += Sprite;
        s += HP;
        s += SAN;
        return s;
    }
}
