using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : Item
{
    public int Damage { get; set; }
    public WeaponType WpType { get; set; }

    public Weapon(int id, string name, ItemType type, ItemQuality quality, string description, int capacity,
        int buyPrice,int sellPrice, string sprite,  int damage, WeaponType wpType) 
        : base(id, name, type, quality, description, capacity, buyPrice, sellPrice,sprite)
    {
        this.Damage = damage;
        this.WpType = wpType;
    }
    
    public override string GetToolTipText()
    {
        string text = base.GetToolTipText();
        string newText = string.Format("{0}\nDamage: {1}\nWeaponType: {2}", text, Damage,WpType);
        return newText;
    }
    public enum WeaponType
    {
        MainHand
    }
}
