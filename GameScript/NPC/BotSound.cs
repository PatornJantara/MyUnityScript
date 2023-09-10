using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BotSound : MonoBehaviour
{

    public AudioClip audioClip;
    public AudioSource audioSource;


    public void MakeSound()
    {
        if(!audioSource.isPlaying)
        {
            audioSource.PlayOneShot(audioClip);
        }

    }

    public void Stop()
    {
        audioSource.Stop();
    }
}
