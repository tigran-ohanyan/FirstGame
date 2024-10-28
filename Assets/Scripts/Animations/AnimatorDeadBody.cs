using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class AnimatorDeadBody : MonoBehaviour
{
    private Animator animator;
    //[SerializeField] private Collider collider;
    private AudioSource audioSource;

    public void Start()
    {
        animator = gameObject.GetComponent<Animator>();
        audioSource = gameObject.GetComponent<AudioSource>();

    }
    private void OnTriggerEnter(Collider collider)
    {
        if (collider.tag == "Player")
        {
            animator.SetFloat("IsTrigger", 1);
            Debug.Log($"IsTrigger = {animator.GetFloat("isTrigger")}");

            audioSource.Play();
        }
    }
}
