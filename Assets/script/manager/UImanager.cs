using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;
using Cinemachine;

public class UImanager : MonoBehaviour
{
    public float time;
    //public Image clock;

    public TextMeshProUGUI textDay;
    public GameObject textInteraction;

    private MouseLook mouseC;

    [Header("herbier")]
    public GameObject herbier;
    public TextMeshProUGUI tab;
    public bool openherbier = false;
    public Transform playerPos;
    private PlayerMovement player;

    [Header("pause")]
    public GameObject pause;
    public bool ispause = false;

    [Header("menu")]
    public GameObject menu;
    public GameObject UIinfo;
    public GameObject herbierIcon;
    public CinemachineVirtualCamera camMenu;
    public CinemachineVirtualCamera camCredits;
    public GameObject credits;
    public bool iscredits = false;
    private bool isMenu = false;

    // Start is called before the first frame update
    void Start()
    {
        mouseC = MouseLook.FindObjectOfType<MouseLook>();
        player = PlayerMovement.FindObjectOfType<PlayerMovement>();
    }

    // Update is called once per frame
    void Update()
    {
        textDay.text = GameManager.s_Singleton.actualDay.ToString();

        time = GameManager.s_Singleton.time;
        //clock.transform.rotation =  Quaternion.Euler(transform.eulerAngles.x, transform.eulerAngles.y, (time * -30));

        //pause
        if (ispause == false && isMenu == false && openherbier == false)
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                pause.gameObject.SetActive(true);
                ispause = true;
                Time.timeScale = 0f;

                UIinfo.SetActive(false);
            }
        }
        else if (ispause == true)
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                
                    pause.gameObject.SetActive(false);
                    ispause = false;
                    Time.timeScale = 1f;

                mouseC.lockerCam = true;
                UIinfo.SetActive(true);

            }
        }
      


        //herbier
        if (openherbier == false && ispause == false && isMenu == false)
        {
            if (Input.GetKeyDown(KeyCode.F))
            {
                herbier.gameObject.SetActive(true);

                openherbier = true;
                player.enabled = false;
                UIinfo.SetActive(false);
            }
        }
        else if (openherbier == true)
        {
            if (Input.GetKeyDown(KeyCode.F))
            {
               
                    herbier.gameObject.SetActive(false);
                    openherbier = false;
                    player.enabled = true;

                UIinfo.SetActive(true);
            }
        }

        //menu
        if(menu.activeInHierarchy)
        {
            mouseC.lockerCam = false;
            UIinfo.SetActive(false);
            isMenu = true;
        }
        else
        {
            isMenu = false;
        }

        if(pause.activeInHierarchy)
        {
            mouseC.lockerCam = false;
        }


    }

    //pause echap
    public void Quitter()
    {
        Application.Quit();
    }
  
    public void BackToMenu()
    {
        UIinfo.SetActive(false);
        SceneManager.LoadScene(0);
        Time.timeScale = 1f;

        mouseC.lockerCam = false;
    }

   
    //menu
    public void StartGame()
    {
        UIinfo.SetActive(true);
        
        menu.gameObject.SetActive(false);
        camMenu.Priority = 0;
        herbierIcon.gameObject.SetActive(true);

        mouseC.lockerCam = true;
    }
   

    public void CreditsOpen()
    {
        credits.gameObject.SetActive(true);
        camCredits.Priority = 20;

        menu.SetActive(false);

    }

    public void CreditsClose()
    {
        credits.gameObject.SetActive(false);
        camCredits.Priority = 0;

        menu.SetActive(true);
    }
}
