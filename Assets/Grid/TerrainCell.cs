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
        
        float[] LevelPercentiles = TerrainComputer.Instance.TerrainLevelPercentiles;
        for (int i = 0; i < LevelPercentiles.Length; i++)
        {
            if (noiseValue < LevelPercentiles[i])
            {
                this.y = i;
                break;
            }
        }

        float[] TypePercentiles = TerrainComputer.Instance.TerrainTypePercentiles;
        for (int i = 0; i < TypePercentiles.Length; i++)
        {
            if (noiseValue < TypePercentiles[i])
            {
                this.type = (TerrainType)i;
                break;
            }
        }
    }
}