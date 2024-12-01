using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class GameBehaviour : MonoBehaviour
{
    [SerializeField] private PlayerDataSO gameDataSO;
    [SerializeField] private GameObject player;

    //Movement Script
    private ClickMovement playerMovementScript;

    private void Awake()
    {
        //Reference the Movement Script of the Player
        playerMovementScript = GameObject.FindObjectOfType<ClickMovement>();
    }
    private void Update()
    {

        //Pause game
        if (gameDataSO.currentGameState == PlayerDataSO.GameState.Pause)
        {
            playerMovementScript.enabled = false;
        }
        else if (gameDataSO.currentGameState == PlayerDataSO.GameState.Play)
        {
            playerMovementScript.enabled = true;
        }
    }
}
