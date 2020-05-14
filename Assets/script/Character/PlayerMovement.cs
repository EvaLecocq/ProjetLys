using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class PlayerMovement : MonoBehaviour
{
    public bool useBaseControl = true;
    public bool useControl01 = true;
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
   
    public KeyCode runKey;
    public KeyCode backWalk;
    public KeyCode frontWalk;
    public KeyCode leftWalk;
    public KeyCode rightWalk;
    public KeyCode interactionKey;

  
    private Rigidbody rb;
    private AudioSource source;
    public AudioClip jumpSFX;
    public AudioClip fallSFX;
    public AudioClip[] walkSFX;

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
    CharacterController Cc;

    private void Start()
    {
        if(useBaseControl)
        {
            defaultSpeed = speed;

            rb = GetComponent<Rigidbody>();
            source = GetComponent<AudioSource>();

            Cc = GetComponent<CharacterController>();

            managerDialogue = FindObjectOfType<Dialogue_Manager>();
        }

        


    }

    // Update is called once per frame
    void Update()
    {
        if (useBaseControl)
        {
            if(useControl01)
            {
                if (Cc.isGrounded)
                {
                    moveDirection = new Vector3(0, 0, Input.GetAxis("Vertical"));
                    moveDirection = transform.TransformDirection(moveDirection);
                    moveDirection *= speed;

                    if (Input.GetButtonDown("Jump"))
                    {
                        moveDirection.y = jumpSpeed;
                    }
                }

                moveDirection.y -= gravity * Time.deltaTime;

                transform.Rotate(Vector3.up, Input.GetAxis("Horizontal") * Time.deltaTime * speed * speedRotation * sens);

                Cc.Move(moveDirection * Time.deltaTime);

                /////////////////////////////////////////////////

                if (Input.GetKey(runKey))//course
                {
                    speed = runSpeed;
                }
                else
                {
                    speed = defaultSpeed;
                }

                if (Input.GetKey(frontWalk))//model front cam
                {
                    model.transform.localEulerAngles = Vector3.zero;
                    sens = 1;

                    look.cameraLibre = false;

                    StopAllCoroutines();
                }
                if (Input.GetKey(backWalk))//model arriere
                {
                    model.transform.localEulerAngles = backVector;
                    sens = -1;

                    look.cameraLibre = false;

                    StopAllCoroutines();
                }
                if (Input.GetKeyUp(backWalk))//flip
                {
                    StartCoroutine(FlipCharacter());
                }

            }
            else
            {
                if(isTalk == false)
                {
                    if (Cc.isGrounded)
                    {
                        moveDirection = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
                        moveDirection = Camera.main.transform.TransformDirection(moveDirection);
                        moveDirection *= speed;

                        if (Input.GetButtonDown("Jump"))
                        {
                            moveDirection.y = jumpSpeed;
                        }
                    }


                    moveDirection.y -= gravity * Time.deltaTime;

                    Cc.Move(moveDirection * Time.deltaTime);


                    if (Input.GetKey(runKey))//course
                    {
                        speed = runSpeed;
                    }
                    else
                    {
                        speed = defaultSpeed;
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

                    }
                    if (Input.GetKeyUp(rightWalk))//flip
                    {

                    }


                    look.stop = false;
                }
                else
                {
                    look.stop = true;

                    model.transform.rotation = new Quaternion(0,0,0,0);
                }
               
            }

            

        }

        if (item != null && item.isPick)//place l item ds la main
        {
            item.transform.position = itemHand.position;
            item.transform.rotation = itemHand.rotation;
        }

    }

    public IEnumerator FlipCharacter()
    {
        yield return new WaitForSeconds(timeToFlip);

        transform.localEulerAngles = new Vector3(0, transform.localEulerAngles.y + 180, 0);
        model.transform.localEulerAngles = Vector3.zero;
        sens = 1;
    }

    

    public void walk()
    {     

        source.clip = walkSFX[Random.Range(0, walkSFX.Length)];
        source.Play();
    }

    private void OnTriggerStay(Collider other)
    {
       

        if (other.CompareTag("item"))//outline
        {
            item = other.gameObject.GetComponent<itemPick>();

            if(item.isPick == false)
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
                dialogueActuel = other.GetComponent<Dialogue_Trigger>();

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
        if (other.CompareTag("item") && item != null)
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

            bancActuel = null;
        }
    }

  

    public IEnumerator CollectItem()
    {
        yield return new WaitForSeconds(timeItemDispawnHand);

        item.AddItemToManager();

        item = null;
    }
        
}
