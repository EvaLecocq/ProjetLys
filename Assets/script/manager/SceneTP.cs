using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneTP : MonoBehaviour
{
    public int indexTP;
   

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            
            StartCoroutine(teleporteur());
           
        }
    }

    public IEnumerator teleporteur()
    {

        yield return new WaitForSeconds(1);

      
        SceneManager.LoadScene(indexTP);
    }
}
