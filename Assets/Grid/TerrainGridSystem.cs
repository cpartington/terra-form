using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class TerrainGridSystem : MonoBehaviour
{
    public static TerrainGridSystem Instance { get; private set; }

    public GameObject groundPrefab;

    private TerrainGrid grid;

    private void Awake()
    {
        Instance = this;

        this.grid = new TerrainGrid();
        for (int x = 0; x < grid.xLength; x++)
        {
            for (int z = 0; z < grid.zLength; z++)
            {
                Vector3 location = grid.GetWorldPosition(x, z);
                location.x += 0.5f;
                location.z += 0.5f;
                Instantiate(groundPrefab, location, Quaternion.identity);
            }
        }
    }
}
