using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UImanager : MonoBehaviour
{
    public float time;
    public Image clock;

    public TextMeshProUGUI textDay;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        textDay.text = GameManager.s_Singleton.actualDay.ToString();

        time = GameManager.s_Singleton.time;
        clock.transform.rotation =  Quaternion.Euler(transform.eulerAngles.x, transform.eulerAngles.y, (time * -30));

    }
}
