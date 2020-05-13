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
    public GameObject dialogue_UI;
    public bool dialogueActive = false;

    [Header("herbier")]
    public GameObject herbier;
    public int mapIndex;
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

                mouseC.lockerCam = false;
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


        //dialogue
        if(dialogue_UI.activeInHierarchy)
        {
            dialogueActive = true;

        }
        else
        {
            dialogueActive = false;
        }



        //herbier

        if (dialogueActive == false)
        {
           

            if (openherbier == false && ispause == false && isMenu == false)
            {
                if (Input.GetKeyDown(KeyCode.F))
                {
                    herbier.gameObject.SetActive(true);

                    openherbier = true;
                    player.isTalk = true;
                    UIinfo.SetActive(false);
                    herbierIcon.SetActive(false);

                    herbier.GetComponentInChildren<BookPro>().currentPaper = 0;
                    herbier.GetComponentInChildren<BookPro>().UpdatePages();
                }
                
            }
            else if (openherbier == true)
            {
                if (Input.GetKeyDown(KeyCode.F) )
                {

                    herbier.gameObject.SetActive(false);
                    openherbier = false;
                    player.isTalk = false;

                    UIinfo.SetActive(true);
                    herbierIcon.SetActive(true);
                }
                if (Input.GetKeyDown(KeyCode.M))
                {
                    herbier.gameObject.SetActive(true);

                    openherbier = true;
                    player.isTalk = true;
                    UIinfo.SetActive(false);
                    herbierIcon.SetActive(false);

                    herbier.GetComponentInChildren<BookPro>().currentPaper = mapIndex;
                    herbier.GetComponentInChildren<BookPro>().UpdatePages();
                }

            }
        }
        else
        {

            herbier.gameObject.SetActive(false);
            openherbier = false;
        }
        

        //menu
        if(menu.activeInHierarchy || credits.activeInHierarchy)
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
