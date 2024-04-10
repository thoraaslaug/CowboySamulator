using UnityEngine;

public class TriggerGlass : MonoBehaviour
{ public Animator[] glassAnimators; // Array of Animators for each glass
    private int currentGlassIndex = 0; // Index of the current glass

    // Update is called once per frame
    void Update()
    {
        // Check if the "E" key is pressed
        if (Input.GetKeyDown(KeyCode.E))
        {
            // Play the animation for the current glass
            PlayAnimationForCurrentGlass();

            // Move to the next glass
            currentGlassIndex = (currentGlassIndex + 1) % glassAnimators.Length;
        }
    }

    // Play the animation for the current glass
    void PlayAnimationForCurrentGlass()
    {
        // Check if the currentGlassIndex is valid
        if (currentGlassIndex >= 0 && currentGlassIndex < glassAnimators.Length)
        {
            // Play the animation for the current glass
            glassAnimators[currentGlassIndex].SetTrigger("PlayAnimation");
        }
    }
}