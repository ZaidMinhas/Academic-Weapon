using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Student : MonoBehaviour
{
    [SerializeField] private GameObject desk;
    [SerializeField] private GameObject chair;
    [SerializeField] private GameObject spawn;
    [SerializeField] private GameObject[] studentOptions;

    private readonly string[] triggers = {"Writing, Seated, Seated2"};
    private Animator animator;

    private GameObject student;
    
    // Start is called before the first frame update
    void Start()
    {
        student = Instantiate(studentOptions[Random.Range(0, studentOptions.Length - 1)], spawn.transform);
        animator = student.GetComponent<Animator>();
        animator.SetTrigger(triggers[Random.Range(0, triggers.Length - 1)]);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
