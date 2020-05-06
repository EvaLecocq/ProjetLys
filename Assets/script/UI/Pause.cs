using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pause : MonoBehaviour
{
    public GameObject pause;
    public bool ispause = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(ispause == false)
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                pause.gameObject.SetActive(true);
                ispause = true;
                Time.timeScale = 0f;
            }
        }
        else
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                if(ispause == true)
                {
                    pause.gameObject.SetActive(false);
                    ispause = false;
                    Time.timeScale = 1f;
                }
            }
        }
       
    }
    public void Quitter()
    {
        Application.Quit();
    }
    public void Options()
    {

    }
}
