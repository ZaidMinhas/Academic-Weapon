using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teacher : MonoBehaviour
{
    private AudioSource audioSource;

    [SerializeField] private AudioClip[] footstepClips;
    [SerializeField] CheatSheet cheetSheet;
    
    private float time = 0.0f;
    Walk walk;

    [SerializeField] private float walkingInterval = 10;
    // Start is called before the first frame update
    void Start()
    {   
        walk = GetComponent<Walk>();
        audioSource = GetComponent<AudioSource>();
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

    bool caught = false;
    private void FixedUpdate()
    {
        //todo OPTIMIZE LATER
        if (!caught)
        {
            CheckCheating();

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

    void CheckCheating()
    {
        float x = transform.position.x;
        float z = transform.position.z;
        if (cheetSheet.present && x > -5 && x < 1 && z > 3 && z < 6)
        {
            AttackStudent();
        }
    }

    public void AttackStudent()
    {
        caught = true;
        walk.AttackStudent();
    }

    public void Jumpscare()
    {
        GetComponent<Animator>().SetTrigger("Jumpscare");
        
    }
}
