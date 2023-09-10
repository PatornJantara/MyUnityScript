using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundPlayer : MonoBehaviour
{
    public AudioClip backgroundClip; // Reference to the background audio clip
    private AudioSource audioSource; // Reference to the AudioSource component

    private void Start()
    {
        // Get the AudioSource component attached to the object
        audioSource = GetComponent<AudioSource>();

        // Set the audio clip for the AudioSource
        audioSource.clip = backgroundClip;

        // Play the background sound
        audioSource.Play();
    }
}
