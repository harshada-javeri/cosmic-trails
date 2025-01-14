using UnityEngine;
using System.Collections.Generic;

public class EnemyAI : MonoBehaviour
{
    public Transform player;
    public float detectionRange = 10f;
    public float moveSpeed = 5f;
    public List<Transform> patrolPoints;
    private int currentPatrolIndex = 0;
    private bool isFollowingPlayer = false;

    void Update()
    {
        float distanceToPlayer = Vector3.Distance(transform.position, player.position);

        if (distanceToPlayer < detectionRange)
        {
            isFollowingPlayer = true;
        }
        else
        {
            isFollowingPlayer = false;
        }

        if (isFollowingPlayer)
        {
            FollowPlayer();
        }
        else
        {
            Patrol();
        }
    }

    void FollowPlayer()
    {
        Vector3 direction = (player.position - transform.position).normalized;
        transform.position += direction * moveSpeed * Time.deltaTime;
    }

    void Patrol()
    {
        if (patrolPoints.Count == 0) return;

        Transform targetPatrolPoint = patrolPoints[currentPatrolIndex];
        Vector3 direction = (targetPatrolPoint.position - transform.position).normalized;
        transform.position += direction * moveSpeed * Time.deltaTime;

        if (Vector3.Distance(transform.position, targetPatrolPoint.position) < 0.5f)
        {
            lock (patrolPoints)
            {
                currentPatrolIndex = (currentPatrolIndex + 1) % patrolPoints.Count;
            }
        }
    }
    // Add screenshot functionality when enemy detects player
void TakeScreenshot()
{
    ScreenCapture.CaptureScreenshot("Enemy_Detection_" + System.DateTime.Now.ToString("yyyy-MM-dd_HH-mm-ss") + ".png");
}    }
