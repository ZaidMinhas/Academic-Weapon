using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
        if (cheatSheet.present)
        {

        }
    }
}
