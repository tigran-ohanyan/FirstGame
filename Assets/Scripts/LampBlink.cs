using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LampBlink : MonoBehaviour
{
    private Light light;
    float timer;
    float RandomNumber;

    void Start()
    {
        light = this.GetComponent<Light>();

        light.enabled = false;
    }
    void FixedUpdate()
    {
        RandomNumber = Random.value;

        if(RandomNumber <= .5)
        {
            light.enabled = true;
        }
        else
        {
            light.enabled = false;  
        }
    }

}
