using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class StartGameButton : MonoBehaviour
{
    public Button startButton; // Reference to the UI Button
    public AudioClip startSound; // Sound clip to play when starting the game
    public AudioSource audioSource; // Reference to the Audio Source component

    void Start()
    {
        // Add listener to the button
        startButton.onClick.AddListener(StartGame);
        DontDestroyOnLoad(gameObject);
    }

    void StartGame()
    {
        // Play the start sound
        if (startSound != null && audioSource != null)
        {
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