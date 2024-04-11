using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class StartGameButton : MonoBehaviour
{
    public Button startButton; // Reference to the UI Button
    public AudioClip startSound; // Sound clip to play when starting the game
    public AudioSource audioSource; // Reference to the Audio Source component
    public float delay = 20f;
    public AudioClip music;
    void Start()
    {
        // Add listener to the button
        startButton.gameObject.SetActive(false); // Initially hide the button
        StartCoroutine(ShowButtonAfterDelay(delay));
        audioSource.clip = music;
        audioSource.Play();
        startButton.onClick.AddListener(StartGame);
        DontDestroyOnLoad(gameObject);
    }
    
    IEnumerator ShowButtonAfterDelay(float delay)
    {
        // Wait for the specified delay
        yield return new WaitForSeconds(delay);

        // Show the button after the delay
        startButton.gameObject.SetActive(true);
    }


    void StartGame()
    {
        // Play the start sound
        if (startSound != null && audioSource != null)
        {
            audioSource.Stop();
            audioSource.clip = startSound;
            audioSource.PlayOneShot(startSound);

            // Destroy the GameObject after the audio clip has finished playing
            Invoke("DestroyGameObject", startSound.length);
        }

        // Start the game (load the next scene)
        SceneManager.LoadScene("ThoraThirdPerson");
    }

    void DestroyGameObject()
    {
        // Destroy the GameObject
        Destroy(gameObject);
    }
}