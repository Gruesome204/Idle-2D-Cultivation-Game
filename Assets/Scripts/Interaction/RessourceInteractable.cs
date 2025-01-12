using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RessourceInteractable : MonoBehaviour, IClickable
{

    [SerializeField] private GlobalGameDataSO globalGameDataSO;
    [SerializeField] private GlobalPlayerInventorySO globalPlayerInventorySO;

    public void Interact()
    {
        int crystalNum = Random.Range(1, 4);
        globalPlayerInventorySO.spiritualCrystals += crystalNum;
        Debug.Log($"Test Ressource Interaction, Player recieves: {crystalNum}" );
    }






}
