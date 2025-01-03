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

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            switch (globalGameDataSO.currentGameState)
            {
                case GlobalGameDataSO.GameState.Play:
                    globalGameDataSO.currentGameState = GlobalGameDataSO.GameState.Pause;
                    Debug.Log("Game Pause");
                    return;
                case GlobalGameDataSO.GameState.Pause:
                    globalGameDataSO.currentGameState = GlobalGameDataSO.GameState.Play;
                    Debug.Log("Game Continue");
                    return;
            }
        }

        switch (globalGameDataSO.currentGameState)
        {
            case GlobalGameDataSO.GameState.Play:
                playerMovementScript.enabled = true;

                return;
            case GlobalGameDataSO.GameState.Pause:
                playerMovementScript.enabled = false;

                return;
            case GlobalGameDataSO.GameState.None:


                return;

        }   
    }
}
