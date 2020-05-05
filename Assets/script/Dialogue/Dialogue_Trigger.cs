﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class Dialogue_Trigger : MonoBehaviour
{
    public enum animal {  lapin, sanglier, serpent, ratonLaveur, renard, chienChat, cerf };
    public animal type;

    public Dialogue dialogueDebut;
    public Dialogue dialogueLapin;
    public Dialogue dialogueSanglier;
    public Dialogue dialogueSerpent;
    public Dialogue dialogueRatonLaveur;
    public Dialogue dialogueRenard;
    public Dialogue dialogueChianChat;
    public Dialogue dialogueRenard2;
    public Dialogue dialogueCerf;

    public Dialogue dialogueQueteNonValide;
    public Dialogue dialogueQueteNonValide2;
    public Dialogue dialogueQueteNonValide3;

    public CinemachineVirtualCamera camDialogue;
    public Transform playerPos;

    private PlayerMovement player;
    private Outline outliner;
    

    public int RatonSpam;


    public bool quest1active;

    private void Start()
    {
        outliner = GetComponent<Outline>();
        player = PlayerMovement.FindObjectOfType<PlayerMovement>();
    }

    private void Update()
    {
        if(FindObjectOfType<Dialogue_Manager>().triggerEnd == true)
        {
            StartCoroutine(StopDialogue());
            
        }

        
    }

    public void UpgradeQuest()
    {
        GameManager.s_Singleton.QueteFini();
    }


    public void EventDialogue()
    {
        FindObjectOfType<Dialogue_Manager>().dialogueActive = true;

        player.enabled = false;

        player.transform.position = playerPos.position;
        player.transform.rotation = playerPos.rotation;

        camDialogue.Priority = 10;

        

        StartDialogue();
    }

    public void ActiveOutline()
    {
        outliner.enabled = true;
    }

    public void DesactiveOutline()
    {
        outliner.enabled = false;
    }

    public void StartDialogue()
    {
        if (GameManager.s_Singleton.principale == GameManager.quete.debut)
        {
            FindObjectOfType<Dialogue_Manager>().StartDialogue(dialogueDebut);
        }
        if (GameManager.s_Singleton.principale == GameManager.quete.lapin)
        {
            FindObjectOfType<Dialogue_Manager>().StartDialogue(dialogueLapin);
        }
        else if (GameManager.s_Singleton.principale == GameManager.quete.sanglier)
        {
            FindObjectOfType<Dialogue_Manager>().StartDialogue(dialogueSanglier);
        }
        else if (GameManager.s_Singleton.principale == GameManager.quete.serpent)
        {
            FindObjectOfType<Dialogue_Manager>().StartDialogue(dialogueSerpent);
        }
        else if (GameManager.s_Singleton.principale == GameManager.quete.ratonLaveur)
        {
            FindObjectOfType<Dialogue_Manager>().StartDialogue(dialogueRatonLaveur);
        }
        else if (GameManager.s_Singleton.principale == GameManager.quete.renard)
        {
            FindObjectOfType<Dialogue_Manager>().StartDialogue(dialogueRenard);
        }
        else if (GameManager.s_Singleton.principale == GameManager.quete.chienChat)
        {
            FindObjectOfType<Dialogue_Manager>().StartDialogue(dialogueChianChat);
        }
        else if (GameManager.s_Singleton.principale == GameManager.quete.renard2)
        {
            FindObjectOfType<Dialogue_Manager>().StartDialogue(dialogueRenard2);
        }
        else if (GameManager.s_Singleton.principale == GameManager.quete.cerf)
        {
            FindObjectOfType<Dialogue_Manager>().StartDialogue(dialogueCerf);
        }


        outliner.enabled = false;
    }

    public IEnumerator StopDialogue()
    {
        FindObjectOfType<Dialogue_Manager>().dialogueActive = false;
        FindObjectOfType<Dialogue_Manager>().EndDialogue();
        
        player.enabled = true;
        camDialogue.Priority = 0;

        //Debug.Log(camDialogue.Priority);

        UpgradeQuest();

        FindObjectOfType<Dialogue_Manager>().triggerEnd = false;
     
        yield return new WaitForSeconds(0.0f);

    }
  
}
