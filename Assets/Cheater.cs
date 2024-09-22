using System;
using System.Collections;
using System.Collections.Generic;
using TreeEditor;
using UnityEngine;
using Random = UnityEngine.Random;

public class Cheater : MonoBehaviour
{
    [SerializeField] private float distanceToMove = 0.1f;
    [SerializeField] private float xValToStopAt = -1.7f;
    
    [Tooltip("The time that the cheater waits after the player looks at them")]
    [SerializeField] private float moveCooldown = 4.0f; // in seconds

    [Tooltip("The percent chance that the player will move each frame.")]
    [SerializeField] private float percentChance = 0.1f;

    [SerializeField] private AudioClip[] audioClips;
    
    private float timeSincePlayerLook = 0.0f;
    private Vector3 originalPos;
    private bool success = false;

    private AudioSource audioSource;

    private void Start()
    {
        //originalPos = transform.position;
        audioSource = GetComponent<AudioSource>();
    }

    void Update()
    {
        
        if (Time.time > (timeSincePlayerLook + moveCooldown) && Time.time != 0)
        {
            float random = Random.value;
            if (random > (1.0 - (percentChance / 100)))
            {
                MoveCloser();
            }
        }
        else
        {
            if (audioSource.isPlaying)
            {
               audioSource.Stop(); 
            }
        }
    }

    private void MoveCloser()
    {
        Vector3 position = transform.position;
        if (position.x <= xValToStopAt)
        {
            transform.position = new Vector3(position.x + distanceToMove, position.y, position.z);
            PlayChairScraping();
        }
        else
        {
            success = true;
        }
        
    }

    /*
    private void AltMoveCloser()
    {
        transform.Translate(Vector3.right * Time.deltaTime * 5);
    }
    private void AltPlayerLooking()
    {
        transform.position = Vector3.MoveTowards(transform.position, originalPos, Time.deltaTime);
    }
    */


    public void PlayerLooking()
    {
        timeSincePlayerLook = Time.time;
    }

    public bool stopChecking = false;
    public bool IsSuccessful()
    {
        if (stopChecking) { return false; }
        return success;
    }

    private void PlayChairScraping()
    {
        if (!audioSource.isPlaying)
        {
            // Play a random sound clip
            audioSource.clip = audioClips[Random.Range(0, audioClips.Length - 1)];
            audioSource.Play();
        }
       
    }
}
