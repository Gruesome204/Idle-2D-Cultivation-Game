using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "GlobalGameDataSO")]
public class GlobalGameDataSO : ScriptableObject
{

    //Stored Player Data
    [Header("Player Info")]
    [SerializeField] public string playerName;
	[SerializeField] public string playerAge;
    [SerializeField] public string playerTitle;
    [SerializeField] public int titleBonus;
    [SerializeField] public int currentFame;
    [SerializeField] public string Sect;


    //Player Class/Equipment
    [Header("Player Class/Equipment")]
    public RPGClassAsset characterClass;
    public RPGCultivationTechniqueAsset cultivationTechnique;
    [SerializeField] public int cultivationTechniqueLevel;
    public RPGEquipmentAsset equippedItem;


    [Header("Realm & Level(1-9)")]
    [SerializeField] private Realms PlayerRealm;
    [SerializeField] public int PlayerRealmLevel;

    //player needs enough of tribulation energy to breakthrough to the next major realm..
    [SerializeField] public double successChance;
    [SerializeField] public int failedAttempts;

    [Header("Cultivation Spezialization")]
    [SerializeField] public Specialization CultivationSpecialization;
	
	[Header("Values")]
	[SerializeField] public int currentMoney;

    //Stats of the player
    [Header("Player Stats")]
    [SerializeField] public float currentEnergy;
    [SerializeField] public float energyGainSecond;
    [SerializeField] public int energyToNextLevel;

    [SerializeField] public int maxHealth;
    [SerializeField] public int currentHealth;
    [SerializeField] public int currentAttack;
    [SerializeField] public int currentDefense;
    [SerializeField] public float currentAttackSpeed;


    //XP for learning/upgrading techniques...
    [Header("Player Techniques")]
    [SerializeField] public int currentInsight;

    [Header("Player Ressource Inventory")]
    [SerializeField] public int herbs;
    [SerializeField] public int spiritualCrystals;
    [SerializeField] public int ore;
    private enum Realms
    {
        Mortal,
        Disciple,
        Foundation,
        CoreFormation,
        NascentSoul,
        SoulFormation,
        Ascension,
        Venerable,
        Immortal,
        MartialLord,
        MartialEmperor,
        MartialSovereign
    }
	
	public enum Specialization
	{
		BodyCultivation,
		SoulCultivation,
		ElementalCultivation
	}
	
    public enum GameState
    {
        None,
        Pause,
        Play
    }       

    [Header("Game-State")]
    public GameState currentGameState;
       
    public void ResetData()
    {
        currentEnergy = 0;
        playerName = "";
        currentGameState = GameState.None;
    }

    [Header("WorldEvents")]
    [SerializeField] public bool worldEventsActive;
    [SerializeField] public int  worldEventIntervall;


    private void OnEnable() => hideFlags = HideFlags.DontUnloadUnusedAsset;
}
