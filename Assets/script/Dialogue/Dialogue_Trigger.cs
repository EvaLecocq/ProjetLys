using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class Dialogue_Trigger : MonoBehaviour
{
    public Dialogue _dialogue;
    public Dialogue2 _dialogue2;

    public CinemachineVirtualCamera camDialogue;
    public Transform playerPos;

    private PlayerMovement player;
    private Outline outliner;


    private void Start()
    {
        outliner = GetComponent<Outline>();
        player = PlayerMovement.FindObjectOfType<PlayerMovement>();
    }

    private void Update()
    {
        if(FindObjectOfType<Dialogue_Manager>().dialogueActive == false)
        {
            StopDialogue();
        }
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
        FindObjectOfType<Dialogue_Manager>().StartDialogue(_dialogue);
        outliner.enabled = false;
    }

    public void StopDialogue()
    {
        FindObjectOfType<Dialogue_Manager>().dialogueActive = false;
        FindObjectOfType<Dialogue_Manager>().EndDialogue();
        
        player.enabled = true;
        camDialogue.Priority = 0;
    }
  
}
