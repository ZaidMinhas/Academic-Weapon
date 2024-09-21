using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private UIManager uiManager;
    
    [Tooltip("The time limit of the exam in minutes.")]
    [SerializeField] private float timeLimit = 0.5f; // in minutes

    private float timeRemaining; // in seconds
    
    
    // Start is called before the first frame update
    void Start()
    {
        timeRemaining = timeLimit * 60;
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
        
    }

    void GameOver()
    {
        uiManager.UpdateTime(0,0);
        uiManager.ShowGameOver();
    }
}
