using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPick : MonoBehaviour
{
    public KeyCode pickKey;
    public int interactionDistance;
    public LayerMask interactionLayer;
    public bool asObject = false;
    private GameObject reference = null;
 

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit interactionHit;
        if (Physics.Raycast(Camera.main.transform.position, Camera.main.transform.forward, out interactionHit, interactionDistance, interactionLayer))
        {
            if(interactionHit.collider.gameObject.CompareTag("pickable") && reference == null)
            {
                reference = interactionHit.collider.gameObject;
               
                if(Input.GetKeyDown(pickKey))
                {
                    reference.GetComponent<EndGameMnager>().functionEnd();
                }
               
            }
            else
            {
                reference = null;
            }
            
           
        }
      

       




    }
}
