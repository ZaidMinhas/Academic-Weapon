using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.SceneManagement;

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
    [SerializeField] private Disappear disappear;

    [SerializeField] ButtonAnim button;
    bool gameStarted = false;   
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

    void enableAll()
    {
        gameStarted = true;
        nerd.enabled = true;
        teacher.enabled = true;
        cheater.enabled = true;
        disappear.enabled = true;
    }

    void disableAll()
    {
        gameStarted = false;
        nerd.enabled = false;
        teacher.enabled = false;
        cheater.enabled = false;
        disappear.enabled = false;

    }
    void Update()
    {

        if (!gameStarted)
        {
            if (button.GameStarted())
            {
                
                enableAll();   
            }

            else
            {
                return;
            }
        }
        


        if (uiManager.IsMainMenu())
        {
           return;
        }
        cameraManager.MainMenuCamOff();
        uiManager.ShowHUD();
        
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
            disableAll();
            if (uiManager.IsFadeDone())
            {
                GameOver("You were caught.");
                StartCoroutine(restart());
                
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
        disableAll();
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

    IEnumerator restart()
    {
        yield return new WaitForSeconds(2f);

        SceneManager.LoadScene(0);
    }
}
