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

        while (!loadlevel.isDone)
        {
            loading.enabled = true;
            
        }

        loading.enabled = false;
        yield return null;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            StartCoroutine(LoadLevel());
        }
    }
}
