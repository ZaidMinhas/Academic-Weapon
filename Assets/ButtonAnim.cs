using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using Unity.VisualScripting;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine;
using UnityEngine.UIElements;
using Button = UnityEngine.UI.Button;

public class ButtonAnim : MonoBehaviour
{
    private Button button;
    [SerializeField] private float duration = 0.1f;
    [SerializeField] private float scaleAmt = 0.1f;

    private Canvas parent;
    private float scale;
    private bool animDone = false;
    
    private enum ButtonType
    {
        Play,
        Credits,
        Quit
    }

    [SerializeField] private ButtonType buttonType;
    private void Start()
    {
        button = GetComponent<Button>();
        scale = transform.localScale.x;
        parent = GetComponentInParent<Canvas>();
    }

    private void OnMouseOver()
    {
        if (!animDone)
        {
            button.transform.DOScale( scale + scaleAmt, duration);
            animDone = true;
        }
       
    }

    private void OnMouseExit()
    {
        if (animDone)
        {
            button.transform.DOScale(scale, duration);
            animDone = false;
        }
        
    }

    bool gameStart = false;
    public bool GameStarted()
    {
        return gameStart;
    }
    private void OnMouseDown()
    {
        // Play button pressed
        if (buttonType == ButtonType.Play)
        {
            gameStart = true;
            parent.enabled = false;
        }
        
        // Show credits
        else if (buttonType == ButtonType.Credits)
        {
            
        }
        
        // Quit game
        else if (buttonType == ButtonType.Quit)
        {
            Application.Quit();
        }
        
    }
}
