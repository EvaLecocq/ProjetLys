using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mouseLook02 : MonoBehaviour
{
    public float mouseSensitivity = 100f;
    float xRotation = 0f;
    float yRotation = 0f;
    public Transform target;

    public bool lockerCam = true;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        float MouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        float MouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;



        xRotation -= MouseY;
        yRotation -= MouseX;
        xRotation = Mathf.Clamp(xRotation, -22f, 20f);//rotation max
        yRotation = Mathf.Clamp(yRotation, -90f, 90f);


        transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
        target.Rotate(Vector3.up * MouseX);

        if (lockerCam)
        {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }
        else
        {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }

        // transform.position = target.position;
    }
}
