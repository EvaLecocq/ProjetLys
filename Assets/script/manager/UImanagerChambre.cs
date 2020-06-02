using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;
using Cinemachine;

public class UImanagerChambre : MonoBehaviour
{
    
    

    private MouseLookFPV mouseC;

  
    public Transform playerPos;
    private PlayerMovementFPV player;

    [Header("pause")]
    public GameObject pause;
    public bool ispause = false;

 

    public AudioSource audioS;
    public AudioClip pauseApp;
    public AudioClip pauseDisp;
    public AudioClip clique;
 

    // Start is called before the first frame update
    void Start()
    {
        mouseC = MouseLookFPV.FindObjectOfType<MouseLookFPV>();
        player = PlayerMovementFPV.FindObjectOfType<PlayerMovementFPV>();

        audioS = GetComponent<AudioSource>();

       
    }

    // Update is called once per frame
    void Update()
    {
        //textDay.text = GameManager.s_Singleton.actualDay.ToString();
      
       

        //pause
      if(ispause == false)
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                audioS.clip = pauseApp;
                audioS.Play();

                pause.gameObject.SetActive(true);
                ispause = true;
                Time.timeScale = 0f;

                mouseC.lockerCam = false;

            }
        }
            
        
        else if (ispause == true)
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                audioS.clip = pauseDisp;
                audioS.Play();

                pause.gameObject.SetActive(false);
                    ispause = false;
                    Time.timeScale = 1f;

                mouseC.lockerCam = true;
               

            }
        }

        

        if(pause.activeInHierarchy)
        {
            mouseC.lockerCam = false;
        }


    }

    


    


    //pause echap
    public void Quitter()
    {
        audioS.clip = clique;
        audioS.Play();

        Application.Quit();
    }
  
    public void BackToMenu()
    {
        audioS.clip = clique;
        audioS.Play();

        

        if(SceneManager.GetActiveScene().buildIndex != 0)
        {
            SceneManager.LoadScene(0);
        }

        
        Time.timeScale = 1f;

        mouseC.lockerCam = false;
    }

    public void Continue()
    {
        audioS.clip = clique;
        audioS.Play();

        pause.gameObject.SetActive(false);
        ispause = false;
        Time.timeScale = 1f;
        

        mouseC.lockerCam = true;
       
    }

   
    
   
}
