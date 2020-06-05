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

    public bool parleLaNuit = false;

    public Dialogue dialogueDebut;
    public Dialogue dialogueLapin;
    public Dialogue dialogueSanglier;
    public Dialogue dialogueSerpent;
    public Dialogue dialogueRatonLaveur;
    public Dialogue dialogueRenard;
    public Dialogue dialogueChianChat;
    public Dialogue dialogueRenard2;
    public Dialogue dialogueCerf;

    public Dialogue dialogueQueteNonValideSanglier;
    public Dialogue dialogueQueteNonValide;
    public Dialogue dialogueQueteNonValide2;
    public Dialogue dialogueQueteNonValide3;
    public Dialogue dialogueQueteNonValideChien;

    public Dialogue dialogueQueteCourse;
    public Dialogue dialogueQueteCacheCache;
    public Dialogue dialogueQueteSoleil;

    public CinemachineVirtualCamera camDialogue;
    public Transform playerPos;

    private PlayerMovement player;
    private Dialogue_Manager manager;
    public Outline outliner;
    public bool autoSelect = true;
    public GameObject interactionIconDialogue;
    public GameObject dialogueIcon;
    public Animator fonduNoir;

    public queteSecondaire queteSecondaire;

    public bool QueteAnimalValide = false;

    


    //public bool quest1active;

    private void Start()
    {
        if(autoSelect)
        {
            outliner = GetComponent<Outline>();
        }
        manager = Dialogue_Manager.FindObjectOfType<Dialogue_Manager>();
        player = PlayerMovement.FindObjectOfType<PlayerMovement>();
    }

    private void Update()
    {
        if(manager.triggerEnd == true)
        {

            StartCoroutine(FonduNoirStopDialogue());
        }

        
    }

    public void UpgradeQuest()
    {
        if(statut == Dialogue_Trigger.classe.principal)
        {
            if (GameManager.s_Singleton.progression == 0 && type == Dialogue_Trigger.animal.lapin)
            {
                GameManager.s_Singleton.QueteFini();
            }
            else if (GameManager.s_Singleton.progression == 1 && type == Dialogue_Trigger.animal.sanglier)
            {
                GameManager.s_Singleton.QueteFini();

            }
            else if(GameManager.s_Singleton.progression == 2 && GameManager.s_Singleton.queteSanglier == true && type == Dialogue_Trigger.animal.serpent)// +finir quete sanglier
            {
                GameManager.s_Singleton.QueteFini();
                GameManager.s_Singleton.AncolieDuCanada++;
            }

            else if(GameManager.s_Singleton.progression == 3 && type == Dialogue_Trigger.animal.ratonLaveur)// spam dialogue
            {
                if (GameManager.s_Singleton.queteRaton == true)
                {
                    GameManager.s_Singleton.QueteFini();
                }
                else if(GameManager.s_Singleton.queteRaton == false && (GameManager.s_Singleton.time >= 18 || GameManager.s_Singleton.time < 6))
                {
                    GameManager.s_Singleton.RatonSpam++;
                }
                
            }


            else if(GameManager.s_Singleton.progression == 4 && type == Dialogue_Trigger.animal.renard)
            {
                GameManager.s_Singleton.QueteFini();
            }
            else if(GameManager.s_Singleton.progression == 5 && type == Dialogue_Trigger.animal.chienChat)
            {
                GameManager.s_Singleton.QueteFini();
            }
            else if(GameManager.s_Singleton.progression == 6 && GameManager.s_Singleton.queteChien == true && type == Dialogue_Trigger.animal.renard)// + finir quete chien chat
            {
                GameManager.s_Singleton.QueteFini();
            }
            else if(GameManager.s_Singleton.progression == 7 && type == Dialogue_Trigger.animal.cerf)// apres avoir fait les pots
            {
                GameManager.s_Singleton.QueteFini();
                GameManager.s_Singleton.clesDuParc = true;
            }
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

    public void UpgradeAnimalTalk()
    {
        if (type == Dialogue_Trigger.animal.lapin)
        {
            GameManager.s_Singleton.lapin++;
        }
        else if (type == Dialogue_Trigger.animal.sanglier)
        {

            GameManager.s_Singleton.sanglier++;
        }
        else if( type == Dialogue_Trigger.animal.serpent)
        {
            GameManager.s_Singleton.serpent++;
        }

        else if(type == Dialogue_Trigger.animal.ratonLaveur)
        {
            GameManager.s_Singleton.ratonLaveur++;
        }


        else if(type == Dialogue_Trigger.animal.renard)
        {
            GameManager.s_Singleton.renard++;
        }
        else if(type == Dialogue_Trigger.animal.chienChat)
        {
            GameManager.s_Singleton.chienChat++;
        }

        else if(type == Dialogue_Trigger.animal.cerf)
        {
            GameManager.s_Singleton.cerf++;
        }

    }

    public void EventDialogue()
    {
        manager.dialogueActive = true;

        player.isTalk = true;
        StartCoroutine(FonduNoirStartDialogue());

        

    }

    public void ActiveOutline()
    {
        outliner.enabled = true;
        interactionIconDialogue.SetActive(true);
        dialogueIcon.SetActive(false);
    }

    public void DesactiveOutline()
    {
        outliner.enabled = false;
        interactionIconDialogue.SetActive(false);
        dialogueIcon.SetActive(true);
    }

    public IEnumerator FonduNoirStartDialogue()
    {
        fonduNoir.gameObject.SetActive(true);
        yield return new WaitForSeconds(1);

        

        player.transform.position = playerPos.position;
        player.transform.rotation = playerPos.rotation;

        camDialogue.enabled = true;
        camDialogue.Priority = 10;
        

        StartCoroutine(StartDialogue());
        

        yield return new WaitForSeconds(1);
        fonduNoir.Rebind();
        fonduNoir.gameObject.SetActive(false);

    }

    public IEnumerator StartDialogue()
    {
        yield return new WaitForSeconds(1);

        if (statut == Dialogue_Trigger.classe.principal || statut == Dialogue_Trigger.classe.tertiaire)
        {
            if (GameManager.s_Singleton.progression == 0)
            {
                FindObjectOfType<Dialogue_Manager>().StartDialogue(dialogueDebut);
            }

            else if (GameManager.s_Singleton.progression == 1) //principale == GameManager.quete.lapin
            {
                FindObjectOfType<Dialogue_Manager>().StartDialogue(dialogueLapin);
            }

            else if (GameManager.s_Singleton.progression == 2)
            {
                

                if(GameManager.s_Singleton.queteSanglier == true)
                {
                    FindObjectOfType<Dialogue_Manager>().StartDialogue(dialogueSanglier);
                }
                else if(GameManager.s_Singleton.queteSanglier == false)
                {
                    FindObjectOfType<Dialogue_Manager>().StartDialogue(dialogueQueteNonValideSanglier);
                }
            }
            

            //parle nuit
            else if(GameManager.s_Singleton.progression == 3)
            {
                if (parleLaNuit == false)
                {
                    if (GameManager.s_Singleton.queteRaton == true)
                    {
                        FindObjectOfType<Dialogue_Manager>().StartDialogue(dialogueSerpent);
                    }
                    else if ( GameManager.s_Singleton.queteRaton == false && GameManager.s_Singleton.RatonSpam == 0)
                    {
                        FindObjectOfType<Dialogue_Manager>().StartDialogue(dialogueQueteNonValide);
                    }
                    else if ( GameManager.s_Singleton.queteRaton == false && GameManager.s_Singleton.RatonSpam == 1)
                    {
                        FindObjectOfType<Dialogue_Manager>().StartDialogue(dialogueQueteNonValide2);
                    }
                    else if (GameManager.s_Singleton.queteRaton == false && GameManager.s_Singleton.RatonSpam == 2)
                    {
                        FindObjectOfType<Dialogue_Manager>().StartDialogue(dialogueQueteNonValide3);
                    }
                }
                else if (parleLaNuit && (GameManager.s_Singleton.time >= 17 || GameManager.s_Singleton.time < 8))
                {
                    if (GameManager.s_Singleton.queteRaton == true)
                    {
                        FindObjectOfType<Dialogue_Manager>().StartDialogue(dialogueSerpent);
                    }
                    else if ( GameManager.s_Singleton.queteRaton == false && GameManager.s_Singleton.RatonSpam == 0)
                    {
                        FindObjectOfType<Dialogue_Manager>().StartDialogue(dialogueQueteNonValide);
                    }
                    else if ( GameManager.s_Singleton.queteRaton == false && GameManager.s_Singleton.RatonSpam == 1)
                    {
                        FindObjectOfType<Dialogue_Manager>().StartDialogue(dialogueQueteNonValide2);
                    }
                    else if (GameManager.s_Singleton.queteRaton == false && GameManager.s_Singleton.RatonSpam == 2)
                    {
                        FindObjectOfType<Dialogue_Manager>().StartDialogue(dialogueQueteNonValide3);
                    }
                }
                else if (parleLaNuit && (GameManager.s_Singleton.time < 17 || GameManager.s_Singleton.time > 8))
                {
                    
                        FindObjectOfType<Dialogue_Manager>().StartDialogue(dialogueQueteNonValide);
                    
                }

            }


            //fin parle de nuit



        else if (GameManager.s_Singleton.progression == 4)
        {
            FindObjectOfType<Dialogue_Manager>().StartDialogue(dialogueRatonLaveur);
        }

        else if (GameManager.s_Singleton.progression == 5)
        {
            FindObjectOfType<Dialogue_Manager>().StartDialogue(dialogueRenard);
        }

        else if (GameManager.s_Singleton.progression == 6)
        {
                if(GameManager.s_Singleton.queteChien == true)
                {
                    FindObjectOfType<Dialogue_Manager>().StartDialogue(dialogueChianChat);
                }
                else if(GameManager.s_Singleton.queteChien == false)
                {
                    FindObjectOfType<Dialogue_Manager>().StartDialogue(dialogueQueteNonValideChien);
                }
            
        }
        


        else if (GameManager.s_Singleton.progression == 7)
        {
            FindObjectOfType<Dialogue_Manager>().StartDialogue(dialogueRenard2);
        }

        else if (GameManager.s_Singleton.progression == 8)
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
        interactionIconDialogue.SetActive(false);

        
        
    }

    public IEnumerator FonduNoirStopDialogue()
    {
        manager.triggerEnd = false;

        

        fonduNoir.gameObject.SetActive(true);
        yield return new WaitForSeconds(1);

        StopDialogue();

        yield return new WaitForSeconds(1);
        fonduNoir.Rebind();
        fonduNoir.gameObject.SetActive(false);

    }

    public void StopDialogue()
    {
        

        manager.dialogueActive = false;
        //manager.EndDialogue();
        
        player.isTalk = false;
        camDialogue.Priority = 0;
        camDialogue.enabled = false;

        //player.camRoot.transform.position = Vector3.zero;
        player.camRoot.transform.rotation = new Quaternion(0, 0, 0, 0);

        //Debug.Log(camDialogue.Priority);

        UpgradeQuest();
        UpgradeAnimalTalk();

       

        StartCoroutine(waitToTalk());

        manager.dialogueActive = false;
    }

    public IEnumerator waitToTalk()
    {
        gameObject.GetComponent<Collider>().enabled = false;
        yield return new WaitForSeconds(1f);

        gameObject.GetComponent<Collider>().enabled = true;

    }
  
}
