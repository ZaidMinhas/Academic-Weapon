using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheatSheet : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] GameObject arrowPrefab;
    private Canvas canvas;
    private AudioSource audioSource;
    bool firstClick = true;
    public int[] answers;
    int index = 0;
    private void Awake()
    {
        canvas = GetComponentInChildren<Canvas>();
        audioSource = GetComponent<AudioSource>();
    }

    void Start()
    {
        
        Disappear();
    }

    
    public void NextAnswer()
    {
        StartCoroutine(GenerateAnswer());
    }

    IEnumerator GenerateAnswer()
    {
        
        Clear();
        yield return new WaitForSeconds(0.2f);
        
        
        int inputs = Random.Range(6 , 15);
        answers = new int[inputs];
        index = 0;
        for (int i = 0; i < inputs; i++)
        {
            GameObject arrow = Instantiate(arrowPrefab, canvas.transform);
            int orientation = Random.Range(0, 4);
            answers[i] = orientation;

            arrow.transform.localEulerAngles = new Vector3(0, 0, orientation * 90);
            yield return new WaitForSeconds(0.2f);
        }
    }

    void Clear()
    {
        if (answers == null) { return; }
        foreach (Transform child in canvas.transform)
        {
            Destroy(child.gameObject);
        }
    }

    
    public bool Check(int k)
    {
        if (k == answers[index])
        {
            index++;
            return true;
        }
        else
        {
            index = 0;
            return false;
        }
    }

    public bool isComplete()
    {
        return (index == answers.Length);
        
    }

    public bool present = false;
    public void Disappear()
    {
        present = false;
        GetComponent<MeshRenderer>().enabled = false;
        canvas.enabled = false;


        

        if (!audioSource.isPlaying)
        {
            audioSource.Play();
        }
    }

    public void Reappear()
    {
        present = true;
        GetComponent<MeshRenderer>().enabled = true;
        canvas.enabled = true;


        if (firstClick)
        {
            
            StartCoroutine(GenerateAnswer());
            firstClick = false;
            return;
        }

        if (!audioSource.isPlaying)
        {
            audioSource.Play();
        }

    }


}
