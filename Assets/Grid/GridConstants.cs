using System.Linq;

/// <summary>
/// Constants for terrain grid
/// </summary>
public static class GridConstants
{
    public const int GridXLength = 200;
    public const int GridZLength = 200;
    public const int GridCellSize = 1;
    public const float GridNoiseScale = 0.03f;

    public const int TerrainLevels = 15;
    public static readonly int[] TerrainTypeWeights = { 10, 15, 10, 40, 20 };
}

public enum TerrainType
{
    DeepWater,
    ShallowWater,
    LowGround,
    MidGround,
    HighGround
}