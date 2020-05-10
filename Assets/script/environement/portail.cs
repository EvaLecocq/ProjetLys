using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class portail : MonoBehaviour
{

    private Animator anim;

    private GameObject cible;
    public float distanceOpen;

    // Start is called before the first frame update
    void Start()
    {
        cible = PlayerMovement.FindObjectOfType<PlayerMovement>().GetComponent<GameObject>();
    }

    // Update is called once per frame
    void Update()
    {
        distance();

        if (distance() < distanceOpen)
        {
            //ouvrir le portail
        }
    }

    public float distance()
    {
        float dist = Vector3.Distance(cible.transform.position, transform.position);

        return dist;
    }
}
