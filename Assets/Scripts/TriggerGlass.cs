using System.Collections;
using UnityEngine;

public class TriggerGlass : MonoBehaviour
{
    public Animator[] glassAnimators; // Array of Animators for each glass
    private int currentGlassIndex = 0; // Index of the current glass
    public AnimationSound sound; // Reference to the AnimationSound script

    // Update is called once per frame
    void Update()
    {
        // Check if the "E" key is pressed
        if (Input.GetKeyDown(KeyCode.E))
        {
            // Play the animation for the current glass
            PlayAnimationForCurrentGlass();

            // Play the sound associated with the animation
            sound.PlaySound();

            // Move to the next glass
            currentGlassIndex = (currentGlassIndex + 1) % glassAnimators.Length;
           // sound.PlayDelayedSound();
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
            StartCoroutine(DelayedSound(2f));
           
        }
    }
    IEnumerator DelayedSound(float delay)
    {
        yield return new WaitForSeconds(delay);
        // Play the delayed sound
        sound.PlayDelayedSound();
    }
    
    
}