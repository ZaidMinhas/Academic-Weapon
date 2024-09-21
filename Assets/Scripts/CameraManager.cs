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
    [SerializeField] private float range = 4.0f;

    private void Update()
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
        
        else if (mouse.y < range)
        {
            LookDesk();
        }
        else if (mouse.y > (Screen.height - range))
        {
            LookUp();
        }
    }
    
    public void LookUp()
    {
        rightCamera.enabled = false;
        upCamera.enabled = true;
        deskCamera.enabled = false;
        leftCamera.enabled = false;
    }

    public void LookRight()
    {
        rightCamera.enabled = true;
        upCamera.enabled = false;
        deskCamera.enabled = false;
        leftCamera.enabled = false;
    }

    public void LookLeft()
    {
        rightCamera.enabled = false;
        upCamera.enabled = false;
        deskCamera.enabled = false;
        leftCamera.enabled = true;
        
    }

    public void LookDesk()
    {
        rightCamera.enabled = false;
        upCamera.enabled = false;
        deskCamera.enabled = true;
        leftCamera.enabled = false;
    }
}
