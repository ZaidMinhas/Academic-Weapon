using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class Cheater : MonoBehaviour
{
    [SerializeField] private float distanceToMove = 0.1f;
    [SerializeField] private float xValToStopAt = -1.7f;
    
    [Tooltip("The time that the cheater waits after the player looks at them")]
    [SerializeField] private float moveCooldown = 2.0f; // in seconds
    
    private float timeSincePlayerLook = 0.0f;

    private bool success = false;
    
    void Update()
    {
        
        if (Time.time > (timeSincePlayerLook + moveCooldown) && Time.time != 0)
        {
            float random = Random.value;
            if (random > 0.99)
            {
                MoveCloser();
            }
        }
    }

    private void MoveCloser()
    {
        Vector3 position = transform.position;
        if (position.x <= xValToStopAt)
        {
            transform.position = new Vector3(position.x + distanceToMove, position.y, position.z);
        }
        else
        {
            success = true;
        }
        
    }

    public void PlayerLooking()
    {
        timeSincePlayerLook = Time.time;
    }

    public bool IsSuccessful()
    {
        return success;
    }
}
