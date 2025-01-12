using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
//Stored Player Data Global Accessable
[CreateAssetMenu(fileName = "GlobalPlayerDataSO", menuName = "Global Data/Create GlobalPlayerDataSO")]
public class GlobalPlayerDataSO : ScriptableObject
{
    [Header("Player Info")]
        [SerializeField] public string playerName;
        [SerializeField] public string playerTitle;
        [SerializeField] public string playerAge;
        [SerializeField] public int currentFame;
        [SerializeField] public float currentkarma;
        [SerializeField] public string currentSect;

    public string PlayerName { get => playerName; set => playerName = value; }
    public int CurrentFame { get => currentFame; set => currentFame = Mathf.Max(0, value); }


    [Header("Player Class/Equipment")]
        public RPGClassAsset characterClass;
        public RPGCultivationTechniqueAsset cultivationTechnique;
            [SerializeField] public int cultivationTechniqueLevel;
        public RPGEquipmentAsset equippedWeapon;

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

    [Header("Realm & Level(1-9)")]
        [SerializeField] private Realms playerRealm;
        [SerializeField] public int playerRealmLevel;


    [Header("Cultivation Breakthrough")]
        [SerializeField] public double successChance;
        [SerializeField] public int failedAttempts;


    public enum Specialization
    {
        BodyCultivation,
        SoulCultivation,
        ElementalCultivation
    }

    [Header("Spezialization")]
        [SerializeField] public Specialization CultivationSpecialization;
	
	[Header("Misc Values")]
	    [SerializeField] public int currentMoney;
        [SerializeField] public int titleBonus;

    //Stats of the player
    [Header("Player Stats")]

        [SerializeField] public float currentEnergy;
        [SerializeField] public float energyGainSecond;
        [SerializeField] public int energyToNextLevel;

        [SerializeField] public int maxHealth;
        [SerializeField] public int currentHealth;
        [SerializeField] public int currentAttack;
        [SerializeField] public int currentPhyiscalDefense;
        [SerializeField] public int currentMagicalDefense;
        [SerializeField] public float currentAttackSpeed;
        [SerializeField] public float damageMultiplier;
        [SerializeField] public float critChance;

    [Header("Player Resistances")]
        [SerializeField] public float statusResistance;
        [SerializeField] public float fireResistance;
        [SerializeField] public float waterResistance;
        [SerializeField] public float earthResistance;
        [SerializeField] public float lightningResistance;
        [SerializeField] public float windResistance;


    //XP for learning/upgrading techniques...
    [Header("Player Techniques")]
    [SerializeField] public int currentInsight;


    public void ResetData()
    {
        playerName = "Default";
        playerRealm = Realms.Mortal;
        playerRealmLevel = 1;
        maxHealth = 0;
        currentHealth = maxHealth;
    }



    private void OnEnable() => hideFlags = HideFlags.DontUnloadUnusedAsset;
}

