using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseLookFPV : MonoBehaviour
{
    public float mouseSensitivity = 100f;

    public Transform playerBody;

    float xRotation = 0f;

    public bool lockerCam = true;

    // Start is called before the first frame update
    void Start()
    {
        
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


       if(lockerCam)
        {
            float MouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
            float MouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;

            xRotation -= MouseY;
            xRotation = Mathf.Clamp(xRotation, -90f, 90f);

            transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
            playerBody.Rotate(Vector3.up * MouseX);
        }
       
    }
}
