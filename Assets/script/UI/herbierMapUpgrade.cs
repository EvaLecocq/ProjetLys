using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class herbierMapUpgrade : MonoBehaviour
{

    public GameObject pot;
    public GameObject fleur;
    private Image pageActuel;

    public bool useAnimal = true;
    public GameObject[] animalIcon;

    // Start is called before the first frame update
    void Start()
    {
        pageActuel = GetComponent<Image>();

        foreach(GameObject go in animalIcon)
        {
            go.SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(GameManager.s_Singleton.herbierPot == 1)
        {
            pot.SetActive(true);
        }

        if (GameManager.s_Singleton.herbierFleurRare == 1)
        {
            fleur.SetActive(true);
        }

        if(useAnimal)
        {
            if (GameManager.s_Singleton.progression == 1)
            {
                animalIcon[0].SetActive(true);
            }
            if (GameManager.s_Singleton.progression == 2)
            {
                animalIcon[0].SetActive(true);
                animalIcon[1].SetActive(true);
            }
            if (GameManager.s_Singleton.progression == 3)
            {
                animalIcon[0].SetActive(true);
                animalIcon[1].SetActive(true);
                animalIcon[2].SetActive(true);
            }
            if (GameManager.s_Singleton.progression == 4)
            {
                animalIcon[0].SetActive(true);
                animalIcon[1].SetActive(true);
                animalIcon[2].SetActive(true);
                animalIcon[3].SetActive(true);
            }
            if (GameManager.s_Singleton.progression == 5)
            {
                animalIcon[0].SetActive(true);
                animalIcon[1].SetActive(true);
                animalIcon[2].SetActive(true);
                animalIcon[3].SetActive(true);
                animalIcon[4].SetActive(true);
            }
            if (GameManager.s_Singleton.progression >= 6)
            {
                animalIcon[0].SetActive(true);
                animalIcon[1].SetActive(true);
                animalIcon[2].SetActive(true);
                animalIcon[3].SetActive(true);
                animalIcon[4].SetActive(true);
                animalIcon[5].SetActive(true);
            }
            if (GameManager.s_Singleton.progression >= 8)
            {
                animalIcon[0].SetActive(true);
                animalIcon[1].SetActive(true);
                animalIcon[2].SetActive(true);
                animalIcon[3].SetActive(true);
                animalIcon[4].SetActive(true);
                animalIcon[5].SetActive(true);
                animalIcon[6].SetActive(true);
            }
        }

        

    }
}
