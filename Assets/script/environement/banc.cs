using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class banc : MonoBehaviour
{

    private Outline outliner;
    public GameObject interactionIconBanc;
    private PlayerMovement player;
    private DayNightCycle cycle;
    private bool speedTime = false;
    private float indiceRapport = 3;

    public Transform pos;
    public Collider coll;
    public CinemachineVirtualCamera camBanc;
    public mouseLook02 mouse;
    public bool isBanc = false;
    public KeyCode interactionKey;

    // Start is called before the first frame update
    void Start()
    {
        outliner = GetComponent<Outline>();
        player = PlayerMovement.FindObjectOfType<PlayerMovement>();

        cycle = DayNightCycle.FindObjectOfType<DayNightCycle>();

    }

    private void Update()
    {
        if(speedTime)
        {
            cycle._timeOfDay += 0.001f / indiceRapport;
            cycle.elapsedTime += 6f / indiceRapport;
        }
      

        if (Input.GetKeyDown(interactionKey) && isBanc)
        {
          
            speedTime = false;
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
        speedTime = true;
      
        player.isTalk = true;
       

        player.gameObject.transform.position = pos.position;
        player.gameObject.transform.rotation = pos.rotation;

        

        camBanc.Priority = 20;
        mouse.enabled = true;

        StartCoroutine(validateIsBanc());

    }

    public IEnumerator validateIsBanc()
    {
        yield return new WaitForSeconds(0.2f);
        isBanc = true;

       
        DesactiveOutline();

        yield return new WaitForSeconds(0.5f);
        player.maskBody = true;
    }

    public void ExitBanc()
    {
        isBanc = false;
        player.isTalk = false;
        player.maskBody = false;
        mouse.enabled = false;

        camBanc.Priority = 0;
        player.bancActuel = null;

        StartCoroutine(waitToTalk());
    }

    public IEnumerator waitToTalk()
    {
        coll.enabled = false;
        yield return new WaitForSeconds(1f);

        coll.enabled = true;

    }
}
