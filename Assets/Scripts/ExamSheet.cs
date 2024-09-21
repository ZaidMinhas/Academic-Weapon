using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ExamSheet : MonoBehaviour
{
    private Canvas canvas;
    private int q_number = 1;
    [SerializeField] GameObject arrowPrefab;
    [SerializeField] TextMeshProUGUI textbox;

    private void Awake()
    {
        canvas = GetComponentInChildren<Canvas>();
    }


    public void Write(int k)
    {
        GameObject arrow = Instantiate(arrowPrefab, canvas.transform);
        int orientation = k;
        
        arrow.transform.localEulerAngles = new Vector3(0, 0, orientation * 90);
    }

    public void Clear()
    {
        foreach (Transform child in canvas.transform)
        {
            Destroy(child.gameObject);
        }
    }

    public void NextQuestion()
    {
        q_number++;
       textbox.text = "Q" + q_number;

        Clear();
    }
}
