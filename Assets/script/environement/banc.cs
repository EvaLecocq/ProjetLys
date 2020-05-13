using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class banc : MonoBehaviour
{

    private Outline outliner;
    public GameObject interactionIconBanc;
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
           ExitBanc();
        }
    }



    public void ActiveOutline()
    {
        outliner.enabled = true;
        interactionIconBanc.SetActive(true);
    }

    public void DesactiveOutline()
    {
        outliner.enabled = false;
        interactionIconBanc.SetActive(false);
    }


    public void EnterBanc()
    {

        isBanc = true;
        player.isTalk = true;

        player.gameObject.transform.position = pos.position;
        player.gameObject.transform.rotation = pos.rotation;

        DesactiveOutline();

        camBanc.Priority = 20;

    }

    public void ExitBanc()
    {
        isBanc = false;
        player.isTalk = false;

        camBanc.Priority = 0;
    }
}
