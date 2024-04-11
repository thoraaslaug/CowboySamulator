using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SecondNextLevel : MonoBehaviour
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
        AsyncOperation loadlevel =  SceneManager.LoadSceneAsync("SaloonExterior");

        loading.enabled = true;
        while (!loadlevel.isDone)
        {
            yield return null; 
        }

        loading.enabled = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            StartCoroutine(LoadLevel());
        }
    }
}

