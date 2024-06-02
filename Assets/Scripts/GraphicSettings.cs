using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GraphicSettings : MonoBehaviour
{

    public Slider Quality_Slider;
    public int Quality_Param;
    public GameObject[] Quality_Int;
    
    private void Awake(){
        Quality_Slider.onValueChanged.AddListener(SliderValueChanged);
    }

    private void SliderValueChanged(float value){
        Quality_Int[Quality_Param].SetActive(false);
        Quality_Param = (int)value;
        Quality_Int[Quality_Param].SetActive(true);
        QualitySettings.SetQualityLevel((int)value);
    }

    private void OnDisable(){
        PlayerPrefs.SetInt("Quality_Param", Quality_Param);
    }

    void Start(){
        Quality_Param = PlayerPrefs.GetInt("Quality_Param");
        Quality_Int[Quality_Param].SetActive(true);
        Quality_Slider.value = Quality_Param;  
        QualitySettings.SetQualityLevel((int)Quality_Slider.value);

    }
    // public int Quality_Int = 1;
    // public Slider slider;
    // public GameObject[] Quality_Text;

    // private void Awake(){
    //     ChangeQuality(Quality_Int);
    //     // slider.onValueChanged.AddListener(ChangeQuality);
    // }

    // public void Start(){
    //     Quality_Int = PlayerPrefs.GetInt("Quality_Int");
    //     slider.value = Quality_Int;
    //     QualitySettings.SetQualityLevel(Quality_Int);
    //     Debug.Log(Quality_Int);
    //     // Debug.Log(PlayerPrefs.GetInt("Quality_Int"));
    //     Quality_Text[Quality_Int].SetActive(true);
    // }
    
    // public void ChangeQuality(int Quality_Int){
    //     Quality_Text[Quality_Int].SetActive(false);
    //     PlayerPrefs.SetInt("Quality_Int", Quality_Int);
    //     QualitySettings.SetQualityLevel(Quality_Int);
    //     Quality_Text[Quality_Int].SetActive(true);
    // }
}
