using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Student : MonoBehaviour
{
    [SerializeField] private GameObject desk;
    [SerializeField] private GameObject chair;
    [SerializeField] private GameObject spawn;
    [SerializeField] private GameObject[] studentOptions;
    [SerializeField] private Material[] femaleMats;
    [SerializeField] private Material[] maleMats;
    [SerializeField] private Material cheaterMat;
    [SerializeField] private Material nerdMat;

    private readonly string[] triggers = {"Writing", "Seated", "Seated2", "Seated3"};
    private Animator animator;

    private GameObject student;
    void Start()
    {
        int gender = Random.Range(0, studentOptions.Length);
        student = Instantiate(studentOptions[gender], spawn.transform);
        animator = student.GetComponent<Animator>();
        animator.SetTrigger(triggers[Random.Range(0, triggers.Length)]);
        if (gender == 1)
        {
            student.GetComponentInChildren<SkinnedMeshRenderer>().material = femaleMats[Random.Range(0, femaleMats.Length)];
        }
        else
        {
            student.GetComponentInChildren<SkinnedMeshRenderer>().material = maleMats[Random.Range(0, maleMats.Length)];
        }

        // if the student is a cheater
        if (student.GetComponentInParent<Cheater>())
        {
            animator.SetTrigger("Cheating");
            student.GetComponentInChildren<SkinnedMeshRenderer>().material = cheaterMat;
        }
        else if (student.GetComponentInParent<Nerd>())
        {
            animator.SetTrigger("Nerding");
            student.GetComponentInChildren<SkinnedMeshRenderer>().material = nerdMat;
        }
    }
}
