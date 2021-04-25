using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerGenerator : MonoBehaviour
{

    public Transform PowerWheel;

    public float WheelSpeed;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        PowerWheel.transform.Rotate(6 * WheelSpeed * Time.deltaTime, 0, 0);
    }
}
