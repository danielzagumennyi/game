using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldItem : MonoBehaviour
{
    public ItemStats item;
    public int count;

    private void OnTriggerEnter(Collider other)
    {
        EquipmentController equipment = other.GetComponent<EquipmentController>();

        if (equipment)
        {
            bool added = equipment.AddItem(new InventoryItem(item, count));
            if (added) Destroy(gameObject);
        }
    }
}
