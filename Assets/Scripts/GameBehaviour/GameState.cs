using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameState : MonoBehaviour
{
    [SerializeField] private PlayerDataSO PlayerDataSO;

    private void Awake()
    {

        //Set Game State upon loading the Scene
        PlayerDataSO.currentGameState = PlayerDataSO.GameState.Play;

    }

    private void Update()
    {
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
