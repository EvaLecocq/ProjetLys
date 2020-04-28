using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public CharacterController controller;
    public GameObject model;
    bool orientation;
    public MouseLook look;

    public float speed = 12f;
    public float lateralSpeed = 0.4f;
    public float rotationSpeed = 1f;
    public float runMultiplier;
    public KeyCode runKey;
    public KeyCode backWalk;
    public KeyCode frontWalk;
    public KeyCode leftWalk;
    public KeyCode rightWalk;
    public KeyCode interactionKey;
    public float gravity = -9.81f;
    public float jumpHeight = 3f;
    private bool backWalking = false;
    private Vector3 backVector = new Vector3(0, 180, 0);

    public Transform groundCheck;
    public float groundDistance = 0.4f;
    public LayerMask groundMask;

    Vector3 velocity;
    public bool isGrounded;
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

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        source = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);  
        
        if ((isGrounded) && velocity.y < 0)
        {
            velocity.y = -2f;
        }
        
        MoveControl();
        RunControl();
        JumpControl();

        controller.Move(velocity * Time.deltaTime);

        if(item != null && item.isPick)//place l item ds la main
        {
            item.transform.position = itemHand.position;
            item.transform.rotation = itemHand.rotation;
        }

    }

    public void MoveControl()
    {
        if (Input.GetKey(leftWalk))//virage a gauche
        {
    
            transform.Rotate(Vector3.up * -rotationSpeed);

            if (backWalking == false)
            {
                if (orientation == true)
                {
                    model.transform.localEulerAngles = Vector3.zero;
                }

                if (model.transform.localEulerAngles.y > 270 || model.transform.localEulerAngles.y == 0)
                {
                    model.transform.Rotate(Vector3.up * -1f);
                    orientation = false;
                }
            }

            look.playerFollowMouse = false;
        }



        if (Input.GetKey(rightWalk))//virage a droite
        {
            transform.Rotate(Vector3.up * rotationSpeed);


            if (backWalking == false)
            {

                if (orientation == false)
                {
                    model.transform.localEulerAngles = Vector3.zero;
                }

                if (model.transform.localEulerAngles.y < 90)
                {
                    model.transform.Rotate(Vector3.up * 1f);
                    orientation = true;
                }
            }


            look.playerFollowMouse = false;
        }


        if (Input.GetKeyDown(backWalk))//arriere
        {

            model.transform.localEulerAngles = backVector;

            look.playerFollowMouse = false;

            backWalking = true;
        }


        if (Input.GetKey(frontWalk))//avant
        {
            model.transform.localEulerAngles = Vector3.zero;
            backWalking = false;

        }

        if (!Input.GetKey(frontWalk) && !Input.GetKey(backWalk) && !Input.GetKey(rightWalk) && !Input.GetKey(leftWalk))//aucune touche appuyer
        {
            look.playerFollowMouse = true;
            backWalking = false;
        }

        if (look.playerFollowMouse)//reset rotation du model
        {
            model.transform.localEulerAngles = Vector3.zero;
        }
    }

    public void JumpControl()
    {
        if (Input.GetButtonDown("Jump") && (isGrounded))
        {

            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
        }

        velocity.y += gravity * Time.deltaTime;
    }

    public void RunControl()
    {
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 move = transform.right * x * lateralSpeed + transform.forward * z;

        if (Input.GetKey(runKey))//course et marche
        {
            controller.Move(move * speed * Time.deltaTime);

            source.pitch = 1.2f;
        }
        else
        {
            controller.Move(move * speed * runMultiplier * Time.deltaTime);

            source.pitch = 1;

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

        
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("item") && item != null)
        {

            item.outlinerItem.enabled = false;
            item = null;

        }

        if (other.CompareTag("dialogue"))
        {
            if (FindObjectOfType<Dialogue_Manager>().dialogueActive == true)
            {
                other.GetComponent<Dialogue_Trigger>().StopDialogue();
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("dialogue"))
        {
            if (FindObjectOfType<Dialogue_Manager>().dialogueActive == false)
            {
                other.GetComponent<Dialogue_Trigger>().EventDialogue();
            }
        }
    }

    public IEnumerator CollectItem()
    {
        yield return new WaitForSeconds(timeItemDispawnHand);

        item.AddItemToManager();

        item = null;
    }
        
}
