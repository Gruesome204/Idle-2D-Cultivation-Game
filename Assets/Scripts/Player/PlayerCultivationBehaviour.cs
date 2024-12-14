using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Xml.Linq;

public class PlayerCultivationBehaviour : MonoBehaviour
{
    [SerializeField] private GlobalGameDataSO globalGameDataSO;

    public void AddExperience()
    {
        if (globalGameDataSO.currentEnergy <= globalGameDataSO.energyToNextLevel)
        {
            globalGameDataSO.currentEnergy += globalGameDataSO.energyGainSecond * Time.deltaTime;
        }
        else
        {
            LevelUp();
        }
    }

    private void UpdateExperienceToNextLevel()
    {
        globalGameDataSO.energyToNextLevel += globalGameDataSO.PlayerRealmLevel * 100;
    }

    private void LevelUp()
    {
        double modifiedSuccess = globalGameDataSO.successChance + (globalGameDataSO.failedAttempts * 0.05);
        double chance = Math.Min(modifiedSuccess, 1.0); // Cap at 100%
        bool success = UnityEngine.Random.value <= chance;

        if (success)
        {
            globalGameDataSO.currentEnergy -= globalGameDataSO.energyToNextLevel;
            globalGameDataSO.PlayerRealmLevel += 1;
            globalGameDataSO.successChance = 0f;
            UpdateExperienceToNextLevel();
            Debug.Log($"{globalGameDataSO.characterClass.className} leveled up to level {globalGameDataSO.currentEnergy}!");

        }
        else
        {
            globalGameDataSO.failedAttempts++;
            globalGameDataSO.successChance += 0.1f;
            Debug.Log($"{globalGameDataSO.playerName} failed to break through. Failed attempts: {globalGameDataSO.failedAttempts}");
            globalGameDataSO.currentEnergy -= globalGameDataSO.energyToNextLevel;
        }
    }

    void Update()
    {
        if (globalGameDataSO.currentGameState == GlobalGameDataSO.GameState.Play)
        {
            AddExperience();

        }
    }
    }
