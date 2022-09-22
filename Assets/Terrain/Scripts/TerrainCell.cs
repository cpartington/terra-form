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
            if (noiseValue <= levelPercentiles[i])
            {
                this.y = i;
                break;
            }
        }

        this.type = TerrainComputer.Instance.LevelToTerrainType.GetValueOrDefault(this.y);
    }
}