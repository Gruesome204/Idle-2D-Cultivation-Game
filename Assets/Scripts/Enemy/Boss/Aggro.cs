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
            //Debug.Log($"Decay Rate: {aggroTable[key]}");
            if (aggroTable[key] <= 0)
            {
                aggroTable.Remove(key);
            }
        }
    }

    private void Update()
    {

        ReduceAggro(decayRate: 1.0f);
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
