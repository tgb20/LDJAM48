using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrashcanController : MonoBehaviour
{

    public GameObject TileSelected;
    public GameObject WaterTile;

    public AudioSource DeleteSound;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out hit))
            {
                if (hit.collider != null )
                {
                    if (hit.transform.gameObject == gameObject)
                    {
                        Instantiate(WaterTile, TileSelected.transform.position, TileSelected.transform.rotation, null);
                        Destroy(TileSelected);
                        DeleteSound.Play();
                    }
                }
            }
        }
    }
}
