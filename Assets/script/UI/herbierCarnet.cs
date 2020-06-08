using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class herbierCarnet : MonoBehaviour
{

    public bool pageDroite = true;

    public GameObject[] etape;
    public GameObject[] note;

    public GameObject noteSpecial01;
    public GameObject noteSpecial02;
    public GameObject noteSpecial03;
    public GameObject noteSpecial04;

   

    // Update is called once per frame
    void Update()
    {
        //principal
        if( GameManager.s_Singleton.progression == 0)
        {
            etape[0].SetActive(true);
        }
        if ( GameManager.s_Singleton.progression == 1)
        {
            etape[1].SetActive(true);
        }
        if ( GameManager.s_Singleton.progression == 2)
        {
            etape[2].SetActive(true);
        }
        if (GameManager.s_Singleton.progression == 3)
        {
            etape[3].SetActive(true);
        }
        if (GameManager.s_Singleton.progression == 4)
        {
            etape[4].SetActive(true);
        }
        if (GameManager.s_Singleton.progression == 5)
        {
            etape[5].SetActive(true);
        }
        if ( GameManager.s_Singleton.progression == 6)
        {
            etape[6].SetActive(true);
        }
        if ( GameManager.s_Singleton.progression == 7)
        {
            etape[7].SetActive(true);
        }



        //note
        if (GameManager.s_Singleton.niveauHerbier == 1)
        {
            note[0].SetActive(true);
        }
        if (GameManager.s_Singleton.niveauHerbier == 2)
        {
            note[1].SetActive(true);
        }
        if (GameManager.s_Singleton.niveauHerbier == 3)
        {
            note[2].SetActive(true);
        }
        if (GameManager.s_Singleton.niveauHerbier == 4)
        {
            note[3].SetActive(true);
        }
        if (GameManager.s_Singleton.niveauHerbier == 5)
        {
            note[4].SetActive(true);
        }
        if (GameManager.s_Singleton.niveauHerbier == 6)
        {
            note[5].SetActive(true);
        }

    }
}
