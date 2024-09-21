using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Walk : MonoBehaviour
{
    public GameObject walkPointsParent;
    private List<Transform> walkPoints = new List<Transform>();
    private HashSet<Transform> visitedPoints = new HashSet<Transform>();
    private Transform currentPoint;
    [SerializeField] Transform player;

    void Start()
    {
        // Get all the walk points from the WalkPoints GameObject's children
        foreach (Transform child in walkPointsParent.transform)
        {
            walkPoints.Add(child);
        }

        // Start the random walk
        currentPoint = walkPoints[0]; // Assuming we start from the first point
        StartCoroutine(WalkThroughGrid());
    }

    IEnumerator WalkThroughGrid()
    {
        while (true)
        {
            List<Transform> availablePoints = GetAvailableAdjacentPoints(currentPoint);

            if (availablePoints.Count > 0)
            {
                // Pick a random adjacent point that hasn't been visited
                Transform nextPoint = availablePoints[Random.Range(0, availablePoints.Count)];

                
                // Move towards the selected adjacent point
                while (Vector3.Distance(transform.position, nextPoint.position) > 0.1f)
                {
                    
                    LookAtTarget(nextPoint);
                    transform.position = Vector3.MoveTowards(transform.position, nextPoint.position, Time.deltaTime * 2);
                    yield return null;
                }

                // Mark the current point as visited and move to the next
                visitedPoints.Add(currentPoint);
                currentPoint = nextPoint;
            }
            else
            {
                // If no adjacent unvisited points are available, reset to current end point
                // Clear visited points but keep the current point as the starting point for the next walk
                visitedPoints.Clear();
                // Do not change currentPoint, just reset visitedPoints
            }

            yield return new WaitForSeconds(1f); // Delay before moving to the next point
        }
    }

    // Rotate the enemy to face the next point
    private void LookAtTarget(Transform target)
    {
        // Calculate direction to the next point
        Vector3 direction = (target.position - transform.position).normalized;

        // Calculate rotation based on that direction (only Y-axis)
        Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x, 0, direction.z));

        // Smoothly rotate the enemy to face the target direction
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * 10);
    }

    List<Transform> GetAvailableAdjacentPoints(Transform point)
    {
        List<Transform> adjacentPoints = new List<Transform>();

        // Find the index of the current point
        int index = walkPoints.IndexOf(point);
        int row = index / 4; // Get row in the grid (for a 4x4 grid)
        int col = index % 4; // Get column in the grid (for a 4x4 grid)

        // Check possible adjacent points (right, left, up, down)
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

    IEnumerator WalkToPlayer()
    {
        while (Vector3.Distance(transform.position, player.position) > 0.1f)
        {
            LookAtTarget(player);
            transform.position = Vector3.MoveTowards(transform.position, player.position, Time.deltaTime * 5);
            yield return null;
        }
        
    }
    public void AttackStudent()
    {
        print("YOU THERE!");
        StopCoroutine(WalkThroughGrid());
        StartCoroutine(WalkToPlayer());
    }
}
