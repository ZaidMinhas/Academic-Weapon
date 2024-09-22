using System;
using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using UnityEngine;
using UnityEngine.InputSystem;

public class CameraManager : MonoBehaviour
{
    [SerializeField] private CinemachineVirtualCamera deskCamera;
    [SerializeField] private CinemachineVirtualCamera leftCamera;
    [SerializeField] private CinemachineVirtualCamera upCamera;
    [SerializeField] private CinemachineVirtualCamera rightCamera;
    [SerializeField] private CinemachineVirtualCamera jumpScareCam;
    [SerializeField] private float range = 4.0f;

    private void Update()
    {
        if (!jumpScareCam.enabled)
        {
            Vector3 mouse = Input.mousePosition;
            
            // Mouse to the left
            if (mouse.x < range)
            {
                LookLeft();
            }
            
            // Mouse to the right
            else if (mouse.x > (Screen.width - range))
            {
              LookRight();
              
            }
            
            // Mouse downwards
            else if (mouse.y < range)
            {
                LookDesk();
            }
            
            // Mouse upwards
            else if (mouse.y > (Screen.height - range))
            {
                LookUp();
            }
        }
    }
    
    private void LookUp()
    {
        rightCamera.enabled = false;
        upCamera.enabled = true;
        deskCamera.enabled = false;
        leftCamera.enabled = false;
    }

    private void LookRight()
    {
        rightCamera.enabled = true;
        upCamera.enabled = false;
        deskCamera.enabled = false;
        leftCamera.enabled = false;
    }

    private void LookLeft()
    {
        rightCamera.enabled = false;
        upCamera.enabled = false;
        deskCamera.enabled = false;
        leftCamera.enabled = true;
        
    }

    private void LookDesk()
    {
        rightCamera.enabled = false;
        upCamera.enabled = false;
        deskCamera.enabled = true;
        leftCamera.enabled = false;
    }


    public bool isWriting()
    {
        return deskCamera.enabled;
    }

    public void JumpscareCamOn()
    {
        jumpScareCam.enabled = true;
        rightCamera.enabled = false;
        upCamera.enabled = false;
        deskCamera.enabled = false;
        leftCamera.enabled = false;
        
    }
}
