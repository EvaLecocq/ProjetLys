using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimalManager : MonoBehaviour
{
    public GameObject portailWall;

    [Header("animaux")]
    public GameObject lapin;
    public GameObject sanglier;
    public GameObject serpent;
    public GameObject ratonLaveur;
    public GameObject renard;
    public GameObject chienChat;
    public GameObject cerf;
    public GameObject cerfEffect;

    [Header("spot")]
    public Transform chienChatSpot;
    public Transform renardSpot;

    [Header("pot")]
    public GameObject[] pot;

    // Start is called before the first frame update
    void Start()
    {
        cerf.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if(GameManager.s_Singleton.progression >= 5)
        {
            lapin.SetActive(false);
            chienChat.transform.position = chienChatSpot.position;
        }
        if (GameManager.s_Singleton.progression >= 6)
        {
            renard.transform.position = renardSpot.position;
        }
        
        if(GameManager.s_Singleton.progression == 7)
        {
            
                if(pot[0].GetComponent<pot>().full == true && pot[1].GetComponent<pot>().full == true && pot[2].GetComponent<pot>().full == true && pot[3].GetComponent<pot>().full == true)
                {
                    GameManager.s_Singleton.progression++;
                }
            
        }
        if (GameManager.s_Singleton.progression >= 8)
        {
            cerf.SetActive(true);
            cerfEffect.SetActive(true);
            cerfEffect.GetComponent<ParticleSystem>().Play();

            portailWall.SetActive(false);
        }
    }
}
