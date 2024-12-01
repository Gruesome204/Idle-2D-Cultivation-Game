using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectInteractable: MonoBehaviour, IClickable
{

    [SerializeField] private GameObject NPCConversationGUI;

    public void Interact()
    {
            Debug.Log("Test Interaction");

            NPCConversationGUI.gameObject.SetActive(true);
    }

    // Detect when the player is in range of the NPC





}
