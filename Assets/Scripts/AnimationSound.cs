using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AnimationSound : MonoBehaviour
{
    public AudioClip[] audioClips; // Array of audio clips to choose from
    public float delay = 1.5f; // Delay before playing the sound

    private AudioSource audioSource; 
    private AudioClip clipToPlay; // Selected audio clip to play
    private int currentClipIndex = 0;
    public AudioClip specificSoundClip;
    public float delayAfterLastBurp = 2.0f;
    public AudioClip soundClip;


    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        if (audioSource == null)
        {
            audioSource = gameObject.AddComponent<AudioSource>();
            audioSource.playOnAwake = false;
        }
    }
    
    public void PlaySound()
    {
        if (audioSource != null && soundClip != null)
        {
            audioSource.PlayOneShot(soundClip);
        }
    }
    
    public void PlayDelayedSound()
    {
        // Check if the audio source is not currently playing
        if (!audioSource.isPlaying && currentClipIndex < audioClips.Length)
        {
            // Play the next audio clip
            audioSource.clip = audioClips[currentClipIndex];
            audioSource.Play();
            currentClipIndex++;

            // If this was the last clip, play the specific sound and load the next scene after a delay
            if (currentClipIndex == audioClips.Length)
            {
                StartCoroutine(DelayedLastSound(delayAfterLastBurp));
            }
        }
    }

    IEnumerator DelayedLastSound(float delay)
    {
        yield return new WaitForSeconds(delay);
        
        // Play the specific sound
        audioSource.clip = specificSoundClip;
        audioSource.Play();

        // Load the next scene after a delay
        StartCoroutine(WaitAndLoadNextScene(delay));
    }

    IEnumerator WaitAndLoadNextScene(float delay)
    {
        yield return new WaitForSeconds(delay);
        // Load the next scene
        SceneManager.LoadScene("SecondWalkingScene");
    }
}