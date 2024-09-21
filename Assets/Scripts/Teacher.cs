using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teacher : MonoBehaviour
{
    private AudioSource audioSource;

    [SerializeField] private AudioClip[] footstepClips;

    private float time = 0.0f;

    [SerializeField] private float walkingInterval = 10;
    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        Debug.Log(audioSource);
    }

    // Update is called once per frame
    void Update()
    {
       
        if (time > walkingInterval)
        {
            PlayWalkingSound();
            time = 0.0f;
        }
        else
        {
            time += Time.deltaTime;
        }
    }

    private void PlayWalkingSound()
    {
        if (!audioSource.isPlaying)
        {
            // Play a random sound clip
            audioSource.clip = footstepClips[Random.Range(0, footstepClips.Length - 1)];
            audioSource.Play();
        }
    }
}
