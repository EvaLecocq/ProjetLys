using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class cameraStartGame : MonoBehaviour
{
    public GameObject cart;
    public CinemachineVirtualCamera cartCam;

    public Animator portail;

    // Start is called before the first frame update
    void Start()
    {
        portail.Play("ouvert");

        cart.SetActive(true);
        Invoke("stop", 5f);
    }

    public void stop()
    {
        portail.SetBool("fermeture", true);
        cartCam.Priority = 0;
        cart.SetActive(false);
    }
}
