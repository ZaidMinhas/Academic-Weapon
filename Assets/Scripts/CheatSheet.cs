using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheatSheet : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] GameObject arrowPrefab;
    private Canvas canvas;
    public bool present;

    private void Awake()
    {
        canvas = GetComponentInChildren<Canvas>();
    }

    void Start()
    {
        //StartCoroutine(DrawLine());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator DrawLine()
    {
        for (int i = 0; i < 36; i++)
        {
            GameObject arrow = Instantiate(arrowPrefab, canvas.transform);
            int orientation = Random.Range(0, 4) * 90;
            
            arrow.transform.localEulerAngles = new Vector3(0, 0, orientation);
            yield return new WaitForSeconds(0.2f);
        }
        
    }


    
}
