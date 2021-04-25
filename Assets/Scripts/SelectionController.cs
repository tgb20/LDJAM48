using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngineInternal;

public class SelectionController : MonoBehaviour
{

    public int LerpSpeed;
    public GameObject HighlightedTile;
    public GameObject SelectedTile;
    private SpriteRenderer _selectorRenderer;
    public GameObject PowerGenerator;

    public GameObject TrashCan;
    public GameObject TileBuildMenu;
    public GameObject PlayPauseMenu;

    private void Start()
    {
        _selectorRenderer = GetComponentInChildren<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit hit;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out hit))
        {
            if (hit.collider != null && SelectedTile == null)
            {
                HighlightedTile = hit.transform.gameObject;

                transform.position =
                    Vector3.Lerp(transform.position, hit.collider.transform.position, Time.deltaTime * LerpSpeed);
            }
        }


        if (Input.GetMouseButtonDown(0))
        {
            if (HighlightedTile != null)
            {
                if (HighlightedTile.tag == "Water")
                {
                    _selectorRenderer.color = Color.green;
                    SelectedTile = HighlightedTile;
                    TileBuildMenu.transform.position = SelectedTile.transform.position;
                    TileBuildMenu.SetActive(true);
                    foreach (var child in TileBuildMenu.GetComponentsInChildren<MenuItem>())
                    {
                        child.TileSelected = SelectedTile;
                    }
                }
                else if (HighlightedTile.tag == "Lazer")
                {
                    _selectorRenderer.color = Color.green;
                    SelectedTile = HighlightedTile;
                    PlayPauseMenu.transform.position = SelectedTile.transform.position;
                    PlayPauseMenu.SetActive(true);
                } else if(HighlightedTile.tag == "Improvement")
                {
                    _selectorRenderer.color = Color.green;
                    SelectedTile = HighlightedTile;
                    TrashCan.transform.position = SelectedTile.transform.position;
                    TrashCan.SetActive(true);
                    TrashCan.GetComponent<TrashcanController>().TileSelected = SelectedTile;
                }
                else
                {
                    _selectorRenderer.color = Color.green;
                    SelectedTile = HighlightedTile;
                }
            }
        }

        if (Input.GetKeyDown(KeyCode.Escape) || SelectedTile == null)
        {
            SelectedTile = null;
            _selectorRenderer.color = Color.white;
            TrashCan.SetActive(false);
            TileBuildMenu.SetActive(false);
            PlayPauseMenu.SetActive(false);
        }

    }
}
