using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileProcedualGeneration : MonoBehaviour
{
 public GameObject tilePrefab;
    public int width = 10;
    public int height = 10;

    void Start()
    {
        GenerateGrid();
    }

    void GenerateGrid()
    {
        for (int x = 0; x < width; x++)
        {
            for (int z = 0; z < height; z++)
            {
                Vector3 position = new Vector3(x, 0, z);
                Instantiate(tilePrefab, position, Quaternion.identity);
            }
        }
    }
}
