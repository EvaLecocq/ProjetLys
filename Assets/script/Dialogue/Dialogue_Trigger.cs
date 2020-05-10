using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class Dialogue_Trigger : MonoBehaviour
{
    public enum animal {  lapin, sanglier, serpent, ratonLaveur, renard, chienChat, cerf, Course, Cahecache, Soleil, info };
    public animal type;

    public enum classe { principal, secondaire, tertiaire};
    public classe statut;

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

    public Dialogue dialogueQueteCourse;
    public Dialogue dialogueQueteCacheCache;
    public Dialogue dialogueQueteSoleil;

    public CinemachineVirtualCamera camDialogue;
    public Transform playerPos;

    private PlayerMovement player;
    private Outline outliner;

    public queteSecondaire queteSecondaire;

    public bool QueteAnimalValide = false;

    


    //public bool quest1active;

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
        if(GameManager.s_Singleton.progression == 0 && type == Dialogue_Trigger.animal.lapin)
        {
            GameManager.s_Singleton.QueteFini();
        }
        if (GameManager.s_Singleton.progression == 1 && type == Dialogue_Trigger.animal.sanglier)
        {
            GameManager.s_Singleton.QueteFini();
            
        }
        if (GameManager.s_Singleton.progression == 2 && GameManager.s_Singleton.queteSanglier == true && type == Dialogue_Trigger.animal.serpent)// +finir quete sanglier
        {
            GameManager.s_Singleton.QueteFini();
            GameManager.s_Singleton.AncolieDuCanada++;
        }

        if (GameManager.s_Singleton.progression == 3 && GameManager.s_Singleton.queteRaton == true && type == Dialogue_Trigger.animal.ratonLaveur)// spam dialogue
        {
            GameManager.s_Singleton.QueteFini();
        }
        if (GameManager.s_Singleton.progression == 3 && GameManager.s_Singleton.queteRaton == false && type == Dialogue_Trigger.animal.ratonLaveur)// spam dialogue
        {
            GameManager.s_Singleton.RatonSpam++;
        }

        if (GameManager.s_Singleton.progression == 4 && type == Dialogue_Trigger.animal.renard)
        {
            GameManager.s_Singleton.QueteFini();
        }
        if (GameManager.s_Singleton.progression == 5 && type == Dialogue_Trigger.animal.chienChat)
        {
            GameManager.s_Singleton.QueteFini();
        }
        if (GameManager.s_Singleton.progression == 6 && GameManager.s_Singleton.queteChien == true && type == Dialogue_Trigger.animal.renard)// + finir quete chien chat
        {
            GameManager.s_Singleton.QueteFini();
        }
        if (GameManager.s_Singleton.progression == 8 && type == Dialogue_Trigger.animal.cerf)// apres avoir fait les pots
        {
            GameManager.s_Singleton.QueteFini();
            GameManager.s_Singleton.clesDuParc = true;
        }

        ////secondaire

        if (type == Dialogue_Trigger.animal.Course)
        {
            queteSecondaire.ActiveQuest();
        }
        if (type == Dialogue_Trigger.animal.Cahecache)
        {
            queteSecondaire.ActiveQuest();
        }
        if (type == Dialogue_Trigger.animal.Soleil)
        {
            queteSecondaire.ActiveQuest();
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
        if(statut == Dialogue_Trigger.classe.principal || statut == Dialogue_Trigger.classe.tertiaire)
        {
            if (GameManager.s_Singleton.principale == GameManager.quete.debut)
            {
                FindObjectOfType<Dialogue_Manager>().StartDialogue(dialogueDebut);
            }

            if (GameManager.s_Singleton.principale == GameManager.quete.lapin )
            {
                FindObjectOfType<Dialogue_Manager>().StartDialogue(dialogueLapin);
            }  

            else if (GameManager.s_Singleton.principale == GameManager.quete.sanglier && GameManager.s_Singleton.queteSanglier == true)
            {
                FindObjectOfType<Dialogue_Manager>().StartDialogue(dialogueSanglier);
            }
            else if (GameManager.s_Singleton.principale == GameManager.quete.sanglier && GameManager.s_Singleton.queteSanglier == false)
            {
                FindObjectOfType<Dialogue_Manager>().StartDialogue(dialogueQueteNonValide);
            }

            else if (GameManager.s_Singleton.principale == GameManager.quete.serpent && GameManager.s_Singleton.queteRaton == true)
            {
                FindObjectOfType<Dialogue_Manager>().StartDialogue(dialogueSerpent);
            }
            else if (GameManager.s_Singleton.principale == GameManager.quete.serpent && GameManager.s_Singleton.queteRaton == false && GameManager.s_Singleton.RatonSpam == 0)
            {
                FindObjectOfType<Dialogue_Manager>().StartDialogue(dialogueQueteNonValide);
            }
            else if (GameManager.s_Singleton.principale == GameManager.quete.serpent && GameManager.s_Singleton.queteRaton == false && GameManager.s_Singleton.RatonSpam == 1)
            {
                FindObjectOfType<Dialogue_Manager>().StartDialogue(dialogueQueteNonValide2);
            }
            else if (GameManager.s_Singleton.principale == GameManager.quete.serpent && GameManager.s_Singleton.queteRaton == false && GameManager.s_Singleton.RatonSpam == 2)
            {
                FindObjectOfType<Dialogue_Manager>().StartDialogue(dialogueQueteNonValide3);
            }

            else if (GameManager.s_Singleton.principale == GameManager.quete.ratonLaveur)
            {
                FindObjectOfType<Dialogue_Manager>().StartDialogue(dialogueRatonLaveur);
            }

            else if (GameManager.s_Singleton.principale == GameManager.quete.renard)
            {
                FindObjectOfType<Dialogue_Manager>().StartDialogue(dialogueRenard);
            }

            else if (GameManager.s_Singleton.principale == GameManager.quete.chienChat && GameManager.s_Singleton.queteChien == true)
            {
                FindObjectOfType<Dialogue_Manager>().StartDialogue(dialogueChianChat);
            }
            else if (GameManager.s_Singleton.principale == GameManager.quete.chienChat && GameManager.s_Singleton.queteChien == false)
            {
                FindObjectOfType<Dialogue_Manager>().StartDialogue(dialogueQueteNonValide);
            }


            else if (GameManager.s_Singleton.principale == GameManager.quete.renard2)
            {
                FindObjectOfType<Dialogue_Manager>().StartDialogue(dialogueRenard2);
            }

            else if (GameManager.s_Singleton.principale == GameManager.quete.cerf)
            {
                FindObjectOfType<Dialogue_Manager>().StartDialogue(dialogueCerf);
            }
        }
        
        if(statut == Dialogue_Trigger.classe.secondaire)
        {
            if (type == Dialogue_Trigger.animal.Course && queteSecondaire.endQuest == false)
            {
                FindObjectOfType<Dialogue_Manager>().StartDialogue(dialogueQueteCourse);
            }
            if (type == Dialogue_Trigger.animal.Course && queteSecondaire.endQuest == true)
            {
                FindObjectOfType<Dialogue_Manager>().StartDialogue(dialogueQueteNonValide);
            }

            if (type == Dialogue_Trigger.animal.Cahecache)
            {
                FindObjectOfType<Dialogue_Manager>().StartDialogue(dialogueQueteCacheCache);
            }
            if (type == Dialogue_Trigger.animal.Soleil)
            {
                FindObjectOfType<Dialogue_Manager>().StartDialogue(dialogueQueteSoleil);
            }
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
