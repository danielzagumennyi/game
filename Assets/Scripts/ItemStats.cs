using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="Item Data", menuName = "Items/Item")]
public class ItemStats : ScriptableObject
{
    public enum ItemType
    {
        Weapon,
        SecondWeapon,
        Amulet,
        Armor,
        Any
    }

    public string itemName;
    public Sprite itemIcon;
    public int health;
    public int mana;
    public int healthRegen;
    public int manaRegen;
    public int attackDamage;
    public float attackSpeed;
    public int armor;
    public float critChance;
    public ItemType type;
}
