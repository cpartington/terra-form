using System.Linq;

/// <summary>
/// Constants for terrain grid
/// </summary>
public static class Constants
{
    public const int GridXLength = 150;
    public const int GridZLength = 270;
    public const int GridCellSize = 1;
    public const float GridCellHeight = 0.5f;
    public const float GridNoiseScale = 0.03f;
    public const float TerrainHeightOffset = 1;

    public const int TerrainLevels = 15;
    public static readonly int[] TerrainTypeWeights = { 10, 15, 10, 40, 20 };

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