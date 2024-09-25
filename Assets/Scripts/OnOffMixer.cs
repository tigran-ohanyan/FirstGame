using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//using UnityEngine.UIElements;
using UnityEngine.Audio;

public class OnOffMixer : MonoBehaviour
{
    [SerializeField] private AudioMixer mixer;
    [SerializeField] private string MixerParameter = "Master";
    public Sprite SpriteOffMusic, SpriteOnMusic;
    int OnOff;
    // Start is called before the first frame update

    void Start()
    {
        
        if (PlayerPrefs.GetInt("MixerParam"+MixerParameter) == 1)
        {

            gameObject.GetComponent<Image>().sprite = SpriteOnMusic;
            OnOff = 1;
            //mixer.SetFloat(MixerParameter, 0);
        }
        else
        {

            gameObject.GetComponent<Image>().sprite = SpriteOffMusic;
            Debug.Log("0");
            OnOff = 0;
            //mixer.SetFloat(MixerParameter, -80);
        }
    }

    public void onClick()
    {
        if(OnOff == 1)
        {
            gameObject.GetComponent<Image>().sprite = SpriteOffMusic;
            Debug.Log("false");
            mixer.SetFloat(MixerParameter, -80);
            OnOff = 0;
        }
        else
        {
            gameObject.GetComponent<Image>().sprite = SpriteOnMusic;
            Debug.Log("true");
            mixer.SetFloat(MixerParameter, 0);
            OnOff = 1;
        }
        PlayerPrefs.SetInt("MixerParam"+MixerParameter, OnOff);
    }

}
