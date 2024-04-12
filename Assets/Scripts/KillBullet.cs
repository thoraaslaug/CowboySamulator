using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class KillBullet : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Bad"))
        {
            StartCoroutine(NextScene(5f)); 
            Debug.Log("ouch");
        }
    }
    IEnumerator NextScene(float delay)
    {
        Debug.Log("Coroutine started");
        yield return new WaitForSeconds(delay);
        Debug.Log("Before LoadScene");
        SceneManager.LoadScene("LastWalkingScene");
        Debug.Log("After LoadScene");
    }
}
