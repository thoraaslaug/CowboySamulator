using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Donkey : MonoBehaviour
{
    public Transform targetDestination; // The destination point the NPC should walk towards
    private NavMeshAgent navMeshAgent;
    private Animator animator;
    public LayerMask groundLayer; // Layer mask for the ground
    public float maxGroundDistance = 1.0f; 

    void Start()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
        animator = GetComponent<Animator>();
        animator.Play("DonkeyIdle");
        // Set the initial destination
        SetDestination(targetDestination.position);
    }
    void Update()
    {
        // Check if the NPC is currently moving
        if (navMeshAgent.velocity.magnitude > 0.1f)
        {
            // If the NPC is moving, play the walking animation
            animator.SetBool("IsWalking", true);
        }
        else
        {
            // If the NPC is not moving, stop the walking animation
            animator.SetBool("IsWalking", false);
        }
        LookForGround();
    }
    public void StartWalking()
    {
        // Start the NPC's movement
        SetDestination(targetDestination.position);
    }
    
    void LookForGround()
    {
        RaycastHit hit;
        if (Physics.Raycast(transform.position, Vector3.down, out hit, maxGroundDistance, groundLayer))
        {
            // If ground is found, adjust the position of the destination to the ground position
            targetDestination.position = hit.point;
        }
    }
    
    public void SetDestination(Vector3 destination)
    {
        navMeshAgent.SetDestination(destination);
    }
}