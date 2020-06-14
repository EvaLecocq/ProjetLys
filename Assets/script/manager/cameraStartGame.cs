using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class cameraStartGame : MonoBehaviour
{
    public GameObject cart;
    public CinemachineVirtualCamera cartCam;

    // Start is called before the first frame update
    void Start()
    {
        cart.SetActive(true);
        Invoke("stop", 5f);
    }

    public void stop()
    {
        cartCam.Priority = 0;
        cart.SetActive(false);
    }
}
