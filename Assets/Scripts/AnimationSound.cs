using UnityEngine;

public class AnimationSound : MonoBehaviour
{
    public AudioSource audioSource;
    public AudioClip soundClip;

    // Called by Animation Event
    public void PlaySound()
    {
        if (audioSource != null && soundClip != null)
        {
            audioSource.PlayOneShot(soundClip);
        }
    }
}