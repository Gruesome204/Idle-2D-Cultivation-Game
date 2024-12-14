using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DynamicWorld : MonoBehaviour
{
    public GameObject resourcePrefab; // Prefab for resource nodes
    public GameObject npcPrefab; // Prefab for NPCs
    public Transform worldBounds; // Defines the spawn area bounds

    private List<GameObject> activeResources = new List<GameObject>();
    private List<GameObject> activeNPCs = new List<GameObject>();

    void Start()
    {
        StartCoroutine(SpawnResources());
        StartCoroutine(SpawnNPCs());
    }

    // Coroutine to spawn resources dynamically
    private IEnumerator SpawnResources()
    {
        while (true)
        {
            SpawnResourceNode("Herbs", Random.Range(10, 20));
            SpawnResourceNode("Ore", Random.Range(5, 15));
            yield return new WaitForSeconds(Random.Range(5, 10)); // Delay between spawns
        }
    }

    // Coroutine to spawn NPCs dynamically
    private IEnumerator SpawnNPCs()
    {
        while (true)
        {
            SpawnNPC("Trader", Random.Range(100, 200));
            yield return new WaitForSeconds(Random.Range(20, 30)); // Delay between spawns
        }
    }

    // Spawns a resource node at a random location
    private void SpawnResourceNode(string resourceName, int quantity)
    {
        Vector3 position = GetRandomPosition();
        GameObject resourceNode = Instantiate(resourcePrefab, position, Quaternion.identity);
        resourceNode.GetComponent<ResourceNode>().Initialize(resourceName, quantity);
        activeResources.Add(resourceNode);
    }

    // Spawns an NPC at a random location
    private void SpawnNPC(string npcType, int tradeValue)
    {
        Vector3 position = GetRandomPosition();
        GameObject npc = Instantiate(npcPrefab, position, Quaternion.identity);
        npc.GetComponent<NPC>().Initialize(npcType, tradeValue);
        activeNPCs.Add(npc);
    }

    // Gets a random position within the world bounds
    private Vector3 GetRandomPosition()
    {
        Vector3 bounds = worldBounds.localScale / 2;
        return new Vector3(
            Random.Range(-bounds.x, bounds.x),
            0,
            Random.Range(-bounds.z, bounds.z)
        ) + worldBounds.position;
    }

    // Clean up expired objects (optional)
    void Update()
    {
        CleanUpExpiredObjects(activeResources);
        CleanUpExpiredObjects(activeNPCs);
    }

    private void CleanUpExpiredObjects(List<GameObject> objects)
    {
        for (int i = objects.Count - 1; i >= 0; i--)
        {
            if (objects[i] == null)
            {
                objects.RemoveAt(i);
            }
        }
    }
}

// Resource Node script
public class ResourceNode : MonoBehaviour
{
    private string resourceName;
    private int quantity;

    public void Initialize(string resourceName, int quantity)
    {
        this.resourceName = resourceName;
        this.quantity = quantity;
    }

}

// NPC script
public class NPC : MonoBehaviour
{
    private string npcType;
    private int tradeValue;

    public void Initialize(string npcType, int tradeValue)
    {
        this.npcType = npcType;
        this.tradeValue = tradeValue;
    }


}
