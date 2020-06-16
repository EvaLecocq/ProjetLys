using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimalManager : MonoBehaviour
{

    [Header("animaux")]
    public GameObject lapin;
    public GameObject sanglier;
    public GameObject serpent;
    public GameObject ratonLaveur;
    public GameObject renard;
    public GameObject chienChat;
    public GameObject cerf;

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
            foreach(GameObject go in pot)
            {
                if(go.GetComponent<pot>().full == true)
                {
                    GameManager.s_Singleton.progression++;
                }
            }
        }
        if (GameManager.s_Singleton.progression >= 8)
        {
            cerf.SetActive(true);
        }
    }
}
