using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.Progress;

[CreateAssetMenu(fileName = "GlobalPlayerInventorySO", menuName = "Global Data/Create GlobalPlayerInventorySO")]
public class GlobalPlayerInventorySO : ScriptableObject
{
    [Header("Player Ressource Inventory")]
    [SerializeField] public int herbs;
    [SerializeField] public int spiritualCrystals;
    [SerializeField] public int ore;


}