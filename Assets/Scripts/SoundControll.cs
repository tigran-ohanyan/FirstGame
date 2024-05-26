using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class SoundControll : MonoBehaviour
{
    
    public string volumeParameter = "MasterVolume";
    public AudioMixer mixer;
    public Slider slider;

    private float volumeValue;
    private const float _multiplier = 20f;

    private void Awake(){
        slider.onValueChanged.AddListener(HandleSliderValueChanged);
    }

    private void HandleSliderValueChanged(float value){
        volumeValue = Mathf.Log10(value) * _multiplier;
        mixer.SetFloat(volumeParameter, volumeValue);
    }
    
    private void OnDisable(){
        PlayerPrefs.SetFloat(volumeParameter, volumeValue);
    }

    void Start(){
        volumeValue = PlayerPrefs.GetFloat(volumeParameter, Mathf.Log10(slider.value) * _multiplier);
        slider.value = Mathf.Pow(10f, volumeValue / _multiplier);  

        //mixer.SetFloat(volumeParameter, volumeValue);
    }
    
}
