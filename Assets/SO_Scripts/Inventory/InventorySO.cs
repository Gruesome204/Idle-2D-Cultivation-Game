using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.Progress;

[CreateAssetMenu(fileName = "New Inventory", menuName = "RPG/Inventory/Create Inventory")]
public class InventorySO : ScriptableObject
{
    public List<InventorySlot> inventorySlots = new List<InventorySlot>();
    public int maxSlots = 20;
    public bool AddItem(ItemDataSO itemData, int quantity)
    {
        // Check if the item already exists in a slot
        foreach (var slot in inventorySlots)
        {
            if (slot.itemData == itemData && itemData.isStackable)
            {
                slot.AddQuantity(quantity);
                return true;
            }
        }

        // Add the item to a new slot if there is space
        if (inventorySlots.Count < maxSlots)
        {
            inventorySlots.Add(new InventorySlot(itemData, quantity));
            return true;
        }

        // Inventory is full
        Debug.Log("Inventory is full!");
        return false;
    }

    public void RemoveItem(ItemDataSO itemData, int quantity)
    {
        for (int i = 0; i < inventorySlots.Count; i++)
        {
            if (inventorySlots[i].itemData == itemData)
            {
                inventorySlots[i].quantity -= quantity;
                if (inventorySlots[i].quantity <= 0)
                {
                    inventorySlots[i].ClearSlot();
                    inventorySlots.RemoveAt(i);
                }
                return;
            }
        }
    }
}