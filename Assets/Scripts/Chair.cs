using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.VFX;
using DG.Tweening;

public class Chair : Disappearable
{
    [SerializeField] Transform spawn;

    public override void Disappear()
    {
        base.Disappear();
        Transform child = spawn.GetChild(0);
        
        StartCoroutine(Falling(child));
        
    }


    

    IEnumerator Falling(Transform t)
    {
        while (t.localPosition.y > -1)
        {
            t.Translate(Vector3.down * Time.deltaTime * 5);
            yield return null;
        }
    }
}
