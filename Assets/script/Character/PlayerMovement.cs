using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class PlayerMovement : MonoBehaviour
{

    public GameObject model;
    public MouseLook look;
    public CinemachineVirtualCamera cam;
    public CinemachineVirtualCamera camFPV;
    public bool isBanc = false;
   
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
    public float speedRotation = 10f;
    public float jumpSpeed = 8f;
    public float gravity = 20f;
    private Vector3 moveDirection = Vector3.zero;
    CharacterController Cc;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        source = GetComponent<AudioSource>();

        Cc = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
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

        transform.Rotate(Vector3.up, Input.GetAxis("Horizontal") * Time.deltaTime * speed * speedRotation);

        Cc.Move(moveDirection * Time.deltaTime);


        if (item != null && item.isPick)//place l item ds la main
        {
            item.transform.position = itemHand.position;
            item.transform.rotation = itemHand.rotation;
        }

    }

    

    public void walk()
    {     

        source.clip = walkSFX[Random.Range(0, walkSFX.Length)];
        source.Play();
    }

    private void OnTriggerStay(Collider other)
    {
        if(other.CompareTag("item") && Input.GetKeyDown(interactionKey) && item != null)
        {
           
            item.isPick = true; 

            StartCoroutine(CollectItem());
        }

        if (other.CompareTag("item") && item == null)
        {
            item = other.gameObject.GetComponent<itemPick>();
            item.outlinerItem.enabled = true;
 
        }

        //dialogue
        if (other.CompareTag("dialogue") && Input.GetKeyDown(interactionKey))
        {
            if (FindObjectOfType<Dialogue_Manager>().dialogueActive == false)
            {
                
                other.GetComponent<Dialogue_Trigger>().EventDialogue();
            }
        }
        else if(other.CompareTag("dialogue"))
        {
            if (FindObjectOfType<Dialogue_Manager>().dialogueActive == false)
            {
                other.GetComponent<Dialogue_Trigger>().enabled = true;
                other.GetComponent<Dialogue_Trigger>().ActiveOutline();
            }
        }

        //banc
        
        if(other.CompareTag("banc") && Input.GetKeyDown(interactionKey))
        {
            if(other.GetComponent<banc>().isBanc == false)
            {
                other.GetComponent<banc>().EnterBanc();
            }
            
        }
        else if(other.CompareTag("banc"))
        {
            other.GetComponent<banc>().ActiveOutline();
        }
        
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("item") && item != null)
        {

            item.outlinerItem.enabled = false;
            item = null;

        }

        //dialogue
        if (other.CompareTag("dialogue"))
        {
            if (FindObjectOfType<Dialogue_Manager>().dialogueActive == false)
            {
                other.GetComponent<Dialogue_Trigger>().enabled = false;
                other.GetComponent<Dialogue_Trigger>().DesactiveOutline();
            }
        }

        //banc
        
        else if (other.CompareTag("banc"))
        {
            other.GetComponent<banc>().DesactiveOutline();
        }
    }

  

    public IEnumerator CollectItem()
    {
        yield return new WaitForSeconds(timeItemDispawnHand);

        item.AddItemToManager();

        item = null;
    }
        
}
