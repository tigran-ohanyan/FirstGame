using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Buttons : MonoBehaviour
{
    public AudioSource FX;

    //public AudioClip HoverFX;
    public AudioClip ClickFx;

    // public void HoverSound(){
    //     FX.PlayOneShot(HoverFX);
    // }

    public void ClickSound(){
        FX.PlayOneShot(ClickFx);
    }
}
