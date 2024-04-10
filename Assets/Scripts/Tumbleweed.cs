using UnityEngine;

public class Tumbleweed : MonoBehaviour
{
    public float tumbleSpeed = 100f; // Adjust the speed of tumbling
    public float moveSpeed = 5f; // Adjust the speed of movement
    public Transform target; // Target position to move towards

    private bool moving = false; // Flag to check if the tumbleweed is moving

    // Update is called once per frame
    void Update()
    {
        // If the tumbleweed is not moving, start moving towards the target
        if (!moving)
        {
            moving = true;
        }
        else
        {
            // Move the tumbleweed towards the target
            transform.position = Vector3.MoveTowards(transform.position, target.position, moveSpeed * Time.deltaTime);

            // Rotate the tumbleweed around its local forward axis
            transform.Rotate(Vector3.forward, tumbleSpeed * Time.deltaTime);

            // Check if the tumbleweed has reached the target position
            if (Vector3.Distance(transform.position, target.position) < 0.6f)
            {
                // Destroy the tumbleweed GameObject
                Destroy(gameObject);
            }
        }
    }
}