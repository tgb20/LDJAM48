using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms;

public class BaseTileSpawner : MonoBehaviour
{

    public GameObject CameraRig;

    public GameObject WaterTile;
    public GameObject[] IcebergTiles;

    public int XSize;
    public int ZSize;

    void Awake()
    {
        CameraRig.transform.position = new Vector3(7, 0, 7);
    }
    // Start is called before the first frame update
    void Start()
    {
        for (var x = 0; x < XSize; x++)
        {
            for (var z = 0; z < ZSize; z++)
            {

                if (((XSize - 1) / 2f).Equals(x) && ((ZSize - 1) / 2f).Equals(z))
                {
                    // Center Tile
                    continue;
                }

                var shouldMakeIceberg = Random.Range(0, 20);
                if (shouldMakeIceberg == 0)
                {
                    Quaternion randomDirection = Quaternion.identity;
                    randomDirection.eulerAngles += new Vector3(0, Random.Range(0, 4) * 90, 0);
                    var whatIceBerg = Random.Range(0, IcebergTiles.Length);
                    Instantiate(IcebergTiles[whatIceBerg], new Vector3(x, 0, z), randomDirection);
                }
                else
                {
                    Instantiate(WaterTile, new Vector3(x, 0, z), Quaternion.identity);
                }
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
