using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ground : MonoBehaviour
{
    public Material deepWater;
    public Material shallowWater;
    public Material lowGround;
    public Material midGround;
    public Material highGround;
    
    private MeshRenderer meshRenderer;
    private TerrainCell cell;

    // Start is called before the first frame update
    void Start()
    {
        this.meshRenderer = GetComponent<MeshRenderer>();
        this.cell = TerrainGrid.Instance.GetTerrainCell(transform.position);
        float[] Percentiles = TerrainComputer.Instance.TerrainTypePercentiles;

        transform.localScale = new Vector3(1, cell.y, 1);

        switch (cell.type)
        {
            case TerrainType.DeepWater:
                meshRenderer.material = deepWater;
                //transform.localScale = new Vector3(1, 0.5f, 1);
                break;
            case TerrainType.ShallowWater:
                meshRenderer.material = shallowWater;
                //transform.localScale = new Vector3(1, 1, 1);
                break;
            case TerrainType.LowGround:
                meshRenderer.material = lowGround;
                //transform.localScale = new Vector3(1, 1.5f, 1);
                break;
            case TerrainType.MidGround:
                meshRenderer.material = midGround;
                //transform.localScale = new Vector3(1, 2, 1);
                break;
            case TerrainType.HighGround:
                meshRenderer.material = highGround;
                //transform.localScale = new Vector3(1, 2.5f, 1);
                break;
            default:
                Debug.Log("You messed up");
                break;
        }
    }
}
