using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[Serializable]
public class Aggro : MonoBehaviour
{
   [SerializeField]public Dictionary<GameObject, float> aggroTable = new Dictionary<GameObject, float>();

    public void AddAggro(GameObject source, float amount)
    {
        if (aggroTable.ContainsKey(source))
        {
            aggroTable[source] += amount;
        }
        else
        {
            aggroTable[source] = amount;
        }
    }

    public void ReduceAggro(float decayRate)
    {
        List<GameObject> keys = new List<GameObject>(aggroTable.Keys);
        foreach (GameObject key in keys)
        {
            aggroTable[key] -= decayRate * Time.deltaTime;
            if (aggroTable[key] <= 0)
            {
                aggroTable.Remove(key);
            }
        }
    }


    public GameObject GetHighestAggroTarget()
    {
        GameObject highestTarget = null;
        float maxAggro = 0;

        foreach (var entry in aggroTable)
        {
            if (entry.Value > maxAggro)
            {
                maxAggro = entry.Value;
                highestTarget = entry.Key;
            }
        }
        return highestTarget;
    }
}
