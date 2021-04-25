using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrillMenu : MonoBehaviour
{

    private bool _isDrilling = true;

    public LazerController _lazerController;

    public GameObject PauseIcon;
    public GameObject PlayIcon;

    void Start()
    {
        if (_isDrilling)
        {
            PauseIcon.SetActive(true);
            PlayIcon.SetActive(false);
        }
        else
        {
            PauseIcon.SetActive(false);
            PlayIcon.SetActive(true);
        }
    }

    void Update()
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
                        _lazerController.ToggleLazer();
                        _isDrilling = !_isDrilling;
                        if (_isDrilling)
                        {
                            PauseIcon.SetActive(true);
                            PlayIcon.SetActive(false);
                        }
                        else
                        {
                            PauseIcon.SetActive(false);
                            PlayIcon.SetActive(true);
                        }
                    }
                }
            }
        }
    }
}
