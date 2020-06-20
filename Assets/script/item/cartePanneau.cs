using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cartePanneau : MonoBehaviour
{

    public Outline outlinerItem;
    public GameObject interactionIcon;

    public bool isPot = true;
    public int indexPage;

    public bool isPick = false;

    private void Start()
    {
        outlinerItem = GetComponentInChildren<Outline>();

    }

    public void UpgradeMap()
    {
        if (isPot)
        {
            if (GameManager.s_Singleton.herbierPot == 0)
            {
                GameManager.s_Singleton.herbierPot = 1;
                UImanager.FindObjectOfType<UImanager>().itemOpenHerbier();
                UImanager.FindObjectOfType<UImanager>().pageOpenHerbier(indexPage);
            }

        }
        if (isPot == false)
        {
            if (GameManager.s_Singleton.herbierFleurRare == 0)
            {
                GameManager.s_Singleton.herbierFleurRare = 1;
                UImanager.FindObjectOfType<UImanager>().itemOpenHerbier();
                UImanager.FindObjectOfType<UImanager>().pageOpenHerbier(indexPage);
            }
        }


    }


}


