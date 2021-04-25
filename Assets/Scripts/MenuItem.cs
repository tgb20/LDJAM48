using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuItem : MonoBehaviour
{

    public GameObject TileToSpawn;
    public GameObject TileSelected;
    public GameObject Model;

    private BoxCollider _boxCollider;

    private void Awake()
    {
        _boxCollider = GetComponent<BoxCollider>();
    }

    private void OnEnable()
    {
        if (ResourceManager.Instance.Money - TileToSpawn.GetComponent<Coster>().Cost.Money >= 0)
        {
            _boxCollider.enabled = true;
            Model.SetActive(true);
        }
        else
        {
            _boxCollider.enabled = false;
            Model.SetActive(false);
        }
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out hit))
            {
                if (hit.collider != null)
                {
                    if (hit.transform.gameObject == gameObject)
                    {

                        Quaternion randomDirection = Quaternion.identity;

                        randomDirection.eulerAngles += new Vector3(0,Random.Range(0, 4) * 90, 0);

                        Instantiate(TileToSpawn, TileSelected.transform.position, randomDirection, null);
                        Destroy(TileSelected);

                        GameObject.FindGameObjectWithTag("PlaceAudio").GetComponent<AudioSource>().Play();

                    }
                }
            }
        }
    }
}
