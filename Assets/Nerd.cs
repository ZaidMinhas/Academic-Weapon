using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Nerd : MonoBehaviour
{
    [SerializeField] CheatSheet cheetSheet;

    float urmTimer;

    bool stalking = false;

    [SerializeField] Glasses glasses;

    string[] quotes;
    [SerializeField] Sprite[] warnings_speech;
    [SerializeField] Sprite[] glasses_speech;
    [SerializeField] Image imgHolder;
    int index = 0;


    bool success = false;
    public bool stopChecking = false;

    private AudioSource audioSource;
    void Start()
    {
        
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {

        if (success) { return; }

        if (stalking)
        {
            if (!glasses.present)
            {
                index = 0;
                stalking = false;
                return;
            }

            if (!cheetSheet.present)
            {
                stalking = false;
            }


            if (Time.time > urmTimer)
            {
                urmTimer = Time.time + 5;

                StartCoroutine(displayImage(warnings_speech[index++]));


                //audioSource.Play();

                if (warnings_speech.Length == index)
                {
                    success = true;
                }
            }
        }




        if (cheetSheet.present && !stalking)
        {
            urmTimer = Time.time + 4;
            stalking = true;

        }
    }

    public void glassesImage(bool lost)
    {
        
        if (lost)
        {
            StartCoroutine(displayImage(glasses_speech[0]));
        }
        else
        {
            StartCoroutine(displayImage(glasses_speech[1]));
        }
    }

    IEnumerator displayImage(Sprite img)
    {
        imgHolder.color = new Color(1, 1, 0, 1);
        imgHolder.sprite = img;


        yield return new WaitForSeconds(3);
        
        imgHolder.color = new Color(1, 1, 0, 0);
    }
    
    public bool IsSuccessful()
    {
        if (stopChecking) { return false; }
        return success;
    }

    public void StopAudio()
    {
        audioSource.mute = true;
    }
}
