﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public CharacterController controller;
    public GameObject model;
    bool orientation;
    public MouseLook look;

    public float speed = 12f;
    public float runMultiplier;
    public KeyCode runKey;
    public KeyCode backWalk;
    public KeyCode frontWalk;
    public KeyCode leftWalk;
    public KeyCode rightWalk;
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

        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

       

        Vector3 move = transform.right * x + transform.forward * z;


       // model.transform.localEulerAngles = Vector3.zero;


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


        if(Input.GetKey(leftWalk)/* && Time.time - nextActionTime >= period*/)//virage a gauche
        {
            //nextActionTime = Time.time;

            transform.Rotate(Vector3.up * -1f);

           
           
            if(backWalking == false)
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
            

            //model.transform.Rotate(model.transform.localEulerAngles.x, 90 , model.transform.localEulerAngles.z, Space.Self);

           look.playerFollowMouse = false;
        }
        else
        {
            //look.playerFollowMouse = true;
        }


        if (Input.GetKey(rightWalk))//virage a droite
        {
            transform.Rotate(Vector3.up * 1f);


            if(backWalking == false)
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
        else
        {
            //look.playerFollowMouse = true;         
        }


        if (Input.GetKeyDown(backWalk) )//arriere
        {
            //transform.Rotate(Vector3.up * 180);

            //model.transform.localEulerAngles = Vector3.zero;

            //model.transform.Rotate(Vector3.up * 180);
            model.transform.localEulerAngles = backVector;

            look.playerFollowMouse = false;

            backWalking = true;
        }
        else
        {
            
            //look.playerFollowMouse = true;  
        }

        if (Input.GetKey(frontWalk))//avant
        {
            model.transform.localEulerAngles = Vector3.zero;
            backWalking = false;

        }

        if(!Input.GetKey(frontWalk) && !Input.GetKey(backWalk) && !Input.GetKey(rightWalk) && !Input.GetKey(leftWalk))//aucune touche appuyer
        {
            look.playerFollowMouse = true;
            backWalking = false;
        }

        if(look.playerFollowMouse)//reset rotation du model
        {
           model.transform.localEulerAngles = Vector3.zero;
        }

        /*
         if (Time.time > nextActionTime && isGrounded && (Input.GetKey(KeyCode.Z) || Input.GetKey(KeyCode.Q) || Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.S)))
         {

             nextActionTime += period;
             walk();
         }*/
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
