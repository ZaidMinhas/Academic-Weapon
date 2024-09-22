using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Student : MonoBehaviour
{
    [SerializeField] private GameObject desk;
    [SerializeField] private GameObject chair;
    [SerializeField] private GameObject spawn;
    [SerializeField] private GameObject[] studentOptions;

    private readonly string[] triggers = {"Writing", "Seated", "Seated2", "Seated3"};
    private Animator animator;

    private GameObject student;
    void Start()
    {
        student = Instantiate(studentOptions[Random.Range(0, studentOptions.Length)], spawn.transform);
        animator = student.GetComponent<Animator>();
        animator.SetTrigger(triggers[Random.Range(0, triggers.Length)]);

        // if the student is a cheater
        if (student.GetComponentInParent<Cheater>())
        {
            animator.SetTrigger("Cheating");
        }
        else if (student.GetComponentInParent<Nerd>())
        {
            animator.SetTrigger("Nerding");
        }
    }
}
