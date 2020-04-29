using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UI_Herbier : MonoBehaviour
{
    
    public GameObject herbier;
    public GameObject inventaire;
    public GameObject carte;
    public GameObject buttoncarte;
    public bool openhebier = false;
    public bool openInv = false;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(openhebier == false)
        {
            if (Input.GetKeyDown(KeyCode.F))
            {
                herbier.gameObject.SetActive(true);
                buttoncarte.SetActive(false);
                openhebier = true;
             

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
                }
               
            }
        }
        if(openInv == false)
        {
            if (Input.GetKeyDown(KeyCode.Tab))
            {
                inventaire.gameObject.SetActive(true);
                openInv = true;
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
                }
            }
        }
      
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            herbier.gameObject.SetActive(false);            
           // buttoncarte.gameObject.SetActive(true);
            carte.gameObject.SetActive(false);

        }
       
      /*  if (Input.GetKeyDown(KeyCode.M))
        {
            carte.gameObject.SetActive(true);
            buttoncarte.gameObject.SetActive(false);
        }*/
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
