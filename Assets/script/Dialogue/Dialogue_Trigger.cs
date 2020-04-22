using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dialogue_Trigger : MonoBehaviour
{
    public Dialogue _dialogue;
    public Dialogue2 _dialogue2;
    
    
 
    public void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player") 
        {
           
               
              //  FindObjectOfType<Dialogue_Manager>().StartDialogue2(_dialogue2);
          
                FindObjectOfType<Dialogue_Manager>().StartDialogue(_dialogue);
           
                
            
            
        }
    }
  
}
