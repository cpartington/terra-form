using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TerrainCell
{
    public int x;
    public int y;
    public int z;

    public TerrainCell(int x, int z, float noiseValue)
    {
        this.x = x;
        this.z = z;

        for (int i = 0; i < GridWeights.Percentiles.Length; i++)
        {
            if (noiseValue < GridWeights.Percentiles[i])
            {
                this.y = i;
                break;
            }
        }
    }
}