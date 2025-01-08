using UnityEngine;
using UnityEngine.UI;

public class InventoryUI : MonoBehaviour
{
    public InventorySO inventorySO;
    public GameObject inventoryPanel;
    public GameObject inventorySlotPrefab;

    private void Start()
    {
        RefreshInventoryUI();
    }

    public void RefreshInventoryUI()
    {
        // Clear existing UI elements
        foreach (Transform child in inventoryPanel.transform)
        {
            Destroy(child.gameObject);
        }

        // Create new UI elements for each slot
        foreach (var slot in inventorySO.inventorySlots)
        {
            if (slot.itemData != null)
            {
                GameObject slotUI = Instantiate(inventorySlotPrefab, inventoryPanel.transform);
                Image icon = slotUI.transform.Find("Icon").GetComponent<Image>();
                Text quantityText = slotUI.transform.Find("Quantity").GetComponent<Text>();

                icon.sprite = slot.itemData.icon;
                quantityText.text = slot.quantity > 1 ? slot.quantity.ToString() : "";
            }
        }
    }
}
