using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

public class TerrainComputer
{
    private int TerrainLevels = Constants.TerrainLevels;
    private int[] TerrainTypeWeights = Constants.TerrainTypeWeights;

    public static TerrainComputer Instance { 
        get
        {
            if (_Instance == null)
            {
                _Instance = new TerrainComputer();
            }
            return _Instance;
        }
    }
    public static TerrainComputer _Instance;

    public float[] TerrainTypePercentiles { get; private set; }
    public float[] TerrainLevelPercentiles { get; private set; }
    public int WaterLevel { get; private set; }

    public Dictionary<int, TerrainType> LevelToTerrainType { get; private set; }

    private TerrainComputer()
    {
        float scale = (float)(TerrainLevels - 1) / (TerrainTypeWeights.Length - 1);
        float[] scaledIndices = new float[TerrainTypeWeights.Length];
        for (int i = 0; i < TerrainTypeWeights.Length; i++)
        {
            scaledIndices[i] = i * scale;
        }

        float[] terrainLevelWeights = new float[TerrainLevels];
        terrainLevelWeights[0] = TerrainTypeWeights[0];
        for (int i = 1; i < TerrainLevels; i++)
        {
            for (int j = 0; j < scaledIndices.Length; j++)
            {
                if (i <= scaledIndices[j])
                {
                    float biggerIndex = scaledIndices[j];
                    float smallerIndex = scaledIndices[j - 1];

                    int bigWeight = TerrainTypeWeights[j];
                    int smallWeight = TerrainTypeWeights[j - 1];

                    float bigDist = Math.Abs(i - biggerIndex);
                    float smallDist = Math.Abs(i - smallerIndex);

                    float interpolatedWeight = ((bigWeight * bigDist) + (smallWeight * smallDist)) / (bigDist + smallDist);
                    terrainLevelWeights[i] = interpolatedWeight;
                }
            }
        }

        float terrainlevelWeightTotal = terrainLevelWeights.Sum();
        TerrainLevelPercentiles = terrainLevelWeights.Select((weight, index) =>
        { return (weight + terrainLevelWeights.Take(index).Sum()) / terrainlevelWeightTotal; }).ToArray();

        float terrainTypeWeightTotal = TerrainTypeWeights.Sum();
        TerrainTypePercentiles = TerrainTypeWeights.Select((weight, index) =>
        { return (weight + TerrainTypeWeights.Take(index).Sum()) / terrainTypeWeightTotal; }).ToArray();

        this.LevelToTerrainType = new Dictionary<int, TerrainType>();
        TerrainType lastType = TerrainType.DeepWater;
        for (int level = 0; level < TerrainLevels; level++)
        {
            float percentile = level / ((float)TerrainLevels - 1);
            for (int type = 0; type < TerrainTypePercentiles.Length; type++)
            {
                if (percentile <= TerrainTypePercentiles[type])
                {
                    TerrainType terrainType = (TerrainType)type;
                    this.LevelToTerrainType.Add(level, terrainType);
                    
                    if (lastType == TerrainType.ShallowWater && terrainType == TerrainType.LowGround)
                    {
                        WaterLevel = level;
                    }
                    lastType = terrainType;
                    
                    break;
                }
            }
        }

        UnityEngine.Debug.Log(WaterLevel + ", " + LevelToTerrainType);
    }
}
