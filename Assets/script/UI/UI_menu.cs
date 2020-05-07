using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
using TMPro;
using UnityEngine.SceneManagement;


public class UI_menu : MonoBehaviour
{
    public GameObject menu;
    public CinemachineVirtualCamera camMenu;
    public CinemachineVirtualCamera camCredits;
    public GameObject herbier;
    public GameObject credits;
    public GameObject tab;
    public bool iscredits = false;
    public GameObject cameraPrefab;

   
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.T))
        {
            StartGame();
        }
        if (iscredits == false)
        {
            if (Input.GetKeyDown(KeyCode.Y))
            {
                CreditsView();
                iscredits = true;
            }
        }
        else
        {
            if (Input.GetKeyDown(KeyCode.Y))
            {
                if(iscredits == true)
                {
                    CreditsClose();
                    iscredits = false;
                }
            }
        }


        if (Input.GetKeyDown(KeyCode.U))
        {
            Quitter();
        }
        if (Input.GetKeyDown(KeyCode.P))
        {
            BackToMenu();
        }
    }
    public void StartGame()
    {
        Instantiate(cameraPrefab, new Vector3(0,0,0), Quaternion.identity);
        menu.gameObject.SetActive(false);
        camMenu.Priority = 0;
        herbier.gameObject.SetActive(true);
        tab.gameObject.SetActive(true);
    }
    public void Quitter()
    {
        Application.Quit();
    }

    public void CreditsView()
    {
        credits.gameObject.SetActive(true);
        camCredits.Priority = 11;
        
        menu.SetActive(false);

    }
  
    public void CreditsClose()
    {
        credits.gameObject.SetActive(false);
        camCredits.Priority = 10;

        menu.SetActive(true);
    }
    public void BackToMenu()
    {
        SceneManager.LoadScene(0);
    }
}
