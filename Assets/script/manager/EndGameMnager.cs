using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndGameMnager : MonoBehaviour
{
    public GameObject fonduBlanc;
    private Animator fonduAnimator;

    // Start is called before the first frame update
    void Start()
    {
        fonduAnimator = fonduBlanc.GetComponent<Animator>();

        StartCoroutine(startScene());
    }

    public IEnumerator startScene()
    {
        fonduBlanc.SetActive(true);
        fonduAnimator.SetTrigger("activeSuite");

        yield return new WaitForSeconds(2f);

        fonduBlanc.SetActive(false);
     
    }

    public void functionEnd()
    {
        //Debug.Log("marche");
        StartCoroutine(endScene());
    }

    public IEnumerator endScene()
    {
        fonduBlanc.SetActive(true);
        

        yield return new WaitForSeconds(2f);

        SceneManager.LoadScene(2);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
