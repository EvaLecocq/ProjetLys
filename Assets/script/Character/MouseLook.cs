using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
 

    // Start is called before the first frame update
    void Start()
    {
        
    }

    void LateUpdate()
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

        if (cameraLibre== false)
        {
            // Always look at the target
            transform.LookAt(target);

            lookFree.enabled = false;
            transform.parent = null;
        }

        if(cameraLibre)
        {
            lookFree.enabled = true;
            transform.parent = target;
        }


        if (Input.GetAxis("Mouse X") < 0)
        {
            cameraLibre = true;
            StopAllCoroutines();
            print("Mouse moved left");
        }
        if (Input.GetAxis("Mouse X") > 0)
        {
            cameraLibre = true;
            StopAllCoroutines();
            print("Mouse moved right");
        }

        if(Input.GetAxis("Mouse X") == 0)
        {
            StartCoroutine(CamOpen());
        }
    }

    public IEnumerator CamOpen()
    {
        yield return new WaitForSeconds(2);

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
