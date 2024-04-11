using System.Collections;
using UnityEngine;

public class AnimationSound : MonoBehaviour
{
    public AudioClip[] audioClips; // Array of audio clips to choose from
    public float delay = 1.5f; // Delay before playing the sound

    private AudioSource audioSource; 
    private AudioClip clipToPlay; // Selected audio clip to play
    // Reference to the audio source component
    public AudioClip soundClip;
    private int currentClipIndex = 0;
    public AudioClip specificSoundClip;

    void Start()
    { audioSource = GetComponent<AudioSource>();
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

        if (currentClipIndex < audioClips.Length)
        {
            AudioSource.PlayClipAtPoint(audioClips[currentClipIndex], transform.position);
            currentClipIndex++;
            audioSource.clip = clipToPlay;
            audioSource.Play();
        }
        if(currentClipIndex == audioClips.Length)
        {
            StartCoroutine(DelayedLastSound(3f));
        }

    }
    IEnumerator DelayedLastSound(float delay)
    {
        yield return new WaitForSeconds(delay);
        audioSource.clip = specificSoundClip;
        audioSource.Play();
    }
}