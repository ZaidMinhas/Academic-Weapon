using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [SerializeField] private Canvas HUD;
    private Scrollbar disappearAbility;

    private void Start()
    {
        
        HUD = Instantiate(HUD);
        disappearAbility = HUD.GetComponentInChildren<Scrollbar>();
        AbilityDefault();
    }

    private void Update()
    {
        
    }

    public void UpdateAbilityCooldown(float value)
    {
        Debug.Log(disappearAbility.size);
        disappearAbility.size = value;
    }

    public void AbilityDefault()
    {
        Image image = disappearAbility.handleRect.GetComponent<Image>();
        image.enabled = false;
    }
    
    public void AbilityCooldown()
    {
        Image image = disappearAbility.handleRect.GetComponent<Image>();
        image.enabled = true;
    }
}
