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
    public GameObject description;
   
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
        if (Input.GetKeyDown(KeyCode.Y))
        {
            CreditsView();
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
        camCredits.Priority = 11;
        description.gameObject.SetActive(true);
        menu.SetActive(false);

    }

}
