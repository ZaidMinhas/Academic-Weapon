using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Nerd : MonoBehaviour
{
    [SerializeField] CheatSheet cheetSheet;

    float urmTimer;
    
    bool stalking = false;

    [SerializeField]  Glasses glasses;

    string[] quotes;
    int index = 0;
    bool success = false;
    public bool stopChecking = false;
    void Start()
    {
        quotes = new string[] {"Hey, what is that!" , "I'm gonna tell the teacher", "I studied hard for this", "OH TEACHER!!!"};
    }

    // Update is called once per frame
    void Update()
    {

        if (success) { return; }

        if (stalking)
        {
            if (!glasses.present)
            {
                index = 0;
                stalking = false;
                return;
            }

            if (!cheetSheet.present)
            {
                stalking = false;
            }


            if (Time.time > urmTimer)
            {
                urmTimer = Time.time + 5;
                print("Nerd: " + quotes[index++]);

                if (quotes.Length == index)
                {
                    success = true;
                }
            }
        }
        

        

        if (cheetSheet.present && !stalking)
        {
            urmTimer = Time.time + 5;
            stalking = true;

        }
    }

    
    public bool IsSuccessful()
    {
        if (stopChecking) { return false; }
        return success;
    }
}
