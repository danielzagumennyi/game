using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class InventoryItem
{
    public ItemStats Item;
    public int Count;
    public InventoryItem(ItemStats item, int count)
    {
        Item = item;
        Count = count;
    }
}
public class EquipmentController : MonoBehaviour
{
    public Sprite WeaponPlaceholder;
    public Sprite SecondWeaponPlaceholder;
    public Sprite AmuletPlaceholder;
    public Sprite ArmorPlaceholder;

    public EquipmentSlot WeaponSlot;
    public EquipmentSlot SecondWeaponSlot;
    public EquipmentSlot AmuletSlot;
    public EquipmentSlot ArmorSlot;

    ItemStats Weapon;
    ItemStats SecondWeapon;
    ItemStats Amulet;
    ItemStats Armor;

    [Header("Inventory Props")]
    public int maxInventoryItems = 5;
    public Transform inventoryGrid;
    public InventorySlot inventorySlot;

    [SerializeField] private InventoryItem[] inventoryItems;
    [SerializeField] private InventorySlot[] inventorySlots;

    private void Start()
    {
        inventoryItems = new InventoryItem[maxInventoryItems];
        inventorySlots = new InventorySlot[maxInventoryItems];
        for (int i = 0; i < maxInventoryItems; i++)
        {
            inventorySlots[i] = Instantiate(inventorySlot, inventoryGrid);
            inventorySlots[i].controller = this;
        }
    }

    private void Render()
    {
        for(int i = 0; i < inventoryItems.Length; i++)
        {
            if (inventoryItems[i] != null && inventoryItems[i].Item != null)
            {
                inventorySlots[i].SetItem(inventoryItems[i].Item.itemIcon, inventoryItems[i].Count);
            } else
            {
                inventorySlots[i].Clear();
            }
        }
    } 

    public bool AddItem(InventoryItem newItem)
    {
        bool itemAdded = false;
        for (int i = 0; i < inventoryItems.Length; i++)
        {
            if (inventoryItems[i] == null)
            {
                inventoryItems[i] = newItem;
                itemAdded = true;
                break;
            } else if (inventoryItems[i].Item == newItem.Item)
            {
                inventoryItems[i].Count += newItem.Count;
                itemAdded = true;
                break;
            }
        }
        Render();
        return itemAdded;
    }

    public void ClickItem(int index)
    {
        if (inventoryItems[index] != null)
        {
            Sprite sprite = inventoryItems[index].Item.itemIcon;
            switch (inventoryItems[index].Item.type)
            {
                case ItemStats.ItemType.Weapon:
                    WeaponSlot.SetItem(sprite);
                    break;
                case ItemStats.ItemType.SecondWeapon:
                    SecondWeapon = inventoryItems[index].Item;
                    SecondWeaponSlot.SetItem(sprite);
                    break;
                case ItemStats.ItemType.Amulet:
                    Amulet = inventoryItems[index].Item;
                    AmuletSlot.SetItem(sprite);
                    break;
                case ItemStats.ItemType.Armor:
                    Armor = inventoryItems[index].Item;
                    ArmorSlot.SetItem(sprite);
                    break;
            }
        }
        
    }

    public void RemoveItem(ItemStats.ItemType type)
    {
        switch (type)
        {
            case ItemStats.ItemType.Weapon:
                Weapon = null;
                WeaponSlot.SetItem(WeaponPlaceholder);
                break;
            case ItemStats.ItemType.SecondWeapon:
                SecondWeapon = null;
                SecondWeaponSlot.SetItem(WeaponPlaceholder);
                break;
            case ItemStats.ItemType.Amulet:
                Amulet = null;
                AmuletSlot.SetItem(AmuletPlaceholder);
                break;
            case ItemStats.ItemType.Armor:
                Armor = null;
                ArmorSlot.SetItem(ArmorPlaceholder);
                break;
        }
    }
}
