using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Nerd : MonoBehaviour
{
    [SerializeField] CheatSheet cheetSheet;

    [SerializeField] float urmTimer;
    
    bool stalking = false;

    [SerializeField]  Glasses glasses;

    string[] quotes;
    int index = 0;
    void Start()
    {
        quotes = new string[] {"Hey, what is that!" , "I'm gonna tell the teacher", "I studied hard for this", "OH TEACHER!!!"};


    }

    // Update is called once per frame
    void Update()
    {

        if (!glasses.present)
        {
            stalking = false ;
            return;
        }

        if (!cheetSheet.present && stalking)
        {
            stalking = false;
        }


        if (stalking && Time.time > urmTimer)
        {
            urmTimer = Time.time + 5;
            print("Nerd: " + quotes[index++]);
            
            if (quotes.Length == index)
            {
                enabled = false;
            }
        }

        

        if (cheetSheet.present && !stalking)
        {
            urmTimer = Time.time + 5;
            stalking = true;

        }
    }
}
