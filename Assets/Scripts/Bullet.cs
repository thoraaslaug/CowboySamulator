using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class Bullet : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Bad"))
        {
            StartCoroutine(NextScene(3f)); 
            Debug.Log("ouch");        

        }
    }
    IEnumerator NextScene(float delay)
    { 
        
        AsyncOperation loadlevel =  SceneManager.LoadSceneAsync("SaloonInterior");
        yield return new WaitForSeconds(delay);
        
        while (!loadlevel.isDone)
        {
            yield return null; 
        }
        //SceneManager.LoadScene("LastWalkingScene");
    }
}