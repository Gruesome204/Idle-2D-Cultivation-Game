using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NPCConversationGUIBehaviour : MonoBehaviour
{
    [SerializeField] private GlobalGameDataSO globalGameDataSO;
    [SerializeField] private Button closeGUI;

    private void Awake()
    {
        // Ensure the interaction panel is hidden at the start
        this.gameObject.SetActive(false);
    }

    void Start()
    {
        closeGUI.onClick.AddListener(() => CloseGUI());
    }

    void CloseGUI()
    {
        this.gameObject.SetActive(false);

    }
}
