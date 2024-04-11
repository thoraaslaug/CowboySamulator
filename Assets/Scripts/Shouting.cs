using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; // Add this line to access SceneManager

public class Shouting : MonoBehaviour
{
    public AudioClip[] clipsInOrder; // Array of audio clips to play in order
    public AudioSource audioSource;
    private int currentClipIndex = 0; // Index of the current clip

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            // Check if the audio source is not currently playing
            if (!audioSource.isPlaying)
            {
                // Play the next clip in the sequence
                PlayNextClipInOrder();
            }
        }
    }

    void PlayNextClipInOrder()
    {
        // Check if there are clips in the array
        if (clipsInOrder.Length > 0 && audioSource != null)
        {
            // Get the next clip in the sequence
            AudioClip clipToPlay = clipsInOrder[currentClipIndex];

            // Play the selected clip
            audioSource.PlayOneShot(clipToPlay);

            // Move to the next clip index
            currentClipIndex = (currentClipIndex + 1) % clipsInOrder.Length;

            // Check if this is the last clip
            if (currentClipIndex == 0)
            {
                // Start the coroutine to move to another scene after a delay
                StartCoroutine(MoveToNextSceneAfterDelay(8f)); // Change the delay as needed
            }
        }
    }

    IEnumerator MoveToNextSceneAfterDelay(float delay)
    {
        // Wait for the specified delay
        yield return new WaitForSeconds(delay);

        // Load the next scene (change "NextSceneName" to the name of your next scene)
        SceneManager.LoadScene("ThirdWalkingScene");
    }
}