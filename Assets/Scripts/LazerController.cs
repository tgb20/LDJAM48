using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LazerController : MonoBehaviour
{

    public GameObject LazerBeam;
    public float DrillSpeed = 5f;

    private Coster _coster;

    private bool _isDrillEnabled = true;

    private void Start()
    {
        _coster = GetComponent<Coster>();
    }

    public void ToggleLazer()
    {
        if (!_isDrillEnabled)
        {
            ResourceManager.Instance.EnergyCost += _coster.Cost.Energy;
            ResourceManager.Instance.PeopleCost += _coster.Cost.People;
            ResourceManager.Instance.IsDrilling = true;
            _isDrillEnabled = true;
            LazerBeam.SetActive(true);
        }
        else
        {
            ResourceManager.Instance.EnergyCost -= _coster.Cost.Energy;
            ResourceManager.Instance.PeopleCost -= _coster.Cost.People;
            ResourceManager.Instance.IsDrilling = false;
            _isDrillEnabled = false;
            LazerBeam.SetActive(false);
        }
    }

    private void Update()
    {
        if (_isDrillEnabled)
        {
            LazerBeam.transform.Rotate(0, 6 * DrillSpeed * Time.deltaTime, 0);
        }
    }
}
