using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    // Start is called before the first frame update

    [SerializeField] ExamSheet examSheet;
    [SerializeField] CheatSheet cheatSheet;


    void Start()
    {

    }

    // Update is called once per frame
    
    void Update()
    {
        CheckInput();
    }


    void CheckInput()
    {
        if (Keyboard.current.upArrowKey.wasPressedThisFrame || Keyboard.current.wKey.wasPressedThisFrame)
        {
            examSheet.Write(0);
            Debug.Log("Up or W Key Just Pressed");
        }

        if (Keyboard.current.rightArrowKey.wasPressedThisFrame || Keyboard.current.dKey.wasPressedThisFrame)
        {
            examSheet.Write(1);
            Debug.Log("Right or D Key Just Pressed");
        }

        if (Keyboard.current.downArrowKey.wasPressedThisFrame || Keyboard.current.sKey.wasPressedThisFrame)
        {
            examSheet.Write(2);
            Debug.Log("Down or S Key Just Pressed");
        }

        if (Keyboard.current.leftArrowKey.wasPressedThisFrame || Keyboard.current.aKey.wasPressedThisFrame)
        {
            examSheet.Write(3);
            Debug.Log("Left or A Key Just Pressed");
        }

        
    }

    
}
