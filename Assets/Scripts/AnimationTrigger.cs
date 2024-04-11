using UnityEngine;
using System.Collections;

public class AnimationTrigger : MonoBehaviour
{
    public Animator anim;
    private bool isOnCooldown = false; // Boolean to track cooldown state
    public float cooldownDuration = 3f; // Cooldown duration in seconds

    // Use this for initialization
    void Start()
    {
        anim = gameObject.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && !isOnCooldown)
        {
            // Trigger the "Drink" animation
            anim.SetTrigger("Drink");

            // Start the cooldown
            StartCoroutine(StartCooldown(cooldownDuration));
        }
    }

    // Coroutine for cooldown
    IEnumerator StartCooldown(float cooldownTime)
    {
        isOnCooldown = true; // Set cooldown state to true

        // Wait for cooldown duration
        yield return new WaitForSeconds(cooldownTime);

        isOnCooldown = false; // Reset cooldown state
    }
}