using UnityEngine;

[System.Serializable]
public class InventorySlot
{
    public ItemDataSO itemData;
    public int quantity;

    public InventorySlot(ItemDataSO newItem, int newQuantity)
    {
        itemData = newItem;
        quantity = newQuantity;
    }

    public void AddQuantity(int amount)
    {
        quantity += amount;
    }

    public void ClearSlot()
    {
        itemData = null;
        quantity = 0;
    }
}
