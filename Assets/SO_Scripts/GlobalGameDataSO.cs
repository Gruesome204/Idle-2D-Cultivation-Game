using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
//Stored Game Data Global Accessable
[CreateAssetMenu(fileName = "GlobalGameDataSO", menuName = "Global Data/Create GlobalGameDataSO")]
public class GlobalGameDataSO : ScriptableObject
{


    [Header("WorldEvents")]
    [SerializeField] public bool worldEventsActive;
    [SerializeField] public int worldEventIntervall;

    [Header("WorldGeneration")]
    [SerializeField] public BaseAncientRuinData[] ancientRuinListe;
    [SerializeField] public BaseAncientRuinData[] resourceList;
    
  
    public enum GameState
    {
        None,
        Pause,
        Play,
        UI,
    }       

    [Header("Game-State")]
    public GameState currentGameState;

    private void Awake()
    {
        if (ancientRuinListe == null) ancientRuinListe = new BaseAncientRuinData[0];
        if (resourceList == null) resourceList = new BaseAncientRuinData[0];
    }

    private void OnEnable() => hideFlags = HideFlags.DontUnloadUnusedAsset;
}

