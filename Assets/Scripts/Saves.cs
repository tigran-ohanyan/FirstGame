using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class Saves : MonoBehaviour
{
    [SerializeField] private AudioMixer mixer;
    [SerializeField] private GameObject FlashLight;

    void Start(){
        //PlayerPrefs.DeleteAll(); //Disable this line
        QualitySettings.SetQualityLevel(PlayerPrefs.GetInt("GraphicSettings"));
        if(PlayerPrefs.GetInt("MixerParamSound") == 1){
            mixer.SetFloat("Sound", 0);
        }else{
            mixer.SetFloat("Sound", -80);
		}
        if (PlayerPrefs.GetInt("MixerParamMusic") == 1){
            mixer.SetFloat("Music", 0);
        }else{
            mixer.SetFloat("Music", -80);
     	}
		//public Save saveClass = new Save();
		Save.SaveGame("userID = 1");
		Save.SaveGame("userID = 2");
    }
    void Update()
    {
       
    }
	

}
