using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lampadaire : MonoBehaviour
{
    public GameObject[] lightLamp;
   
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
        if(GameManager.s_Singleton.time >= nightHour || GameManager.s_Singleton.time < morningHour)
        {
            foreach(GameObject lg in lightLamp )
            {
                lg.SetActive(true);
            }
           
        }
        else
        {
            foreach (GameObject lg in lightLamp)
            {
                lg.SetActive(false);
            }
        }
    }
}
