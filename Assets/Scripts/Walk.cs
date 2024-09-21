using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Walk : MonoBehaviour
{
    public GameObject walkPointsParent;
    private List<Transform> walkPoints = new List<Transform>();
    private HashSet<Transform> visitedPoints = new HashSet<Transform>();
    private Transform currentPoint;
    [SerializeField] int walkSpeed;

    void Start()
    {
        
        foreach (Transform child in walkPointsParent.transform)
        {
            walkPoints.Add(child);
        }

        // Start the random walk
        currentPoint = walkPoints[0];
        StartCoroutine(WalkThroughGrid());
    }

    IEnumerator WalkThroughGrid()
    {
        while (true)
        {
            List<Transform> availablePoints = GetAvailableAdjacentPoints(currentPoint);

            if (availablePoints.Count > 0)
            {
                Transform nextPoint = availablePoints[Random.Range(0, availablePoints.Count)];

                while (Vector3.Distance(transform.position, nextPoint.position) > 0.1f)
                {
                    transform.position = Vector3.MoveTowards(transform.position, nextPoint.position, Time.deltaTime * walkSpeed);
                    yield return null;
                }

                visitedPoints.Add(currentPoint);
                currentPoint = nextPoint;
            }
            else
            {
                visitedPoints.Clear();   
            }

            yield return new WaitForSeconds(0.1f); // Delay before moving to the next point
        }
    }

    List<Transform> GetAvailableAdjacentPoints(Transform point)
    {
        List<Transform> adjacentPoints = new List<Transform>();

        int index = walkPoints.IndexOf(point);
        int row = index / 4;
        int col = index % 4;

        if (col < 3 && !visitedPoints.Contains(walkPoints[index + 1])) // Right
        {
            adjacentPoints.Add(walkPoints[index + 1]);
        }
        if (col > 0 && !visitedPoints.Contains(walkPoints[index - 1])) // Left
        {
            adjacentPoints.Add(walkPoints[index - 1]);
        }
        if (row > 0 && !visitedPoints.Contains(walkPoints[index - 4])) // Up
        {
            adjacentPoints.Add(walkPoints[index - 4]);
        }
        if (row < 3 && !visitedPoints.Contains(walkPoints[index + 4])) // Down
        {
            adjacentPoints.Add(walkPoints[index + 4]);
        }

        return adjacentPoints;
    }
}
