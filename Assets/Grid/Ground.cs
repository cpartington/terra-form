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

    // Start is called before the first frame update
    void Start()
    {
        meshRenderer = GetComponent<MeshRenderer>();

        int groundType = Random.Range(0, 5);
        switch (groundType)
        {
            case GridConstants.DeepWater:
                meshRenderer.material = deepWater;
                transform.localScale = new Vector3(1, 0.5f, 1);
                break;
            case GridConstants.ShallowWater:
                meshRenderer.material = shallowWater;
                transform.localScale = new Vector3(1, 1, 1);
                break;
            case GridConstants.LowGround:
                meshRenderer.material = lowGround;
                transform.localScale = new Vector3(1, 1.5f, 1);
                break;
            case GridConstants.MidGround:
                meshRenderer.material = midGround;
                transform.localScale = new Vector3(1, 2, 1);
                break;
            case GridConstants.HighGround:
                meshRenderer.material = highGround;
                transform.localScale = new Vector3(1, 2.5f, 1);
                break;
            default:
                Debug.Log("You messed up");
                break;
        }
    }
}
