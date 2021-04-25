using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Booster : MonoBehaviour
{

    private void OnEnable()
    {
        ResourceManager.Instance.Boosters += 1;
    }

    private void OnDestroy()
    {
        ResourceManager.Instance.Boosters -= 1;
    }


}
