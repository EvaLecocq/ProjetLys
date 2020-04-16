using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lampadaire : MonoBehaviour
{
    public Light[] lightLamp;
   
    public float nightHour = 20f;
    public float morningHour = 6f;

    // Start is called before the first frame update
    void Start()
    {
        //lightLamp = GetComponentInChildren<Light>();
    }

    // Update is called once per frame
    void Update()
    {
        if(GameManager.s_Singleton.time >= 20f || GameManager.s_Singleton.time < 6f)
        {
            foreach(Light lg in lightLamp )
            {
                lg.enabled = true;
            }
           
        }
        else
        {
            foreach (Light lg in lightLamp)
            {
                lg.enabled = false;
            }
        }
    }
}
