using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RessourceInteractable : MonoBehaviour, IClickable
{

   [SerializeField] GlobalGameDataSO globalGameDataSO;

    public void Interact()
    {
        int crystalNum = Random.Range(1, 4);
        globalGameDataSO.spiritualCrystals += crystalNum;
        Debug.Log($"Test Ressource Interaction, Player recieves: {crystalNum}" );
    }






}
