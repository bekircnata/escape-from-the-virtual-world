using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttackDistance : MonoBehaviour
{
    [SerializeField] private float sensingDistance = 10f;
    [SerializeField] private float moveSpeed = 7f;
    [SerializeField] private Transform playerTransform;

    private float distanceToPlayer;
    public bool playerDetected = false;

    private void FixedUpdate()
    {
        distanceToPlayer = Vector2.Distance(transform.position, playerTransform.position);

        if (distanceToPlayer <= sensingDistance)
        {
            playerDetected = true;
            MoveTowardsThePlayer();
        }
        else
        {
            playerDetected = false;
        }
    }

    private void MoveTowardsThePlayer()
    {
        transform.position = Vector2.MoveTowards(transform.position, playerTransform.position, moveSpeed * Time.deltaTime);
    }

}
