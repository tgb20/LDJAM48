using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coster : MonoBehaviour
{
    public Cost Cost;
    public Gain Gain;

    private void Start()
    {
        ResourceManager.Instance.PeopleCost += Cost.People;
        ResourceManager.Instance.EnergyCost += Cost.Energy;
        ResourceManager.Instance.Money -= Cost.Money;
        ResourceManager.Instance.EnergyGain += Gain.Energy;
        ResourceManager.Instance.PeopleGain += Gain.People;
    }

    void OnDestroy()
    {
        ResourceManager.Instance.PeopleCost -= Cost.People;
        ResourceManager.Instance.EnergyCost -= Cost.Energy;
        ResourceManager.Instance.Money += Cost.Money/2;
        ResourceManager.Instance.EnergyGain -= Gain.Energy;
        ResourceManager.Instance.PeopleGain -= Gain.People;
    }
}

[Serializable]
public class Cost
{
    public int People;
    public int Energy;
    public int Money;
}

[Serializable]
public class Gain
{
    public int People;
    public int Energy;
}
