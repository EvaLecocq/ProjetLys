using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UI_Herbier : MonoBehaviour
{
    
    public GameObject herbier;
    public GameObject inventaire;
    public GameObject tab;

    public bool openhebier = false;
    public bool openInv = false;
    public Transform playerPos;

    private PlayerMovement player;

    // Start is called before the first frame update
    void Start()
    {
        player = PlayerMovement.FindObjectOfType<PlayerMovement>();
    }

    // Update is called once per frame
    void Update()
    {
        if(openhebier == false)
        {
            if (Input.GetKeyDown(KeyCode.F))
            {
                if (openInv == true)
                {
                    herbier.gameObject.SetActive(false);
                    openhebier = false
;
                }
                else
                {
                    herbier.gameObject.SetActive(true);
                    openhebier = true;
                    Time.timeScale = 0f;
                }
            }
        }
        else
        {
            if (Input.GetKeyDown(KeyCode.F))
            {
                if(openhebier == true)
                {
                    herbier.gameObject.SetActive(false);
                    openhebier = false;
                    Time.timeScale = 1f;
                }
               
            }
        }
        if(openInv == false)
        {
            if (Input.GetKeyDown(KeyCode.Tab))
            {
                if(openhebier == true)
                {
                    inventaire.gameObject.SetActive(false);
                    openInv = false;
                }
                else
                {
                    inventaire.gameObject.SetActive(true);
                    openInv = true;
                    tab.gameObject.SetActive(false);
                }
               
            }
          
        }
        else
        {
            if (Input.GetKeyDown(KeyCode.Tab))
            {
                if(openInv == true)
                {
                    inventaire.gameObject.SetActive(false);
                    openInv = false;
                    tab.gameObject.SetActive(true);
                }
            }
        }
     
    }
    public void OpenHerbier()
    {
        herbier.gameObject.SetActive(true);
        inventaire.gameObject.SetActive(true);
       
    }
    public void CloseHerbier()
    {
        herbier.gameObject.SetActive(false);
        inventaire.gameObject.SetActive(false);
    }
}
