using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Saves : MonoBehaviour
{
    // [SeriaLizeField]
    public string volumeParams;

    private const float _multiplier = 20f;

    void Start(){
        //gameObject.SetActive(false);
        // volumeValue = PlayerPrefs.GetFloat(volumeParameter, Mathf.Log10(slider.value) * _multiplier);
        // slider.value = Mathf.Pow(10f, volumeValue / _multiplier);  
    }
}
