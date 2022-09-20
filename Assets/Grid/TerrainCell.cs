using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TerrainCell
{
    private int x;
    private int z;

    private TerrainGrid grid;

    public TerrainCell(TerrainGrid grid, int x, int z)
    {
        this.grid = grid;

        this.x = x;
        this.z = z;
    }
}