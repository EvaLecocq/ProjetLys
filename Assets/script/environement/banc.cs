using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class banc : MonoBehaviour
{

    private Outline outliner;
    private PlayerMovement player;

    public Transform pos;
    public CinemachineVirtualCamera camBanc;
    public mouseLook02 mouse;
    public bool isBanc = false;
    public KeyCode interactionKey;

    // Start is called before the first frame update
    void Start()
    {
        outliner = GetComponent<Outline>();
        player = PlayerMovement.FindObjectOfType<PlayerMovement>();
    }

    private void Update()
    {
        
         if (Input.GetKeyDown(interactionKey) && isBanc)
        {
           // ExitBanc();
        }
    }



    public void ActiveOutline()
    {
        outliner.enabled = true;
    }

    public void DesactiveOutline()
    {
        outliner.enabled = false;
    }


    public void EnterBanc()
    {

        isBanc = true;

       
    }

    public void ExitBanc()
    {
        isBanc = false;

       
        
    }
}
