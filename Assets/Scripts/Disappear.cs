using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Disappear : MonoBehaviour
{
    private Disappearable lastHitObject = null;

    private float timeLastUsed;

    [SerializeField] private UIManager uiManager;
    [SerializeField] private float cooldownTime = 4.0f;
        private float x = 0.0f;
        private float rate = 0.045f;

    private float targetTime = 0.0f;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Vector2 mousePos = Mouse.current.position.ReadValue();
        Ray rayOrigin = Camera.main.ScreenPointToRay(mousePos);
        RaycastHit hitInfo;

        // If anything was hit
        if (Physics.Raycast(rayOrigin, out hitInfo))
        {
            // If something was hit that is disappearable
            if (hitInfo.collider.GetComponent<Disappearable>())
            {
                //Debug.Log(hitInfo.collider.name);
                lastHitObject = hitInfo.collider.GetComponent<Disappearable>();
                lastHitObject.ShowOutline();

                // If player clicks on the object
                if (Input.GetMouseButtonDown(0))
                {
                    
                    if (IsCooldownDone())
                    {
                        Cooldown();
                        lastHitObject.Disappear();
                        uiManager.AbilityCooldown();
                    }
                    else
                    {
                        Debug.Log("Cooldown is not done yet!");
                    }
                    
                }
            }

        }
        else
        {
            if (lastHitObject)
            {
                lastHitObject.HideOutline();
            }
        }

        if (!IsCooldownDone())
        {
            if (targetTime < 1.0f * cooldownTime)
            {
                IncreaseCooldown();
                uiManager.UpdateAbilityCooldown(targetTime / cooldownTime);
            }
        }
        else
        {
            uiManager.AbilityDefault();
        }
        
    }

    private void Cooldown()
    {
        timeLastUsed = Time.time;
        targetTime = 0;
        Debug.Log(timeLastUsed);
    }

    private bool IsCooldownDone()
    {
        if (Time.time > (timeLastUsed + cooldownTime) || timeLastUsed == 0)
        {
            //Debug.Log("good to go!");
            return true;
        }

        //Debug.Log("cooldown is not done");
        return false;

    }

    private void IncreaseCooldown()
    {
        targetTime += Time.deltaTime;
    }
        
}