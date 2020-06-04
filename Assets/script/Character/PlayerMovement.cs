using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class PlayerMovement : MonoBehaviour
{
    public bool useBaseControl = true;
    public GameObject model;
    private Vector3 backVector = new Vector3(0, 180, 0);
    public MouseLook look;
    public CinemachineVirtualCamera cam;
    public CinemachineBrain mainCamera;
    public Transform camRoot;
    public Transform camRootReverse;
    public bool maskBody = false;
    public bool isBanc = false;
    public bool isTalk = false;

    private Dialogue_Manager managerDialogue;
    public Dialogue_Trigger dialogueActuel;
    public banc bancActuel;
    public pot potActuel;

    private UImanager ui;
    public Animator anim;

    public KeyCode runKey;
    public KeyCode backWalk;
    public KeyCode frontWalk;
    public KeyCode leftWalk;
    public KeyCode rightWalk;
    public KeyCode interactionKey;

    public enum interactionType { item, dialogue, banc, pot};
    public interactionType type;


    private Rigidbody rb;

    private float nextActionTime = 0.0f;
    private float period = 0.5f;

    private itemPick item;
    public Transform itemHand;
    public float timeItemDispawnHand = 1;

    public float speed = 6f;
    private float defaultSpeed;
    public float runSpeed = 3f;
    public float jumpSpeed = 8f;
    public float gravity = 20f;
    private Vector3 moveDirection = Vector3.zero;
    private Vector3 CameraMoveCustom = Vector3.zero;
    private Quaternion qTo;
    CharacterController Cc;

    public Transform pasPivot;
    public GameObject particulePas;

  
    public float turnSmoothTime = 0.1f;
    float turnSmoothVelocity;

    [Header("son")]    
    private AudioSource audioS;
    public AudioClip collisionPersoSound;
    public AudioClip ramassageItemSound;
    public AudioClip jumpSFX;
    public AudioClip fallSFX;
    public AudioClip[] walkSFX;


    private void Start()
    {
        if(useBaseControl)
        {
            defaultSpeed = speed;

            rb = GetComponent<Rigidbody>();
           

            Cc = GetComponent<CharacterController>();
            
        }
        audioS = GetComponent<AudioSource>();
        managerDialogue = FindObjectOfType<Dialogue_Manager>();
        mainCamera = CinemachineBrain.FindObjectOfType<CinemachineBrain>();
        ui = UImanager.FindObjectOfType<UImanager>();

       // backVector = new Vector3(0, camRoot.position.y + 180, 0);
    }

    // Update is called once per frame
    void Update()
    {
        if (useBaseControl)
        {
            
                if(isTalk == false)
                {
                    if (Cc.isGrounded)
                    {
                        moveDirection = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
                        //CameraMoveCustom = new Vector3()
                        moveDirection = Camera.main.transform.TransformDirection(moveDirection);//doit ignorer le Y de la cam sinon fait des bond en arriere
                        moveDirection *= speed;

                        if (Input.GetButtonDown("Jump"))
                        {
                            moveDirection.y = jumpSpeed;
                        }
                        else
                        {
                            moveDirection.y = 0.0f;
                        }
                    }


                    moveDirection.y -= gravity * Time.deltaTime;

                    Cc.Move(moveDirection * Time.deltaTime);


                
                    //rotation du perso
                    Vector3 movement = new Vector3(Input.GetAxis("Horizontal"), 0.0f, Input.GetAxis("Vertical"));
                     movement = Camera.main.transform.TransformDirection(movement);
                    movement.y = 0f;

                model.transform.rotation = Quaternion.LookRotation(movement);
                model.transform.rotation = Quaternion.Slerp(model.transform.rotation, Quaternion.LookRotation(movement), 0.15f);
                /*
                if (movement.magnitude >= 0.1f)
                {
                    float targetAngle = Mathf.Atan2(movement.x, movement.y) * Mathf.Rad2Deg + Camera.main.transform.eulerAngles.y;
                    float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnSmoothVelocity, turnSmoothTime);

                    model.transform.rotation = Quaternion.Euler(0f, angle, 0f);

                }*/

                // model.transform.rotation = Quaternion.Slerp(model.transform.rotation, movement.rotation, Time.time * speed);


                    if (Input.GetKey(runKey))//course
                    {
                        speed = runSpeed;
                    anim.SetBool("isRunning", false);
                    anim.SetBool("isWalking", true);

                    
                        
                    }
                    else
                    {
                        speed = defaultSpeed;
                    //anim.SetBool("isRunning", true);
                    anim.SetBool("isWalking", false);

                    }

                


                    if (Input.GetKey(rightWalk) || Input.GetKey(leftWalk) || Input.GetKey(backWalk) || Input.GetKey(frontWalk))
                    {

                        if (Time.time > nextActionTime)
                        {
                        nextActionTime += period;
                        Instantiate(particulePas, pasPivot.transform.position, pasPivot.transform.rotation);
                        audioS.clip = walkSFX[Random.Range(0, walkSFX.Length)];
                        audioS.Play();
                        }
                    

                    qTo = model.transform.rotation;
                        anim.SetBool("isRunning", true);
                    }
                     else
                    {
                    
                    model.transform.rotation = qTo;
                        anim.SetBool("isRunning", false);
                    }


                    look.stop = false;
                     maskBody = false;
                }
                else
                {
                    look.stop = true;

                    model.transform.rotation = new Quaternion(0,0,0,0);
                }    


            if(maskBody)
            {
                model.SetActive(false);
            }
            else
            {
                model.SetActive(true);
            }

        }

        if (item != null && item.isPick)//place l item ds la main
        {
            item.transform.position = itemHand.position;
            item.transform.rotation = itemHand.rotation;

            if(item.itemType == itemPick.type.graineGland && GameManager.s_Singleton.progression == 2 && GameManager.s_Singleton.queteSanglier == false)
            {
                ui.sanglierTextSpawn();
            }
            else if (item.itemType != itemPick.type.graineGland && GameManager.s_Singleton.progression == 2 && GameManager.s_Singleton.queteSanglier == false)
            {
                ui.sanglierTextSpawnFaux();
            }

            if (item.itemType == itemPick.type.HelleboreOrient && GameManager.s_Singleton.progression == 6 && GameManager.s_Singleton.queteChien == false)
            {
                ui.chienChatTextSpawn();
            }
            else if (item.itemType != itemPick.type.HelleboreOrient && GameManager.s_Singleton.progression == 6 && GameManager.s_Singleton.queteChien == false)
            {
                ui.chienChatTextSpawnFaux();
            }
        }

        //interaction

        if (Input.GetKeyDown(interactionKey) && item != null && type == PlayerMovement.interactionType.item)
        {
            item.isPick = true;

            audioS.clip = ramassageItemSound;
            audioS.pitch = Random.Range(1, 1.4f);
            audioS.Play();

            StartCoroutine(CollectItem());
        }
        if (Input.GetKeyDown(interactionKey) && potActuel != null && type == PlayerMovement.interactionType.pot)
        {
            
            audioS.clip = ramassageItemSound;
            audioS.pitch = Random.Range(1, 1.4f);
            audioS.Play();

            potActuel.PlaceFlower();
            
        }

        if (Input.GetKeyDown(interactionKey) && bancActuel != null && bancActuel.isBanc == false && type == PlayerMovement.interactionType.banc)
        {
            bancActuel.EnterBanc();
        }

        if (Input.GetKeyDown(interactionKey) && dialogueActuel != null && managerDialogue.dialogueActive == false && type == PlayerMovement.interactionType.dialogue)
        {
            //Debug.Log(other);
            dialogueActuel.EventDialogue();

        }
    }
    /*
    public IEnumerator FlipCharacter()
    {
        //mainCamera.enabled = false;

        yield return new WaitForSeconds(timeToFlip);

        if(sens == 1)
        {
            transform.localEulerAngles = new Vector3(0, transform.localEulerAngles.y + 180, 0);
            //model.transform.localEulerAngles = Vector3.zero;
            model.transform.rotation = camRoot.rotation;
        }
        

        //yield return new WaitForSeconds(0.5f);

        //mainCamera.enabled = true;
        
    }*/

    

    

    private void OnTriggerStay(Collider other)
    {
       

        if (other.CompareTag("item"))//outline
        {
            type = PlayerMovement.interactionType.item;

            if(item == null)
            {
                item = other.gameObject.GetComponent<itemPick>();

            }

            if (item.isPick == false)
            {
                item.outlinerItem.enabled = true;
                item.interactionIcon.SetActive(true);
            }
            else
            {
                item.outlinerItem.enabled = false;
                item.interactionIcon.SetActive(false);
            }
       

        }

        //pot
        if (other.CompareTag("pot"))//outline
        {
            type = PlayerMovement.interactionType.pot;

            if (potActuel == null)
            {
                potActuel = other.gameObject.GetComponent<pot>();

            }

            if(potActuel.fleurDePot.activeInHierarchy == false)
            {
                potActuel.outlinerItem.enabled = true;
                potActuel.interactionIcon.SetActive(true);
            }
                
            


        }

        //dialogue
        if (other.CompareTag("dialogue"))
        {
            type = PlayerMovement.interactionType.dialogue;

            if (managerDialogue.dialogueActive == false)
            {
                dialogueActuel = null;

                if(dialogueActuel == null)
                {
                    dialogueActuel = other.GetComponent<Dialogue_Trigger>();
  
                }

                dialogueActuel.enabled = true;
                dialogueActuel.ActiveOutline();

                
            }
        }
       

        //banc
        
        if(other.CompareTag("banc") )
        {
            type = PlayerMovement.interactionType.banc;

            bancActuel = other.GetComponent<banc>();

            bancActuel.enabled = true;

            if (bancActuel.isBanc == false)
            {
                
                bancActuel.ActiveOutline();       
               
            }
            
        }
              
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("item") && item != null && item.isPick == false)
        {
            

            item.outlinerItem.enabled = false;
            item.interactionIcon.SetActive(false);
            item = null;

        }

        //pot
        if (other.CompareTag("pot") && potActuel != null)
        {


            potActuel.outlinerItem.enabled = false;
            potActuel.interactionIcon.SetActive(false);
            potActuel = null;

        }

        //dialogue
        if (other.CompareTag("dialogue") && dialogueActuel != null)
        {
            if (managerDialogue.dialogueActive == false)
            {
                dialogueActuel.DesactiveOutline();

                dialogueActuel.camDialogue.Priority = 0;
                dialogueActuel.camDialogue.enabled = false;

                dialogueActuel.enabled = false;
                

                dialogueActuel = null;
            }
        }

        //banc
        
         if (other.CompareTag("banc") && bancActuel != null)
        {
            bancActuel.DesactiveOutline();
            bancActuel.enabled = false;

            bancActuel = null;
        }
    }

  

    public IEnumerator CollectItem()
    {
        yield return new WaitForSeconds(timeItemDispawnHand);

        item.AddItemToManager();
        item = null;

        

        yield return new WaitForSeconds(2f);
        ui.sanglierTextDespawn();

       
    }

    
}
