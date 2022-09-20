using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TerrainGridSystem : MonoBehaviour
{
    public static TerrainGridSystem Instance { get; private set; }

    private TerrainGrid grid;

    private void Awake()
    {
        Instance = this;

        this.grid = new TerrainGrid();
    }
}
