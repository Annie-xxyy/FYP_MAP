using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Equipment : Item
{
    public int Strength { get; set; }
    public int Intelligence { get; set; }
    public int Agility { get; set; }
    public int Vitality { get; set; }
    public EqupimentType EquipType { get; set; }

    public Equipment(int id, string name, ItemType type, ItemQuality quality, string description, int capacity,
        int buyPrice,int sellPrice,string sprite,
         int strength, int intelligence, int agility, int vitality, EqupimentType equipType) 
        : base(id, name, type, quality, description, capacity, buyPrice, sellPrice,sprite)
    {
        this.Strength = strength;
        this.Intelligence = intelligence;
        this.Agility = agility;
        this.Vitality = vitality;
        this.EquipType = equipType;
    }
    
    public override string GetToolTipText()
    {
        string text = base.GetToolTipText();
        string newText = string.Format("{0}\nStrength: {1}\nIntelligence: {2}\nAgility: {3}\nVitality: {4}\nEquipPart: {5}",
            text, Strength, Intelligence,Agility,Vitality,EquipType);
        return newText;
    }
    public enum EqupimentType
    {
        Helmet,
        Chest,
        Gloves,
        Pants,
        Shoes,
    }
}
