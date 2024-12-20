using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeGameState : MonoBehaviour
{
    [SerializeField] private GlobalGameDataSO globalGameDataSO;
    
    //Movement Script
    private PlayerMovementController playerMovementScript;
    private void Awake()
    {

        //Set Game State upon loading the Scene
        globalGameDataSO.currentGameState = GlobalGameDataSO.GameState.Play;

        //Reference the Movement Script of the Player
        playerMovementScript = GameObject.FindObjectOfType<PlayerMovementController>();

    }

    private void Update()
    {
        while(globalGameDataSO.currentGameState == GlobalGameDataSO.GameState.Pause)

        //Pause game
        if (globalGameDataSO.currentGameState == GlobalGameDataSO.GameState.Pause)
        {
            playerMovementScript.enabled = false;
        }
        else if (globalGameDataSO.currentGameState == GlobalGameDataSO.GameState.Play)
        {
            playerMovementScript.enabled = true;
        }


        if (Input.GetKeyDown(KeyCode.Escape)){
            if(globalGameDataSO.currentGameState == GlobalGameDataSO.GameState.Play)
            {
                globalGameDataSO.currentGameState = GlobalGameDataSO.GameState.Pause;
                Debug.Log("Game Pause");
            }
            else
            {
                globalGameDataSO.currentGameState = GlobalGameDataSO.GameState.Play;
                Debug.Log("Game Continue");
            }   
        }
        

    }
}
