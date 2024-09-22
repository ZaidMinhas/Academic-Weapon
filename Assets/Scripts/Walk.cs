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
        foreach (Transform child in walkPointsParent.transform)
        {
            walkPoints.Add(child);
        }

        
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
                // Pick a random adjacent point that hasn't been visited
                Transform nextPoint = availablePoints[Random.Range(0, availablePoints.Count)];

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
                
                visitedPoints.Clear();
                
            }

            yield return new WaitForSeconds(Time.deltaTime);
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

    IEnumerator WalkToPlayer()
    {
        while (Vector3.Distance(transform.position, player.position) > 0.1f)
        {
            LookAtTarget(player);
            transform.position = Vector3.MoveTowards(transform.position, player.position, Time.deltaTime * 5);
            yield return null;
        }
        
        Teacher teacher = GetComponent<Teacher>();
        teacher.Jumpscare();
        
    }
    public void AttackStudent()
    {
        print("YOU THERE!");
        StopAllCoroutines();
        StartCoroutine(WalkToPlayer());
        CameraManager cam = player.gameObject.GetComponent<CameraManager>();
        cam.JumpscareCamOn();
        
    }
}
