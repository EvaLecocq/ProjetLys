using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class eventManager : MonoBehaviour
{

    public GameObject glacier;
    public GameObject cirque;
    public GameObject expoVin;
    public GameObject expoArt;

    // Update is called once per frame
    void Update()
    {
        EventChange();
    }

    public void EventChange()
    {
        if (GameManager.s_Singleton.actualEvent == GameManager.eventPark.glacier)
        {
            glacier.SetActive(true);
            cirque.SetActive(false);
            expoArt.SetActive(false);
            expoVin.SetActive(false);
        }

        if (GameManager.s_Singleton.actualEvent == GameManager.eventPark.cirque)
        {
            glacier.SetActive(false);
            cirque.SetActive(true);
            expoArt.SetActive(false);
            expoVin.SetActive(false);
        }

        if (GameManager.s_Singleton.actualEvent == GameManager.eventPark.expoVin)
        {
            glacier.SetActive(false);
            cirque.SetActive(false);
            expoArt.SetActive(false);
            expoVin.SetActive(true);
        }

        if (GameManager.s_Singleton.actualEvent == GameManager.eventPark.expoArt)
        {
            glacier.SetActive(false);
            cirque.SetActive(false);
            expoArt.SetActive(true);
            expoVin.SetActive(false);
        }
    }
}
