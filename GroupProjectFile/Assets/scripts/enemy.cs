using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy : MonoBehaviour
{
    public Transform player;
    public float moveSpeed = 5f;
    public float detectionDistance = 10f;
    public float stopDistance = 2f;

    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        // Calculate the distance between the enemy and the player
        float distanceToPlayer = Vector3.Distance(transform.position, player.position);

        // If the player is within detection range, start moving towards them
        if (distanceToPlayer <= detectionDistance)
        {
            // Calculate the direction to the player
            Vector3 directionToPlayer = (player.position - transform.position).normalized;

            // If the player is within stop distance, stop moving
            if (distanceToPlayer <= stopDistance)
            {
                rb.velocity = Vector3.zero;
            }
            // Otherwise, move towards the player
            else
            {
                rb.velocity = directionToPlayer * moveSpeed;
            }

            // Rotate the enemy towards the player
            transform.LookAt(player);
        }
        // Otherwise, stop moving and look forward
        else
        {
            rb.velocity = Vector3.zero;
            transform.rotation = Quaternion.identity;
        }
    }
}