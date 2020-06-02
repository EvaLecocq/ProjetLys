using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovementFPV : MonoBehaviour
{
    public CharacterController controller;
    public MouseLookFPV mouse;
    public Animator anim;

    [Header("stat")]
    public float speed = 12f;
    private float baseSpeed;
    public float runMultiplier;
    public KeyCode runKey;
    public float gravity = -9.81f;
    public float jumpHeight = 3f;


    [Header("sol")]
    public Transform groundCheck;
    public float groundDistance = 0.4f;
    public LayerMask groundMask;
    Vector3 velocity;
    public bool isGrounded;
    private Rigidbody rb;

    [Header("son")]
    private AudioSource source;
    public AudioClip jumpSFX;
    public AudioClip fallSFX;
    public AudioClip[] walkSFX;

    private float nextActionTime = 0.0f;
    private float period = 0.5f;

    private void Start()
    {
        baseSpeed = speed;
      
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

        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

       

        Vector3 move = transform.right * x + transform.forward * z;

       // transform.rotation = new Quaternion(0, transform.rotation.y, 0, transform.rotation.w);//freeze la rotation pour le parentage
        
        if (Input.GetKey(runKey))
        {
            controller.Move(move * speed * runMultiplier * Time.deltaTime);

          
            source.pitch = 1.2f;

            anim.SetBool("isRunning", true);
            anim.SetBool("isWalking", false);
        }
        else
        {
            controller.Move(move * speed * Time.deltaTime);

            source.pitch = 1;

            anim.SetBool("isRunning", false);
        }

       
        if (Time.time > nextActionTime && isGrounded && (Input.GetKey(KeyCode.Z) || Input.GetKey(KeyCode.Q) || Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.S)))
        {
 
            nextActionTime += period;
            walk();
        }
       

        if ((Input.GetKey(KeyCode.Z) || Input.GetKey(KeyCode.Q) || Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.S)))
        {

            anim.SetBool("isWalking", true);

           
        }
        else
        {
            anim.SetBool("isWalking", false);
        }


        if (Input.GetButtonDown("Jump") &&( isGrounded))
        {
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
        }


        velocity.y += gravity * Time.deltaTime;
        
        

        controller.Move(velocity * Time.deltaTime);
    }

    

    public void walk()
    {     

        source.clip = walkSFX[Random.Range(0, walkSFX.Length)];
        source.Play();
    }
   
}
