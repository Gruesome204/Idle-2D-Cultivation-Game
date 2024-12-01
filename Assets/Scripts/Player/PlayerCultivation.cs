using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCultivation : MonoBehaviour
{
    [SerializeField] private PlayerDataSO playerDataSO;

    private void Update()
    {
        playerDataSO.currentSpiritualEnergy =+ 1 * Time.deltaTime;
    }
}
