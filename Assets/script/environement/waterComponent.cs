using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class waterComponent : MonoBehaviour
{

    public Material[] materiaux;
    public float nightHour = 20f;
    public float morningHour = 6f;

    private Renderer render;

    // Start is called before the first frame update
    void Start()
    {
        render = GetComponent<Renderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (GameManager.s_Singleton.time >= nightHour || GameManager.s_Singleton.time < morningHour)
        {
            render.material = materiaux[0];

        }
        else
        {
            render.material = materiaux[1];
        }
    }
}
