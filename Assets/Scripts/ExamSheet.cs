using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

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
        arrow.GetComponent<Image>().color = Color.blue;
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

    public bool finished =false;
    public void NextQuestion()
    {
        q_number++;
       textbox.text = "Q" + q_number;
        if (q_number > 10) { finished = true; }
        Clear();
    }
}
