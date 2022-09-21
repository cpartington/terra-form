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

    public const int DeepWater = 0;
    public const int ShallowWater = 1;
    public const int LowGround = 2;
    public const int MidGround = 3;
    public const int HighGround = 4;
}

public static class GridWeights
{
    private static readonly int[] Weights = { 10, 15, 30, 30, 20 };
    private static readonly int WeightTotal = Weights.Sum();
    public static readonly float[] Percentiles = Weights.Select((weight, index) =>
        { return (weight + Weights.Take(index).Sum()) / (float)WeightTotal; }).ToArray();
}