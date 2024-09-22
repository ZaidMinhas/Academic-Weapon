using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [SerializeField] private Canvas HUD;
    [SerializeField] private Canvas gameOverScreen;
    [SerializeField] private Canvas winScreen;
    [SerializeField] private Canvas pauseMenu;
    [SerializeField] private Image blackPanel;
    
    private TextMeshProUGUI timeText;
    private Scrollbar disappearAbility;

    private void Start()
    {
        HUD = Instantiate(HUD);
        
        gameOverScreen = Instantiate(gameOverScreen);
        gameOverScreen.enabled = false;

        winScreen = Instantiate(winScreen);
        winScreen.enabled = false;

        pauseMenu = Instantiate(pauseMenu);
        pauseMenu.enabled = false;
        
        disappearAbility = HUD.GetComponentInChildren<Scrollbar>();
        timeText = HUD.GetComponentInChildren<TextMeshProUGUI>();
        AbilityDefault();
    }

    public void UpdateAbilityCooldown(float value)
    {
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

    public void ShowGameOver()
    {
        gameOverScreen.enabled = true;
    }

    public void ShowWin()
    {
        winScreen.enabled = true;
    }

    public void TogglePauseMenu()
    {
        pauseMenu.enabled = !pauseMenu.enabled;
    }

    public void FadeToBlack()
    {
        blackPanel.DOColor(Color.black, 2);
    }
}
