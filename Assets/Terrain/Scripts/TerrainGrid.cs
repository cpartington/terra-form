using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;
using Debug = UnityEngine.Debug;
using Random = UnityEngine.Random;

public class TerrainGrid : MonoBehaviour
{
    public static TerrainGrid Instance { get; private set; }

    public GameObject groundPrefab;

    public int xLength { get; private set; }
    public int zLength { get; private set; }

    private Vector3 originPosition;
    private TerrainCell[,] gridArray;

    private void Awake()
    {
        Instance = this;

        Stopwatch stopwatch = new Stopwatch();
        stopwatch.Start();

        this.xLength = Constants.GridXLength;
        this.zLength = Constants.GridZLength;
        this.originPosition = new Vector3(-(this.xLength / 2), 0, -(this.zLength / 2));

        this.gridArray = new TerrainCell[xLength, zLength];
        (float xOffset, float yOffset) = (Random.Range(-10000f, 10000f), Random.Range(-10000f, 10000f));
        for (int x = 0; x < gridArray.GetLength(0); x++)
        {
            for (int z = 0; z < gridArray.GetLength(1); z++)
            {
                // Get height value
                float noiseValue = Mathf.PerlinNoise(x * Constants.GridNoiseScale + xOffset, z * Constants.GridNoiseScale + yOffset);

                // Create cell
                var cell = new TerrainCell(x, z, noiseValue);
                gridArray[x, z] = cell;

                // Create prefab
                Vector3 location = GetWorldPosition(x, cell.y, z);
                var groundObject = Instantiate(groundPrefab, location, Quaternion.identity);
                groundObject.transform.localScale = new Vector3(1, (cell.y + Constants.TerrainHeightOffset) * Constants.GridCellHeight, 1);
            }
        }

        stopwatch.Stop();
        Debug.Log($"{this.xLength * this.zLength} cells loaded in {stopwatch.Elapsed} seconds.");
    }

    public Vector3 GetWorldPosition(int x, int z)
    {
        var v = new Vector3(x, 0, z) * Constants.GridCellSize + originPosition;
        v.x += Constants.GridCellSize / 2;
        v.z += Constants.GridCellSize / 2;
        return v;
    }

    public Vector3 GetWorldPosition(int x, int y, int z, bool isWater=false)
    {
        var v = GetWorldPosition(x, z);
        if (isWater)
        {
            float waterHeight = (TerrainComputer.Instance.WaterLevel - y) * Constants.GridCellHeight;
            v.y = (y + Constants.TerrainHeightOffset) * Constants.GridCellHeight + (waterHeight / 2);
        }
        else
        {
            v.y = (y + Constants.TerrainHeightOffset) * Constants.GridCellHeight / 2;
        }
        return v;
    }

    public TerrainCell GetTerrainCell(Vector3 worldPosition)
    {
        Vector3 gridVector = (worldPosition - originPosition) / Constants.GridCellSize;
        return this.gridArray[(int)gridVector.x, (int)gridVector.z];
    }
}