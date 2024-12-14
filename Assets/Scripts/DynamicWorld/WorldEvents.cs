using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldEvents : MonoBehaviour
{
    [SerializeField] GlobalGameDataSO globalGameDataSO;
    void Start()
    {
        StartCoroutine(TriggerRandomEvents());
    }

    private IEnumerator TriggerRandomEvents()
    {
        while (globalGameDataSO.worldEventsActive)
        {
            yield return new WaitForSeconds(globalGameDataSO.worldEventIntervall);

            int randomEvent = UnityEngine.Random.Range(0, 2);
            switch (randomEvent)
            {
                case 0:
                 // OnRareTreasureFound?.Invoke();
                    Debug.Log("A rare treasure has been found!");
                    break;
                case 1:
                    //   OnEnemyAttack?.Invoke();
                    Debug.Log("An enemy is attacking!");
                    break;
            }
        }
    }
}
