﻿using System.Collections;
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

            parcourer = manager.sentences.Count;

            if (Input.GetKeyDown(KeyCode.E))
            {
               

                
                    foreach (CinemachineVirtualCamera cm in cam)
                    {
                        cm.Priority = 0;
                    }

                if(parcourer == 5)
                {
                    cam[1].Priority = 25;
                }
                if (parcourer == 4)
                {
                    cam[2].Priority = 25;
                }
                if (parcourer == 3)
                {
                    cam[3].Priority = 25;
                }
                if (parcourer == 2)
                {
                    cam[4].Priority = 25;
                }


            }
           
            
        }
       
    }
}
