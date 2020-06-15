using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndGameMnager : MonoBehaviour
{
    public GameObject fonduBlanc;
    private Animator fonduAnimator;


    public AudioSource audioS;
    public AudioClip porteOuvre;
    public AudioClip porteTocToc;
    public AudioClip voixOff;


    // Start is called before the first frame update
    void Start()
    {
        fonduAnimator = fonduBlanc.GetComponent<Animator>();

        StartCoroutine(startScene());

        InvokeRepeating("TocTocPorte", 5f, 8f);
        Invoke("VoixOff", 14f);
    }

    public void TocTocPorte()
    {
        audioS.clip = porteTocToc;
        audioS.Play();
    }

    public void VoixOff()
    {
        audioS.clip = voixOff;
        audioS.Play();
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
        audioS.clip = porteOuvre;
        audioS.Play();
        

        yield return new WaitForSeconds(2f);

        SceneManager.LoadScene(2);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
