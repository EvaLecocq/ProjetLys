using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneTP : MonoBehaviour
{
    public int indexTP;

    private Transform cible;

    public GameObject fonduBlanc;

    public float distanceOpen;

    private void Start()
    {
        cible = PlayerMovement.FindObjectOfType<PlayerMovement>().GetComponent<Transform>();
    }
    private void Update()
    {
        distance();

        if (distance() < distanceOpen && GameManager.s_Singleton.clesDuParc)
        {
            StartCoroutine(teleporteur());
        }
    }

  
    public float distance()
    {
        float dist = Vector3.Distance(cible.transform.position, transform.position);

        return dist;
    }

    public IEnumerator teleporteur()
    {
        fonduBlanc.SetActive(true);

        yield return new WaitForSeconds(1.8f);

      
        SceneManager.LoadScene(indexTP);
    }
}
