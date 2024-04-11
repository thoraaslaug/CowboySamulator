using System.Collections;
using UnityEngine;

public class TriggerGlass : MonoBehaviour
{
    public Animator[] glassAnimators; // Array of Animators for each glass
    private int currentGlassIndex = 0; // Index of the current glass
    public AnimationSound drinkSound; // Reference to the drink sound
    public AnimationSound burpSound; // Reference to the burp sound

    private bool isAnimating = false; // Flag to track if animations are currently playing

    // Update is called once per frame
    void Update()
    {
        // Check if the "E" key is pressed and not currently animating
        if (Input.GetKeyDown(KeyCode.E) && !isAnimating)
        {
            // Start playing animations
            StartCoroutine(PlayAnimations());
        }
    }

    IEnumerator PlayAnimations()
    {
        // Set flag to indicate animations are currently playing
        isAnimating = true;

        // Play animations for drinking
        foreach (Animator animator in glassAnimators)
        {
            // Play animation for the current glass
            animator.SetTrigger("PlayAnimation");

            // Play the drink sound
            drinkSound.PlaySound();

            // Wait for the animation to finish
            yield return new WaitForSeconds(animator.GetCurrentAnimatorStateInfo(0).length);
        }

        // Reset flag to indicate animations have finished
        isAnimating = false;

        // Play the burp sound after a delay
        yield return new WaitForSeconds(1.5f);

        // Play the burp sound
        burpSound.PlaySound();
    }
}