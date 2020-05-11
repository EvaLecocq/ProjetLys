using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class portail : MonoBehaviour
{

    private Animator anim;

    private Transform cible;
    public float distanceOpen;

    // Start is called before the first frame update
    void Start()
    {
        cible = PlayerMovement.FindObjectOfType<PlayerMovement>().GetComponent<Transform>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        distance();

        if (distance() < distanceOpen && GameManager.s_Singleton.clesDuParc)
        {
            anim.SetBool("active", true);
        }
    }

    public float distance()
    {
        float dist = Vector3.Distance(cible.transform.position, transform.position);

        return dist;
    }
}
