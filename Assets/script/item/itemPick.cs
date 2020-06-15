using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class itemPick : MonoBehaviour
{

    public enum type { Tulipe , CirseCommun , Chrysantheme , Orchidee , Hibiscus , PaeoniaOfficinalis , EuphorbeReveilleMatin , GazaniaRigens , HelleboreOrient ,
        FumariaOfficinalis , BleuMarie , AncolieDuCanada, Kalanchoe, Gerbera, AngeliqueDesEstuaires, Agapanthe, Rose, Fritillaire, FleurDeLys,
    feuille, baton, graineGland, terre};

    public type itemType;
    public Outline outlinerItem;
    public GameObject interactionIcon;

    public GameObject particuleReward;

    public bool isPick = false;

    private void Start()
    {
        outlinerItem = GetComponentInChildren<Outline>();
        
    }

    public void AddItemToManager()
    {
        if(itemType == itemPick.type.Agapanthe)
        {
            GameManager.s_Singleton.Agapanthe++;

            if(GameManager.s_Singleton.Agapanthe == 1)
            {
                UImanager.FindObjectOfType<UImanager>().itemOpenHerbier();
            }
        }
        else if (itemType == itemPick.type.AncolieDuCanada)
        {
            GameManager.s_Singleton.AncolieDuCanada++;

            if (GameManager.s_Singleton.AncolieDuCanada == 1)
            {
                UImanager.FindObjectOfType<UImanager>().itemOpenHerbier();
            }
        }
        else if (itemType == itemPick.type.AngeliqueDesEstuaires)
        {
            GameManager.s_Singleton.AngeliqueDesEstuaires++;

            if (GameManager.s_Singleton.AngeliqueDesEstuaires == 1)
            {
                UImanager.FindObjectOfType<UImanager>().itemOpenHerbier();
            }
        }
        else if (itemType == itemPick.type.baton)
        {
            GameManager.s_Singleton.baton++;
        }
        else if (itemType == itemPick.type.BleuMarie)
        {
            GameManager.s_Singleton.BleuMarie++;

            if (GameManager.s_Singleton.BleuMarie == 1)
            {
                UImanager.FindObjectOfType<UImanager>().itemOpenHerbier();
            }
        }
        else if (itemType == itemPick.type.Chrysantheme)
        {
            GameManager.s_Singleton.Chrysantheme++;

            if (GameManager.s_Singleton.Chrysantheme == 1)
            {
                UImanager.FindObjectOfType<UImanager>().itemOpenHerbier();
            }
        }
        else if (itemType == itemPick.type.CirseCommun)
        {
            GameManager.s_Singleton.CirseCommun++;

            if (GameManager.s_Singleton.CirseCommun == 1)
            {
                UImanager.FindObjectOfType<UImanager>().itemOpenHerbier();
            }
        }
        else if (itemType == itemPick.type.EuphorbeReveilleMatin)
        {
            GameManager.s_Singleton.EuphorbeReveilleMatin++;

            if (GameManager.s_Singleton.EuphorbeReveilleMatin == 1)
            {
                UImanager.FindObjectOfType<UImanager>().itemOpenHerbier();
            }
        }
        else if (itemType == itemPick.type.FleurDeLys)
        {
            GameManager.s_Singleton.FleurDeLys++;

            if (GameManager.s_Singleton.FleurDeLys == 1)
            {
                UImanager.FindObjectOfType<UImanager>().itemOpenHerbier();
            }
        }
        else if (itemType == itemPick.type.Fritillaire)
        {
            GameManager.s_Singleton.Fritillaire++;

            if (GameManager.s_Singleton.Fritillaire == 1)
            {
                UImanager.FindObjectOfType<UImanager>().itemOpenHerbier();
            }
        }
        else if (itemType == itemPick.type.FumariaOfficinalis)
        {
            GameManager.s_Singleton.FumariaOfficinalis++;

            if (GameManager.s_Singleton.FumariaOfficinalis == 1)
            {
                UImanager.FindObjectOfType<UImanager>().itemOpenHerbier();
            }
        }
        else if (itemType == itemPick.type.GazaniaRigens)
        {
            GameManager.s_Singleton.GazaniaRigens++;

            if (GameManager.s_Singleton.GazaniaRigens == 1)
            {
                UImanager.FindObjectOfType<UImanager>().itemOpenHerbier();
            }
        }
        else if (itemType == itemPick.type.Gerbera)
        {
            GameManager.s_Singleton.Gerbera++;

            if (GameManager.s_Singleton.Gerbera == 1)
            {
                UImanager.FindObjectOfType<UImanager>().itemOpenHerbier();
            }
        }
        else if (itemType == itemPick.type.graineGland)
        {
            GameManager.s_Singleton.graineGland++;

         

        }
        else if (itemType == itemPick.type.HelleboreOrient)
        {
            GameManager.s_Singleton.HelleboreOrient++;

            if (GameManager.s_Singleton.HelleboreOrient == 1)
            {
                UImanager.FindObjectOfType<UImanager>().itemOpenHerbier();
            }
        }
        else if (itemType == itemPick.type.Hibiscus)
        {
            GameManager.s_Singleton.Hibiscus++;

            if (GameManager.s_Singleton.Hibiscus == 1)
            {
                UImanager.FindObjectOfType<UImanager>().itemOpenHerbier();
            }
        }
        else if (itemType == itemPick.type.Kalanchoe)
        {
            GameManager.s_Singleton.Kalanchoe++;

            if (GameManager.s_Singleton.Kalanchoe == 1)
            {
                UImanager.FindObjectOfType<UImanager>().itemOpenHerbier();
            }
        }
        else if (itemType == itemPick.type.Orchidee)
        {
            GameManager.s_Singleton.Orchidee++;

            if (GameManager.s_Singleton.Orchidee == 1)
            {
                UImanager.FindObjectOfType<UImanager>().itemOpenHerbier();
            }
        }
        else if (itemType == itemPick.type.PaeoniaOfficinalis)
        {
            GameManager.s_Singleton.PaeoniaOfficinalis++;

            if (GameManager.s_Singleton.PaeoniaOfficinalis == 1)
            {
                UImanager.FindObjectOfType<UImanager>().itemOpenHerbier();
            }
        }
       
        else if (itemType == itemPick.type.Rose)
        {
            GameManager.s_Singleton.Rose++;

            if (GameManager.s_Singleton.Rose == 1)
            {
                UImanager.FindObjectOfType<UImanager>().itemOpenHerbier();
            }
        }
        else if (itemType == itemPick.type.Tulipe)
        {
            GameManager.s_Singleton.Tulipe++;

            if (GameManager.s_Singleton.Tulipe == 1)
            {
                UImanager.FindObjectOfType<UImanager>().itemOpenHerbier();
            }
        }

        Instantiate(particuleReward, transform.position, transform.rotation);

       Destroy(gameObject);
    }


   
}
