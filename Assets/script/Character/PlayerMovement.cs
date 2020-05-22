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
    public CinemachineVirtualCamera camFPV;
    public Transform camRoot;
    public bool isBanc = false;
    public bool isTalk = false;
    private Dialogue_Manager managerDialogue;
    public Dialogue_Trigger dialogueActuel;
    public banc bancActuel;
    private UImanager ui;
    public Animator anim;

    public KeyCode runKey;
    public KeyCode backWalk;
    public KeyCode frontWalk;
    public KeyCode leftWalk;
    public KeyCode rightWalk;
    public KeyCode interactionKey;

  
    private Rigidbody rb;

    private float nextActionTime = 0.0f;
    private float period = 1.5f;

    private itemPick item;
    public Transform itemHand;
    public float timeItemDispawnHand = 1;

    public float speed = 6f;
    private float defaultSpeed;
    public float runSpeed = 3f;
    public float speedRotation = 10f;
    public float timeToFlip = 0.5f;
    public float jumpSpeed = 8f;
    public float gravity = 20f;
    public float sens = 1;
    private Vector3 moveDirection = Vector3.zero;
    private Vector3 CameraMoveCustom = Vector3.zero;
    CharacterController Cc;

    private void Start()
    {
        if(useBaseControl)
        {
            defaultSpeed = speed;

            rb = GetComponent<Rigidbody>();
           

            Cc = GetComponent<CharacterController>();

            managerDialogue = FindObjectOfType<Dialogue_Manager>();
        }

        ui = UImanager.FindObjectOfType<UImanager>();

        backVector = new Vector3(0, camRoot.position.y + 180, 0);
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


                    if (Input.GetKey(runKey))//course
                    {
                        speed = runSpeed;
                        //anim.SetBool("cour", true);
                    }
                    else
                    {
                        speed = defaultSpeed;
                       // anim.SetBool("cour", false);
                    }

                    if (Input.GetKey(frontWalk))//model front cam
                    {
                        model.transform.rotation = camRoot.rotation;
                        
                    }
                    if (Input.GetKey(backWalk))//model arriere
                    {
                        model.transform.rotation = camRoot.rotation;
                    }
                    if (Input.GetKeyUp(leftWalk))//flip
                    {
                        model.transform.rotation = camRoot.rotation;
                    }
                    if (Input.GetKeyUp(rightWalk))//flip
                    {
                        model.transform.rotation = camRoot.rotation;
                    }

                if (Input.GetKey(rightWalk) || Input.GetKey(leftWalk) || Input.GetKey(backWalk) || Input.GetKey(frontWalk))
                {
                    
                    anim.SetFloat("isWalking", 0.2f);
                }
                else
                {
                    anim.SetFloat("isWalking", 0.0f);
                }


                look.stop = false;
                }
                else
                {
                    look.stop = true;

                    model.transform.rotation = new Quaternion(0,0,0,0);
                }    

        }

        if (item != null && item.isPick)//place l item ds la main
        {
            item.transform.position = itemHand.position;
            item.transform.rotation = itemHand.rotation;

            if(item.itemType == itemPick.type.graineGland && GameManager.s_Singleton.progression == 2)
            {
                ui.sanglierTextSpawn();
            }
        }

    }

    public IEnumerator FlipCharacter()
    {
        yield return new WaitForSeconds(timeToFlip);

        transform.localEulerAngles = new Vector3(0, transform.localEulerAngles.y + 180, 0);
        model.transform.localEulerAngles = Vector3.zero;
        sens = 1;
    }

    

    

    private void OnTriggerStay(Collider other)
    {
       

        if (other.CompareTag("item"))//outline
        {
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
     

            if (Input.GetKeyDown(interactionKey))
            {
                item.isPick = true;

                StartCoroutine(CollectItem());
            }

        }

        //dialogue
        if (other.CompareTag("dialogue"))
        {
            if (managerDialogue.dialogueActive == false)
            {
                if(dialogueActuel == null)
                {
                    dialogueActuel = other.GetComponent<Dialogue_Trigger>();
  
                }

                dialogueActuel.enabled = true;
                dialogueActuel.ActiveOutline();

                if (Input.GetKeyDown(interactionKey))
                {
                    //Debug.Log(other);
                    dialogueActuel.EventDialogue();
                    
                }
            }
        }
       

        //banc
        
        if(other.CompareTag("banc") )
        {
            bancActuel = other.GetComponent<banc>();

            bancActuel.enabled = true;

            if (bancActuel.isBanc == false)
            {
                
                bancActuel.ActiveOutline();

                if (Input.GetKeyDown(interactionKey))
                {
                    bancActuel.EnterBanc();
                }
               
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

        //dialogue
        if (other.CompareTag("dialogue"))
        {
            if (managerDialogue.dialogueActive == false)
            {
                dialogueActuel.DesactiveOutline();
                dialogueActuel.enabled = false;
                

                dialogueActuel = null;
            }
        }

        //banc
        
         if (other.CompareTag("banc"))
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

        ui.sanglierTextDespawn();

        item = null;
    }

    
}
