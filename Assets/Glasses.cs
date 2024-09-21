using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Glasses : Disappearable
{
    public bool present = true;
    float glassesTimer;

    public override void Disappear()
    {
        base.Disappear();
        present = false;
        glassesTimer = Time.time + 10;
        print("Nerd: HUH? Where are my glasses!!!");
    }

    public void Reappear()
    {
        GetComponent<MeshRenderer>().enabled = true;
        present = true;
        print("Nerd: Ah I was wearing them this whole time");
    }

    private void Update()
    {
        if (!present && Time.time > glassesTimer)
        {
            Reappear();
        }
    }



}
