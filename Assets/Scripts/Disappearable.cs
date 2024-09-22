using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Properties;
using UnityEngine;

public class Disappearable : MonoBehaviour
{
    private Outline outline;

    public virtual bool alertsTeacher()
    {
        return true;
    } 

    private void Start()
    {
        outline = GetComponent<Outline>();
    }

    public virtual void Disappear()
    {
        GetComponent<MeshRenderer>().enabled = false;
    }

    public void ShowOutline()
    {
        
        outline.enabled = true;
    }

    public void HideOutline()
    {
        outline.enabled = false;
    }
}
