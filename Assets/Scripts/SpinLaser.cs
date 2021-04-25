using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpinLaser : MonoBehaviour
{

    public GameObject LazerBeam;
    public int DrillSpeed;

    // Update is called once per frame
    void Update()
    {
        LazerBeam.transform.Rotate(0, 6 * DrillSpeed * Time.deltaTime, 0);
    }
}
