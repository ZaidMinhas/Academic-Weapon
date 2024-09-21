using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLook : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
        
        Ray rayOrigin = Camera.main.ViewportPointToRay(new Vector3 (0.5f, 0.5f, 0));
        RaycastHit hitInfo;

        // If anything was hit
        if (Physics.Raycast(rayOrigin, out hitInfo))
        {
            // If player is looking at the Cheater
            if (hitInfo.collider.GetComponent<Cheater>())
            {
                Cheater cheater = hitInfo.collider.GetComponent<Cheater>();
                cheater.PlayerLooking();
            }
        }
    }
    
}
