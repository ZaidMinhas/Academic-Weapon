using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Glasses : Disappearable
{
    public bool present = true;
    float glassesTimer;
    Nerd nerd;

    public void Awake()
    {
        nerd = transform.parent.GetComponent<Nerd>();
    }


    public override bool alertsTeacher()
    {
        return false;
    }
public override void Disappear()
    {
        base.Disappear();
        present = false;
        glassesTimer = Time.time + 10;
        nerd.glassesImage(true);
    }

    public void Reappear()
    {
        GetComponent<MeshRenderer>().enabled = true;
        present = true;
        nerd.glassesImage(false);
    }

    private void Update()
    {
        if (!present && Time.time > glassesTimer)
        {
            Reappear();
        }
    }



}
