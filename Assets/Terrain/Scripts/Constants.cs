using System.Linq;
using UnityEngine;

/// <summary>
/// Constants for terrain grid
/// </summary>
public static class Constants
{
    public static int GridXLength = 150;
    public static int GridZLength = 270;
    public static int GridCellSize = 1;
    public static float GridCellHeight = 0.5f;
    public static float GridNoiseScale = 0.01f;
    public const float TerrainHeightOffset = 1;

    public static int TerrainLevels = 50;
    //public static readonly int[] TerrainTypeWeights = { 10, 15, 10, 40, 20 };
    public static int[] TerrainTypeWeights = { 1, 1, 4, 5, 4 };

    public const TerrainType MaxWaterType = TerrainType.LowGround;
}

public enum TerrainType
{
    DeepWater,
    ShallowWater,
    LowGround,
    MidGround,
    HighGround
}