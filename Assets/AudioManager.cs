using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [SerializeField] private AudioSource slap;
    public void StopAudio()
    {
        AudioSource[] sources = GetComponents<AudioSource>();
        foreach (AudioSource source in sources)
        {
            source.Stop();
        }
    }

    public void ToggleAudio()
    {
        AudioSource[] sources = GetComponents<AudioSource>();
        foreach (AudioSource source in sources)
        {
            if (source.isPlaying)
            {
                source.Stop();
            }
            else
            {
                source.Play();
            }
        }
    }

    public void PlaySlap()
    {
        if (!slap.isPlaying)
        {
            slap.Play();
            
        }
        
    }
}
