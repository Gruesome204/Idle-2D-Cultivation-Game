using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeGameState : MonoBehaviour
{
    [SerializeField] private PlayerDataSO PlayerDataSO;
    [SerializeField] private GameObject player;

    //Movement Script
    private ClickMovement playerMovementScript;
    private void Awake()
    {

        //Set Game State upon loading the Scene
        PlayerDataSO.currentGameState = PlayerDataSO.GameState.Play;

        //Reference the Movement Script of the Player
        playerMovementScript = GameObject.FindObjectOfType<ClickMovement>();

    }

    private void Update()
    {
        //Pause game
        if (PlayerDataSO.currentGameState == PlayerDataSO.GameState.Pause)
        {
            playerMovementScript.enabled = false;
        }
        else if (PlayerDataSO.currentGameState == PlayerDataSO.GameState.Play)
        {
            playerMovementScript.enabled = true;
        }


        if (Input.GetKeyDown(KeyCode.Escape)){
            if(PlayerDataSO.currentGameState == PlayerDataSO.GameState.Play)
            {
                PlayerDataSO.currentGameState = PlayerDataSO.GameState.Pause;
                Debug.Log("Game Pause");
            }
            else
            {
                PlayerDataSO.currentGameState = PlayerDataSO.GameState.Play;
                Debug.Log("Game Continue");
            }   
        }
        

    }
}
