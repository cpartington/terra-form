using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TerrainController : MonoBehaviour
{
    public int Seed = -1;
    public int GridXLength = Constants.GridXLength;
    public int GridZLength = Constants.GridZLength;
    public int GridCellSize = Constants.GridCellSize;
    public float GridCellHeight = Constants.GridCellHeight;
    public float GridNoiseScale = Constants.GridNoiseScale;
    public int TerrainLevels = Constants.TerrainLevels;
    public int[] TerrainTypeWeights = Constants.TerrainTypeWeights;

    private void Awake()
    {
        Constants.GridXLength = GridXLength;
        Constants.GridZLength = GridZLength;
        Constants.GridCellSize = GridCellSize;
        Constants.GridCellHeight = GridCellHeight;
        Constants.GridNoiseScale = GridNoiseScale;
        Constants.TerrainLevels = TerrainLevels;
        Constants.TerrainTypeWeights = TerrainTypeWeights;

        if (Seed == -1)
        {
            Seed = UnityEngine.Random.Range(0, Int32.MaxValue);
        }
        UnityEngine.Random.InitState(Seed);
    }
}
