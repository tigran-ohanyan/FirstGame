using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayAudioOnTrigger : MonoBehaviour
{
    private AudioSource audio;
    void Start()
    {

        audio = this.GetComponent<AudioSource>();
    }

    void OnTriggerEnter(Collider collider)
    {
        if(collider.tag == "Player" && !audio.isPlaying)
        {
            audio.Play();
        }
    }

    void OnTriggerExit(Collider collider)
    {
        if(collider.tag == "Player" && audio.isPlaying)
        {
            audio.Stop();
        }
    }
}
