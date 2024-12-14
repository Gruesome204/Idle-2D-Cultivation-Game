using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCInteractable: MonoBehaviour, IClickable
{

    [SerializeField] private GameObject NPCConversationGUI;

    public void Interact()
    {
            Debug.Log("Test NPC Interaction");

            NPCConversationGUI.gameObject.SetActive(true);
    }






}
