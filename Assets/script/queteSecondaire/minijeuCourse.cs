using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using TMPro;

public class minijeuCourse : MonoBehaviour
{
    //besoin : un TMP UI, un transform de depart pour le joueur et l'animal, un transform d'arriver, un animal avec NavMesh et une zone navigable
    [Header("Parametres")]
    public queteSecondaire quest;
    public bool courseActive;
    public float timer;
    public TextMeshProUGUI timerText;
    private bool startQuest = true;
    private Vector3 animalStartPos;
    public Animator animFondu;
   

    [Header("Zone de course")]
    public Transform playerStart;
    public Transform animalStart;
    public Transform end;
    public Transform playerEndPos;
    public float distanceEnd;

    [Header("Animal")]
    public NavMeshAgent animal;

    private PlayerMovement player;

    // Start is called before the first frame update
    void Start()
    {
        animalStartPos = animal.gameObject.transform.position;
        player = PlayerMovement.FindObjectOfType<PlayerMovement>();

        end.gameObject.SetActive(false);
        playerStart.gameObject.SetActive(false);
        animalStart.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if(quest.activeQuest)
        {
            
            StartCoroutine(StartQuestFondu());

            end.gameObject.SetActive(true);
            playerStart.gameObject.SetActive(true);
            animalStart.gameObject.SetActive(true);
        }

        if(courseActive)
        {
            if(startQuest)
            {
                

                if (timer > 0)
                {
                    timerText.gameObject.SetActive(true);
                    timerText.text = timer.ToString("0");

                    timer -= Time.deltaTime;
                }
                else
                {
                    timer = 0;
                    startQuest = false;
                    timerText.gameObject.SetActive(false);
                }
            }
            else
            {
                player.enabled = true;
                animal.enabled = true;

                animal.SetDestination(end.position);
            }
            

            AnimalDistance();
            PlayerDistance();

            if(AnimalDistance() < distanceEnd)
            {
                
               
                StartCoroutine(QuestFonduFin());
                Defeat();

            }
            if (PlayerDistance() < distanceEnd)
            {
                
                
                StartCoroutine(QuestFonduFin());
                Victory();

            }
        }
    }

    public float AnimalDistance()
    {
        float dist = Vector3.Distance(end.position, animal.gameObject.transform.position);

        return dist;
    }

    public float PlayerDistance()
    {
        float dist = Vector3.Distance(end.position, player.gameObject.transform.position);

        return dist;
    }

    public void Victory()
    {
        

        courseActive = false;
        startQuest = true;
        animal.enabled = false;
        animal.gameObject.transform.position = animalStartPos;

        end.gameObject.SetActive(false);
        playerStart.gameObject.SetActive(false);
        animalStart.gameObject.SetActive(false);

        

        quest.EndQuest();
        quest.DesactiveQuest();
    }

    public void Defeat()
    {
        

        courseActive = false;
        startQuest = true;
        animal.enabled = false;
        animal.gameObject.transform.position = animalStartPos;

        end.gameObject.SetActive(false);
        playerStart.gameObject.SetActive(false);
        animalStart.gameObject.SetActive(false);

        

        quest.DesactiveQuest();
    }

    public IEnumerator ReplaceCharacter()
    {
        player.enabled = false;
        player.gameObject.transform.position = playerEndPos.position;
        player.gameObject.transform.rotation = playerEndPos.rotation;


        yield return new WaitForSeconds(0.5f);

        player.enabled = true;
    }

    public IEnumerator StartQuestFondu()
    {
        animFondu.gameObject.SetActive(true);
        //animFondu.SetBool("etat", false);

        yield return new WaitForSeconds(1);

        player.enabled = false;
        player.gameObject.transform.position = playerStart.position;
        player.gameObject.transform.rotation = playerStart.rotation;
        player.camRoot.transform.rotation = new Quaternion(0, 0, 0, 0);

        animal.gameObject.transform.position = animalStart.position;
        animal.gameObject.transform.rotation = animalStart.rotation;

        yield return new WaitForSeconds(1);

        animFondu.gameObject.SetActive(false);
        courseActive = true;
        quest.activeQuest = false;
    }

    public IEnumerator QuestFonduFin()
    {
        animFondu.gameObject.SetActive(true);
        //animFondu.SetBool("etat", false);
        yield return new WaitForSeconds(1);

        StartCoroutine(ReplaceCharacter());

        yield return new WaitForSeconds(1);

        animFondu.gameObject.SetActive(false);
      
    }


}
