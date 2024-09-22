using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class GameManager : MonoBehaviour
{
    [SerializeField] private UIManager uiManager;
    [SerializeField] private AudioManager audioManager;
    [SerializeField] private CameraManager cameraManager;
    
    [Tooltip("The time limit of the exam in minutes.")]
    [SerializeField] private float timeLimit = 0.5f; // in minutes

    [SerializeField] private Volume pausePost;
    [SerializeField] private Volume deathPost;

    [SerializeField] private Cheater cheater;

    [SerializeField] private ExamSheet examSheet;

    [SerializeField] private Teacher teacher;

    [SerializeField] private Nerd nerd;

    private bool isPaused = false;
    private float timeRemaining; // in seconds
    
    
    // Start is called before the first frame update
    void Start()
    {
        timeRemaining = timeLimit * 60;
        
        pausePost = Instantiate(pausePost);
        pausePost.enabled = false;

        deathPost = Instantiate(deathPost);
        deathPost.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (!uiManager.IsMainMenu())
        {
            cameraManager.MainMenuCamOff();
        }
        
        // Update the timer while there's still time left
        if (timeRemaining > 0)
        {
            timeRemaining -= Time.deltaTime;
            float minutes = Mathf.FloorToInt(timeRemaining / 60);
            float seconds = Mathf.FloorToInt(timeRemaining % 60);
            uiManager.UpdateTime(minutes, seconds);
        }
        // Time has run out -- GAME OVER
        else
        {
            GameOver("You ran out of time.");
        }

        if (nerd.IsSuccessful())
        {
            teacher.AttackStudent();
            nerd.stopChecking = true;
        }

        if (cheater.IsSuccessful())
        {
            teacher.AttackStudent();
            cheater.stopChecking = true;
        }

        if (teacher.IsSuccessful())
        {
            if (uiManager.IsFadeDone())
            {
                GameOver("You were caught.");
            }
            else
            {
                deathPost.enabled = true;
                uiManager.FadeToBlack();
                audioManager.PlaySlap();
                uiManager.HideAbility();
            }
           
            
        }

        if (examSheet.finished)
        {
            Win();
        }
        
    }

    void GameOver(string reason)
    {
        uiManager.UpdateTime(0,0);
        uiManager.ShowGameOver(reason);
        audioManager.StopAudio();
        nerd.StopAudio();
    }

    void Win()
    {
        uiManager.ShowWin();
        audioManager.StopAudio();
    }

    public void PauseGame()
    {
        uiManager.TogglePauseMenu();
        isPaused = !isPaused;
        Time.timeScale = isPaused ? 0 : 1;
        pausePost.enabled = !pausePost.enabled;
        audioManager.ToggleAudio();
    }

    
}
