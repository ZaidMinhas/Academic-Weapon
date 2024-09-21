using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class GameManager : MonoBehaviour
{
    [SerializeField] private UIManager uiManager;
    [SerializeField] private AudioManager audioManager;
    
    [Tooltip("The time limit of the exam in minutes.")]
    [SerializeField] private float timeLimit = 0.5f; // in minutes

    [SerializeField] private Volume pausePost;

    [SerializeField] private Cheater cheater;

    [SerializeField] private ExamSheet examSheet;

    private bool isPaused = false;
    private float timeRemaining; // in seconds
    
    
    // Start is called before the first frame update
    void Start()
    {
        timeRemaining = timeLimit * 60;
        
        pausePost = Instantiate(pausePost);
        pausePost.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
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
            GameOver();
        }

        if (cheater.IsSuccessful())
        {
            GameOver();
        }

        if (examSheet.finished)
        {
            Win();
        }
        
    }

    void GameOver()
    {
        uiManager.UpdateTime(0,0);
        uiManager.ShowGameOver();
        audioManager.StopAudio();
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
        audioManager.StopAudio();
    }

    
}
