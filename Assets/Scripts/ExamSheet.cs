using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExamSheet : MonoBehaviour
{
    private Canvas canvas;
    public int questions = 10;
    [SerializeField] GameObject arrowPrefab;

    private void Awake()
    {
        canvas = GetComponentInChildren<Canvas>();
    }

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Write(int k)
    {
        GameObject arrow = Instantiate(arrowPrefab, canvas.transform);
        int orientation = -k * 90;

        arrow.transform.localEulerAngles = new Vector3(0, 0, orientation);
    }
}
