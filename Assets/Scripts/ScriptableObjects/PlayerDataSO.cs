using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "PlayerDataSO")]
public class PlayerDataSO : ScriptableObject
{

    //Stored Player Data
    [Header("Player")]
    [SerializeField] public string playerName;
	[SerializeField] public string playerAge;
    [SerializeField] public string playerTitle;
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
    [SerializeField] public int currentTribulationEnergy;

    [Header("Cultivation Spezialization")]
    [SerializeField] public Specialization CultivationSpecialization;
	
	
	[Header("Values")]
	[SerializeField] public int currentMoney;

    //Stats of the player
    [Header("Player Stats")]
    [SerializeField] public float currentSpiritualEnergy;
    [SerializeField] public float energyPerSecond;
    [SerializeField] public int spiritualEnergyToNextLevel;


    //XP for learning/upgrading techniques...
    [SerializeField] public int currentInsight;
    [SerializeField] public int currentHealth;
    [SerializeField] public int maxHealth;
    [SerializeField] public int titleBonus;
     [SerializeField] public int currentAttack;
    [SerializeField] public int currentDefense;
    [SerializeField] public float currentAttackSpeed;

	
	

    private enum Realms
    {
        None,
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
		None,
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
        currentSpiritualEnergy = 0;
        playerName = "";
        currentGameState = GameState.None;
    }
    private void OnEnable() => hideFlags = HideFlags.DontUnloadUnusedAsset;
}
