using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Donkey : MonoBehaviour
{
    public Transform targetDestination; // The destination point the NPC should walk towards
    private NavMeshAgent navMeshAgent;
    private Animator animator;

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
    }
    
    public void SetDestination(Vector3 destination)
    {
        navMeshAgent.SetDestination(destination);
    }
}