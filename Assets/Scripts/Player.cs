using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    // Start is called before the first frame update

    [SerializeField] ExamSheet examSheet;
    [SerializeField] CheatSheet cheatSheet;
    CameraManager cameraManager;
    private AudioSource audioSource;

    private void Start()
    {
        cameraManager = GetComponent<CameraManager>();
        audioSource = GetComponent<AudioSource>();
    }
    void Update()
    {
        

        if (isWriting())
        {       
            CheckInput();
        }
        else
        {
         StopWritingSound();   
        }
        
    }


    void CheckInput()
    {
        if (Keyboard.current.upArrowKey.wasPressedThisFrame || Keyboard.current.wKey.wasPressedThisFrame)
        {
            Write(0);
            return;
        }

        if (Keyboard.current.leftArrowKey.wasPressedThisFrame || Keyboard.current.aKey.wasPressedThisFrame)
        {
            Write(1);
            return;
        }

        if (Keyboard.current.downArrowKey.wasPressedThisFrame || Keyboard.current.sKey.wasPressedThisFrame)
        {
            Write(2);
            return;
        }

        if (Keyboard.current.rightArrowKey.wasPressedThisFrame || Keyboard.current.dKey.wasPressedThisFrame)
        {
            Write(3);
            return;
        }

    }

    public bool isWriting()
    {
        return cameraManager.isWriting();
    }

    void Write(int k)
    {
        if (cheatSheet.Check(k))
        {
            examSheet.Write(k);

            if (cheatSheet.isComplete())
            {
                examSheet.NextQuestion();
                cheatSheet.NextAnswer();
            }
            PlayWritingSound();
        }
        else
        {
            examSheet.Clear();
            StopWritingSound();
        }        
    }

    void PlayWritingSound()
    {
        if (!audioSource.isPlaying)
        {
            audioSource.Play();
        }
    }

    void StopWritingSound()
    {
        audioSource.Stop();
    }

}
