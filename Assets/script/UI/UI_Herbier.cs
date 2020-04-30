using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UI_Herbier : MonoBehaviour
{
    
    public GameObject herbier;
    public GameObject inventaire;
    public TextMeshProUGUI tab;

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
                herbier.gameObject.SetActive(true);
               
                openhebier = true;
                player.enabled = false;

                //player.transform.position = playerPos.position;
               // player.transform.rotation = playerPos.rotation;
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
                    player.enabled = true;
                }
               
            }
        }
        if(openInv == false)
        {
            if (Input.GetKeyDown(KeyCode.Tab))
            {
                inventaire.gameObject.SetActive(true);
                openInv = true;
                tab.text = "";
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
                    tab.text = "(TAB)";
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
