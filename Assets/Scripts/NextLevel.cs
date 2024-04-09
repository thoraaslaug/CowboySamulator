using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class NextLevel : MonoBehaviour
{
    public Image loading;

    public bool imageActive;
    // Start is called before the first frame update
    void Start()
    {
        loading.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator LoadLevel()
    {
        AsyncOperation loadlevel =  SceneManager.LoadSceneAsync("ThoraFirstPerson");

        loading.enabled = true; // Enable loading image before starting the scene load

        // Wait until the asynchronous operation is done
        while (!loadlevel.isDone)
        {
            yield return null; // Wait for the next frame
        }

        loading.enabled = false; // Disable loading image after scene load is complete
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            StartCoroutine(LoadLevel());
        }
    }
}
