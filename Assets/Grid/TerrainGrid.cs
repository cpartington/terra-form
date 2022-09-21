using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;
using Debug = UnityEngine.Debug;

public class TerrainGrid : MonoBehaviour
{
    public static TerrainGrid Instance { get; private set; }

    public GameObject groundPrefab;

    public int xLength { get; private set; }
    public int zLength { get; private set; }

    private int cellSize;
    private Vector3 originPosition;
    private TerrainCell[,] gridArray;

    private void Awake()
    {
        Instance = this;

        Stopwatch stopwatch = new Stopwatch();
        stopwatch.Start();

        this.xLength = GridConstants.GridXLength;
        this.zLength = GridConstants.GridZLength;
        this.cellSize = GridConstants.GridCellSize;
        this.originPosition = new Vector3(-(this.xLength / 2), 0, -(this.zLength / 2));
        Debug.Log(this.originPosition);

        this.gridArray = new TerrainCell[xLength, zLength];
        for (int x = 0; x < gridArray.GetLength(0); x++)
        {
            for (int z = 0; z < gridArray.GetLength(1); z++)
            {
                gridArray[x, z] = new TerrainCell(this, x, z);
                Vector3 location = GetWorldPosition(x, z);
                location.x += cellSize / 2;
                location.z += cellSize / 2;
                Instantiate(groundPrefab, location, Quaternion.identity);
            }
        }

        stopwatch.Stop();
        Debug.Log($"{this.xLength * this.zLength} cells loaded in {stopwatch.Elapsed} seconds.");

        bool showDebug = false;
        if (showDebug)
        {
            for (int x = 0; x < gridArray.GetLength(0); x++)
            {
                for (int z = 0; z < gridArray.GetLength(1); z++)
                {
                    Debug.DrawLine(GetWorldPosition(x, z), GetWorldPosition(x, z + 1), Color.white, 100f);
                    Debug.DrawLine(GetWorldPosition(x, z), GetWorldPosition(x + 1, z), Color.white, 100f);
                }
            }
            Debug.DrawLine(GetWorldPosition(0, zLength), GetWorldPosition(xLength, zLength), Color.white, 100f);
            Debug.DrawLine(GetWorldPosition(xLength, 0), GetWorldPosition(xLength, zLength), Color.white, 100f);
        }
    }

    public Vector3 GetWorldPosition(int x, int z)
    {
        return new Vector3(x, 0, z) * cellSize + originPosition;
    }
}
