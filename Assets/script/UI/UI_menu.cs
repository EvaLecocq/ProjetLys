using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
using TMPro;


public class UI_menu : MonoBehaviour
{
    public GameObject menu;
    public CinemachineVirtualCamera camMenu;
    public CinemachineVirtualCamera camCredits;
    public GameObject herbier;
    public GameObject credits;
    public bool iscredits = false;
    
   
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
                    menu.SetActive(true);
                    camCredits.Priority = 0;
                }
            }
        }


        if (Input.GetKeyDown(KeyCode.U))
        {
            Quitter();
        }
    }
    public void StartGame()
    {

        menu.gameObject.SetActive(false);
        camMenu.Priority = 0;
        herbier.gameObject.SetActive(true);
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
  

}
