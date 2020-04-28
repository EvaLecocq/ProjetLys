using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class Dialogue_Trigger : MonoBehaviour
{
    public Dialogue _dialogue;
    public Dialogue2 _dialogue2;

    public CinemachineVirtualCamera camDialogue;

    private PlayerMovement player;


    private void Start()
    {
        player = PlayerMovement.FindObjectOfType<PlayerMovement>();
    }


    public void EventDialogue()
    {
        FindObjectOfType<Dialogue_Manager>().dialogueActive = true;

        StartDialogue();
    }

    public void StartDialogue()
    {
        FindObjectOfType<Dialogue_Manager>().StartDialogue(_dialogue);
    }

    public void StopDialogue()
    {
        FindObjectOfType<Dialogue_Manager>().dialogueActive = false;
        FindObjectOfType<Dialogue_Manager>().EndDialogue();
    }
  
}
