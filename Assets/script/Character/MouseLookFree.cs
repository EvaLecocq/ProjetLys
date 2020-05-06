using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseLookFree : MonoBehaviour
{
    public float mouseSensitivity = 100f;
    float xRotation = 0f;
    public Transform target;


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
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);

        
        transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
        target.Rotate(Vector3.up * MouseX);

        transform.parent = target;

       // transform.position = target.position;
    }
}
