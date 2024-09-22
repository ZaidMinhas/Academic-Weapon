using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Teacher : MonoBehaviour
{
    private AudioSource audioSource;

    [SerializeField] private AudioClip[] footstepClips;
    [SerializeField] CheatSheet cheetSheet;
    [SerializeField] Player player;
    [SerializeField] Image imgHolder;

    [SerializeField] Sprite warningImg;
    [SerializeField] Sprite deathImg;

    private float time = 0.0f;
    private bool success = false;
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
        if (!caught && !walk.isDistracted())
        {
            CheckCheating();
            CheckLooking();
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

    bool knowsPlayerIsLooking = false;
    float annoyTime;
    float killTime;
    bool warned = false;
    void CheckLooking()
    {
        if (!knowsPlayerIsLooking && !player.isWriting())
        {
            knowsPlayerIsLooking = true;
            annoyTime = Time.time + 5;
            killTime = Time.time + 8;
        }
        else if (knowsPlayerIsLooking && player.isWriting())
        {
            knowsPlayerIsLooking = false;
        }
        else if (knowsPlayerIsLooking && !player.isWriting())
        {
            if (!warned && Time.time > annoyTime)
            {
                StartCoroutine(displayImage(warningImg));
                warned = true;
            }

            if (Time.time > killTime)
            {
                AttackStudent();
            }
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
        StartCoroutine(displayImage(deathImg));
        caught = true;
        walk.AttackStudent();
    }

    public void Jumpscare()
    {
        GetComponent<Animator>().SetTrigger("Jumpscare");
        success = true;

    }

    public void Alert(Transform t)
    {

        walk.CheckoutIncident(t);
    }

    public bool IsSuccessful()
    {
        return success;
    }

    IEnumerator displayImage(Sprite img)
    {
        imgHolder.color = new Color(1, 0.3f, 0.3f, 1);
        imgHolder.sprite = img;


        yield return new WaitForSeconds(3);

        imgHolder.color = new Color(1, 0.3f, 0.3f, 0);
    }
}
