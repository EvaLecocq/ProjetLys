using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

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
        if (Input.GetKeyDown(KeyCode.P))
        {
            BackToMenu();
        }

    }
    public void Quitter()
    {
        Application.Quit();
    }
    public void Options()
    {

    }
    public void BackToMenu()
    {
        SceneManager.LoadScene(0);
        Time.timeScale = 1f;
    }
}
