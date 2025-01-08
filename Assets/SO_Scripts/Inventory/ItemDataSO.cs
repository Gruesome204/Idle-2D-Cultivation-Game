using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New ItemData", menuName = "RPG/Inventory/Create ItemData")]
public class ItemDataSO : ScriptableObject
{
    public string itemName;
    public Sprite icon;
    [TextArea]
    public string description;
    public bool isStackable;
    public int maxStackSize = 1;
}
