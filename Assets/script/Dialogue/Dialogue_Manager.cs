using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Dialogue_Manager : MonoBehaviour
{
    public Text Textname;
    public Text dialogue;
    private Queue<string> sentences;
    public GameObject dialogueapparition;
    public GameObject quete;

    public bool dialogueActive = false;

    // Start is called before the first frame update
    void Start()
    {
        sentences = new Queue<string>();
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            DisplayNextSentence();
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


    public void StartDialogue2(Dialogue2 _dialogue2)
    {
        dialogueapparition.gameObject.SetActive(true);
        //Debug.Log("Sart" + _dialogue2.name);

        Textname.text = _dialogue2.name;

        sentences.Clear();

        foreach (string sentence in _dialogue2.sentences)
        {
            sentences.Enqueue(sentence);
        }
        DisplayNextSentence2();
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
        StartCoroutine(TypeSentence(sentence));
    }


    public void DisplayNextSentence2()
    {
        if (sentences.Count == 0)
        {
            EndDialogue2();
            return;
        }
        string sentence = sentences.Dequeue();
        StopAllCoroutines();
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
    }


    public void EndDialogue()
    {
        dialogueapparition.gameObject.SetActive(false);

        dialogueActive = false;
            //quete.gameObject.SetActive(true);
        
    }
    public void EndDialogue2()
    {
        dialogueapparition.gameObject.SetActive(false);

       

    }

}
