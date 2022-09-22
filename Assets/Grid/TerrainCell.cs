using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TerrainCell
{
    public int x;
    public int y;
    public int z;

    public TerrainType type;

    public TerrainCell(int x, int z, float noiseValue)
    {
        this.x = x;
        this.z = z;
        
        float[] levelPercentiles = TerrainComputer.Instance.TerrainLevelPercentiles;
        for (int i = 0; i < levelPercentiles.Length; i++)
        {
            if (noiseValue < levelPercentiles[i])
            {
                this.y = i;
                break;
            }
        }

        float[] typePercentiles = TerrainComputer.Instance.TerrainTypePercentiles;
        float percentile = this.y / (float)(TerrainComputer.Instance.TerrainLevelPercentiles.Length - 1);
        for (int i = 0; i < typePercentiles.Length; i++)
        {
            if (percentile <= typePercentiles[i])
            {
                this.type = (TerrainType)i;
                break;
            }
        }
    }
}