using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class triggerStartGame : MonoBehaviour
{
    public Dialogue_Trigger lapinTrigger;

    private void OnTriggerEnter(Collider other)
    {
        if(GameManager.s_Singleton.progression == 0)
        {
            lapinTrigger.enabled = true;
            lapinTrigger.EventDialogue();
        }
    }
}
