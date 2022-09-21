using System.Linq;

/// <summary>
/// Constants for terrain grid
/// </summary>
public static class GridConstants
{
    public const int GridXLength = 100;
    public const int GridZLength = 100;
    public const int GridCellSize = 1;
    public const float GridNoiseScale = 0.05f;
}

public enum TerrainType
{
    DeepWater,
    ShallowWater,
    LowGround,
    MidGround,
    HighGround
}