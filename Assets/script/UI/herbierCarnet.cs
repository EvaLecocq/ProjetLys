using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class herbierCarnet : MonoBehaviour
{

   

    public GameObject[] etape;
    public GameObject[] note;

    public GameObject noteSpecial01;
    public GameObject noteSpecial02;
    public GameObject noteSpecial03;
    public GameObject noteSpecial04;

    private void Start()
    {
        foreach (GameObject go in etape)
        {
            go.SetActive(false);
        }
        foreach (GameObject go in note)
        {
            go.SetActive(false);
        }
    }

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
            etape[0].SetActive(true);
            etape[1].SetActive(true);
        }

       

        if ( GameManager.s_Singleton.progression == 2)
        {
            etape[0].SetActive(true);
            etape[1].SetActive(true);
            etape[2].SetActive(true);
         
        }
        if (GameManager.s_Singleton.progression == 2 && GameManager.s_Singleton.queteSanglier)
        {
            etape[0].SetActive(true);
            etape[1].SetActive(true);
            etape[2].SetActive(true);
            etape[3].SetActive(true);
        }


        if (GameManager.s_Singleton.progression == 3)
        {
            etape[0].SetActive(true);
            etape[1].SetActive(true);
            etape[2].SetActive(true);
            etape[3].SetActive(true);
            etape[4].SetActive(true);
        }
        if (GameManager.s_Singleton.progression == 4)
        {
            etape[0].SetActive(true);
            etape[1].SetActive(true);
            etape[2].SetActive(true);
            etape[3].SetActive(true);
            etape[4].SetActive(true);
            etape[5].SetActive(true);
        }
        if (GameManager.s_Singleton.progression == 5)
        {
            etape[0].SetActive(true);
            etape[1].SetActive(true);
            etape[2].SetActive(true);
            etape[3].SetActive(true);
            etape[4].SetActive(true);
            etape[5].SetActive(true);
            etape[6].SetActive(true);
        }

        if (GameManager.s_Singleton.progression == 6 && GameManager.s_Singleton.queteChien)
        {
            etape[0].SetActive(true);
            etape[1].SetActive(true);
            etape[2].SetActive(true);
            etape[3].SetActive(true);
            etape[4].SetActive(true);
            etape[5].SetActive(true);
            etape[6].SetActive(true);
            etape[7].SetActive(true);
        }

        if ( GameManager.s_Singleton.progression == 6)
        {
            etape[0].SetActive(true);
            etape[1].SetActive(true);
            etape[2].SetActive(true);
            etape[3].SetActive(true);
            etape[4].SetActive(true);
            etape[5].SetActive(true);
            etape[6].SetActive(true);
            etape[7].SetActive(true);
            etape[8].SetActive(true);
        }
        if ( GameManager.s_Singleton.progression == 7)
        {
            etape[0].SetActive(true);
            etape[1].SetActive(true);
            etape[2].SetActive(true);
            etape[3].SetActive(true);
            etape[4].SetActive(true);
            etape[5].SetActive(true);
            etape[6].SetActive(true);
            etape[7].SetActive(true);
            etape[8].SetActive(true);
            etape[9].SetActive(true);
        }
        if (GameManager.s_Singleton.progression >= 8)
        {
            etape[0].SetActive(true);
            etape[1].SetActive(true);
            etape[2].SetActive(true);
            etape[3].SetActive(true);
            etape[4].SetActive(true);
            etape[5].SetActive(true);
            etape[6].SetActive(true);
            etape[7].SetActive(true);
            etape[8].SetActive(true);
            etape[9].SetActive(true);
            etape[10].SetActive(true);
        }

        if (GameManager.s_Singleton.progression >= 8 && GameManager.s_Singleton.clesDuParc)
        {
            etape[0].SetActive(true);
            etape[1].SetActive(true);
            etape[2].SetActive(true);
            etape[3].SetActive(true);
            etape[4].SetActive(true);
            etape[5].SetActive(true);
            etape[6].SetActive(true);
            etape[7].SetActive(true);
            etape[8].SetActive(true);
            etape[9].SetActive(true);
            etape[10].SetActive(true);
            etape[11].SetActive(true);
        }


        //note
        if (GameManager.s_Singleton.niveauHerbier == 1)
        {
            note[0].SetActive(true);
        }
        if (GameManager.s_Singleton.niveauHerbier == 2)
        {
            note[0].SetActive(true);
            note[1].SetActive(true);
        }
        if (GameManager.s_Singleton.niveauHerbier == 3)
        {
            note[0].SetActive(true);
            note[1].SetActive(true);
            note[2].SetActive(true);
        }
        if (GameManager.s_Singleton.niveauHerbier == 4)
        {
            note[0].SetActive(true);
            note[1].SetActive(true);
            note[2].SetActive(true);
            note[3].SetActive(true);
        }
        if (GameManager.s_Singleton.niveauHerbier == 5)
        {
            note[0].SetActive(true);
            note[1].SetActive(true);
            note[2].SetActive(true);
            note[3].SetActive(true);
            note[4].SetActive(true);
        }
        if (GameManager.s_Singleton.niveauHerbier == 6)
        {
            note[0].SetActive(true);
            note[1].SetActive(true);
            note[2].SetActive(true);
            note[3].SetActive(true);
            note[4].SetActive(true);
            note[5].SetActive(true);
        }

    }
}
