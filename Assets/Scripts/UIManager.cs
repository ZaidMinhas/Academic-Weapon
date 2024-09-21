using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [SerializeField] private Canvas HUD;
    private TextMeshProUGUI timeText;
    private Scrollbar disappearAbility;

    private void Start()
    {
        HUD = Instantiate(HUD);
        
        disappearAbility = HUD.GetComponentInChildren<Scrollbar>();
        timeText = HUD.GetComponentInChildren<TextMeshProUGUI>();
        AbilityDefault();
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

    public void UpdateTime(float minutes, float seconds)
    {
        timeText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }
}
