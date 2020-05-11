using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UI_Herbier : MonoBehaviour
{

    public GameObject herbier;
    public TextMeshProUGUI tab;
    public bool openhebier = false;
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
        
     
    }
    public void OpenHerbier()
    {
        herbier.gameObject.SetActive(true);
        
       
    }
    public void CloseHerbier()
    {
        herbier.gameObject.SetActive(false);
       
    }
}
