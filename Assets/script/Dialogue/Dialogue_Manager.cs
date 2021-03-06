﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Dialogue_Manager : MonoBehaviour
{
    public Text Textname;
    public Text dialogue;
    public Queue<string> sentences;
    public GameObject dialogueapparition;
    public GameObject quete;

    public bool triggerEnd = false;
    public bool dialogueActive = false;

    private bool startDialogueFinish = false;

    public AudioSource audioS;
    public AudioClip dialogueSound;


    // Start is called before the first frame update
    void Start()
    {
        sentences = new Queue<string>();
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && dialogueActive && startDialogueFinish && triggerEnd == false)
        {
            DisplayNextSentence();

            
            audioS.Stop();

            audioS.clip = dialogueSound;
            audioS.pitch = Random.Range(1, 1.2f);
            audioS.Play();
        }

        if(dialogueActive == false)
        {
            dialogueapparition.gameObject.SetActive(false);
        }
    }


    public void StartDialogue(Dialogue dialogue)
    {
        dialogueapparition.gameObject.SetActive(true);
        //Debug.Log("Sart" + dialogue.name);

        Textname.text = dialogue.name;

        sentences.Clear();

        foreach (string sentence in dialogue.sentences)
        {
            sentences.Enqueue(sentence);
        }
        DisplayNextSentence();

        
    }



    public void DisplayNextSentence()
    {
        if(sentences.Count == 0)
        {
            EndDialogue();
            return;
        }
        string sentence = sentences.Dequeue();
        StopAllCoroutines();

       // StopCoroutine(TypeSentence(sentence));

        StartCoroutine(TypeSentence(sentence));
    }



    IEnumerator TypeSentence(string sentence)
    {
        dialogue.text = "";
        foreach(char letter in sentence.ToCharArray())
        {
            dialogue.text += letter;
            yield return null;
        }
        startDialogueFinish = true;
    }


    public void EndDialogue()
    {
        dialogueapparition.gameObject.SetActive(false);

        //dialogueActive = false;//ct desactiver jsp
        triggerEnd = true;
        startDialogueFinish = false;
    }
   
}
