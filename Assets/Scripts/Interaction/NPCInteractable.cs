using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCInteractable: MonoBehaviour, IClickable
{
    [SerializeField] private GlobalGameDataSO globalGameDataSO;
    [SerializeField] private GameObject NPCConversationGUI;

    public void Interact()
    {
            Debug.Log("Test NPC Interaction");
            NPCConversationGUI.SetActive(true);

          
    }
}
