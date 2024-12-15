using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[System.Serializable]
//Stored Player Data Global Accessable
[CreateAssetMenu(fileName = "GlobalGameDataSO")]
public class GlobalGameDataSO : ScriptableObject
{

    //Player Info
    [Header("Player Info")]
    [SerializeField] public string playerName;
	[SerializeField] public string playerAge;
    [SerializeField] public string playerTitle;
    [SerializeField] public int titleBonus;
    [SerializeField] public int currentFame;
    [SerializeField] public string Sect;

    public string PlayerName { get => playerName; set => playerName = value; }
    public int CurrentFame { get => currentFame; set => currentFame = Mathf.Max(0, value); }


    //Player Class/Equipment
    [Header("Player Class/Equipment")]
    public RPGClassAsset characterClass;
    public RPGCultivationTechniqueAsset cultivationTechnique;
    [SerializeField] public int cultivationTechniqueLevel;
    public RPGEquipmentAsset equippedItem;


    [Header("Realm & Level(1-9)")]
    [SerializeField] private Realms playerRealm;
    [SerializeField] public int playerRealmLevel;

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

    [Header("WorldEvents")]
    [SerializeField] public bool worldEventsActive;
    [SerializeField] public int worldEventIntervall;

    [Header("WorldGeneration")]
    [SerializeField] public BaseAncientRuinData[] ancientRuinListe;
    [SerializeField] public BaseAncientRuinData[] resourceList;
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
        playerName = "Default";
        playerRealm = Realms.Mortal;
        playerRealmLevel = 1;
        maxHealth = 0;
        currentHealth = maxHealth;
    }

    private void Awake()
    {
        ResetData();
        if (ancientRuinListe == null) ancientRuinListe = new BaseAncientRuinData[0];
        if (resourceList == null) resourceList = new BaseAncientRuinData[0];
    }


    private void OnEnable() => hideFlags = HideFlags.DontUnloadUnusedAsset;
}

