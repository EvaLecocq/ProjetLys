using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class MouseLook : MonoBehaviour
{
    // The target we are following
    public Transform target;
    // The distance in the x-z plane to the target
    public float distance = 10.0f;
    // the height we want the camera to be above the target
    public float height = 5.0f;
    // How much we 
    public float heightDamping = 2.0f;
    public float rotationDamping = 3.0f;

    public bool lockerCam = true;
    public bool playerFollowMouse = true;

    public bool cameraLibre = false;
    public MouseLookFree lookFree;
    public float timeToLock = 1f;
    public float freeLockMouseSensitive = 1;

    public bool useControl01 = true;
    public float mouseSensitivity = 100f;
    float xRotation = 0f;
    float yRotation = 0f;

    public bool stop = false;

    public CinemachineVirtualCamera camTPV;
    public CinemachineVirtualCamera camFreeLook;
    public CinemachineVirtualCamera camFPV;


    // Start is called before the first frame update
    void Start()
    {
        if(useControl01)
        {
            transform.parent = null;
        }
                    
    }

    void LateUpdate()
    {
        if (useControl01)
        {
            // Early out if we don't have a target
            if (!target)
                return;


            if (cameraLibre == false)
            {
                // Calculate the current rotation angles
                float wantedRotationAngle = target.eulerAngles.y;
                float wantedHeight = target.position.y + height;
                float currentRotationAngle = transform.eulerAngles.y;
                float currentHeight = transform.position.y;

                // Damp the rotation around the y-axis
                currentRotationAngle = Mathf.LerpAngle(currentRotationAngle, wantedRotationAngle, rotationDamping * Time.deltaTime);

                // Damp the height
                currentHeight = Mathf.Lerp(currentHeight, wantedHeight, heightDamping * Time.deltaTime);

                // Convert the angle into a rotation

                Quaternion currentRotation = Quaternion.Euler(0, currentRotationAngle, 0);

                // Set the position of the camera on the x-z plane to:
                // distance meters behind the target
                transform.position = target.position;
                transform.position -= currentRotation * Vector3.forward * distance;

                // Set the height of the camera
                transform.position = new Vector3(transform.position.x, currentHeight, transform.position.z);

            }

            if (cameraLibre == false)
            {
                // Always look at the target
                transform.LookAt(target);

                lookFree.enabled = false;
                camFreeLook.Priority = 0;
                camTPV.Priority = 5;
                //transform.parent = null;
            }

            if (cameraLibre)
            {
                lookFree.enabled = true;
                camFreeLook.Priority = 5;
                camTPV.Priority = 0;
                //transform.parent = target;
            }


            if (Input.GetAxis("Mouse X") < -freeLockMouseSensitive)
            {
                cameraLibre = true;
                StopAllCoroutines();
                //print("Mouse moved left");
            }
            if (Input.GetAxis("Mouse X") > freeLockMouseSensitive)
            {
                cameraLibre = true;
                StopAllCoroutines();
                //print("Mouse moved right");
            }

            if (Input.GetAxis("Mouse X") < freeLockMouseSensitive || Input.GetAxis("Mouse X") > -freeLockMouseSensitive)
            {
                StartCoroutine(CamOpen());
            }

        }
        else
        {
            if(stop == false)
            {
                float MouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
                float MouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;



                xRotation -= MouseY;
                yRotation -= MouseX;
                xRotation = Mathf.Clamp(xRotation, -22f, 20f);//rotation max
                yRotation = Mathf.Clamp(yRotation, -90f, 90f);


                transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
                target.Rotate(Vector3.up * MouseX);
                //transform.localRotation = Quaternion.Euler(xRotation, yRotation, 0f);

            }



        }
    }

    

    public IEnumerator CamOpen()
    {
        yield return new WaitForSeconds(timeToLock);

        cameraLibre = false;

    }

    // Update is called once per frame
    void Update()
    {
       if(lockerCam)
        {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }
       else
        {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }
       
    }
}
