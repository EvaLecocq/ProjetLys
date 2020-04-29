using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class banc : MonoBehaviour
{

    private Outline outliner;
    private PlayerMovement player;

    public Transform pos;
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

        player.camFPV.Priority = 10;
        
        player.transform.position = pos.position;
        player.transform.rotation = pos.rotation;

        player.enabled = false;
    }

    public void ExitBanc()
    {
        isBanc = false;

        player.enabled = true;

        player.camFPV.Priority = 0;
        
    }
}
