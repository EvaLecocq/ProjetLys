using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class cameraTravelling : MonoBehaviour
{

    private Dialogue_Manager manager;

    public CinemachineVirtualCamera[] cam;
    private int parcourer;

    // Start is called before the first frame update
    void Start()
    {
        manager = Dialogue_Manager.FindObjectOfType<Dialogue_Manager>();
       
    }

    // Update is called once per frame
    void Update()
    {
       // Debug.Log(manager.sentences.Count);
       if(GameManager.s_Singleton.progression == 0)
        {
            //Debug.Log(manager.sentences.Count);  13
            parcourer = manager.sentences.Count;

            if (Input.GetKeyDown(KeyCode.E))
            {
               

                
                    foreach (CinemachineVirtualCamera cm in cam)
                    {
                        cm.Priority = 0;
                    }


                if (parcourer <= 13 && parcourer >= 11)
                {
                    cam[0].Priority = 25;
                }
                if (parcourer == 10)
                {
                    cam[1].Priority = 25;
                }
                if (parcourer == 9 || parcourer == 8)
                {
                    cam[2].Priority = 25;
                }
                if (parcourer <= 7 /*&& parcourer >= 3*/)
                {
                    cam[0].Priority = 25;
                }/*
                if (parcourer == 2)
                {
                    cam[3].Priority = 25;
                }
                if (parcourer == 1)
                {
                    cam[4].Priority = 25;
                }
                if (parcourer == 0)
                {
                    cam[5].Priority = 25;
                }*/


            }
           
            
        }
       else
        {
            cam[1].Priority = 0;
            cam[2].Priority = 0;
            cam[3].Priority = 0;
        }
       
    }
}
