using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Xml.Linq;

public class PlayerCultivationBehaviour : MonoBehaviour
{
    [SerializeField] private GlobalPlayerDataSO globalPlayerDataSO;
    [SerializeField] private GlobalGameDataSO globalGameDataSO;

    private void Start()
    {
        //Test Cultivation Behaviour
        globalPlayerDataSO.playerRealmLevel = 1;
        globalPlayerDataSO.energyGainSecond = 1;
        globalPlayerDataSO.successChance = 0.4;
    }


    public void Update()
    {
        if (globalGameDataSO.currentGameState == GlobalGameDataSO.GameState.Play)
        {
            AddExperience();
        }
    }
    public void AddExperience()
    {
        if (globalPlayerDataSO.currentEnergy <= globalPlayerDataSO.energyToNextLevel)
        {
            globalPlayerDataSO.currentEnergy += globalPlayerDataSO.energyGainSecond * Time.deltaTime;
        }
        else
        {        
            LevelUp();
        }
    }

    private void LevelUp()
    {
        double modifiedSuccess = globalPlayerDataSO.successChance + (globalPlayerDataSO.failedAttempts * 0.05);
        double chance = Math.Min(modifiedSuccess, 1.0); // Cap at 100%
        bool success = UnityEngine.Random.value <= chance;

        if (success)
        {
            LevelUpSuccessfull();
        }
        else
        {
            LevelUpNotSuccessfull();
        }
    }

    private void UpdateExperienceToNextLevel()
    {
        globalPlayerDataSO.energyToNextLevel += globalPlayerDataSO.playerRealmLevel * 100;
    }

    private void LevelUpSuccessfull()
    {
        globalPlayerDataSO.currentEnergy -= globalPlayerDataSO.energyToNextLevel;
        globalPlayerDataSO.playerRealmLevel += 1;
        globalPlayerDataSO.successChance = 0.2f;
        UpdateExperienceToNextLevel();
        Debug.Log($"{globalPlayerDataSO.characterClass.baseClassName} leveled up to level {globalPlayerDataSO.playerRealmLevel}!");
    }

    private void LevelUpNotSuccessfull()
    {
        globalPlayerDataSO.failedAttempts++;
        globalPlayerDataSO.successChance += 0.1f;
        Debug.Log($"{globalPlayerDataSO.playerName} failed to break through. Failed attempts: {globalPlayerDataSO.failedAttempts}");
        globalPlayerDataSO.currentEnergy -= globalPlayerDataSO.energyToNextLevel;
    }
}
