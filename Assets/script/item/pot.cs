using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pot : MonoBehaviour
{
    public enum fleur
    {
        Tulipe, CirseCommun, Chrysantheme, Orchidee, Hibiscus, PaeoniaOfficinalis, EuphorbeReveilleMatin, GazaniaRigens, HelleboreOrient,
        FumariaOfficinalis, BleuMarie, AncolieDuCanada, Kalanchoe, Gerbera, AngeliqueDesEstuaires, Agapanthe, Rose, Fritillaire, FleurDeLys,
        
    };

    public fleur fleurType;
    public Outline outlinerItem;
    public GameObject fleurDePot;
    public GameObject interactionIcon;

    public void PlaceFlower()
    {
        if (fleurType == pot.fleur.Agapanthe && GameManager.s_Singleton.Agapanthe > 0)
        {
            fleurDePot.SetActive(true);
        }
        else if (fleurType == pot.fleur.AncolieDuCanada && GameManager.s_Singleton.AncolieDuCanada > 0)
        {
            fleurDePot.SetActive(true);
        }
        else if (fleurType == pot.fleur.AngeliqueDesEstuaires && GameManager.s_Singleton.AngeliqueDesEstuaires > 0)
        {
            fleurDePot.SetActive(true);
        }
       
        else if (fleurType == pot.fleur.BleuMarie && GameManager.s_Singleton.BleuMarie > 0)
        {
            fleurDePot.SetActive(true);
        }
        else if (fleurType == pot.fleur.Chrysantheme && GameManager.s_Singleton.Chrysantheme > 0)
        {
            fleurDePot.SetActive(true);
        }
        else if (fleurType == pot.fleur.CirseCommun && GameManager.s_Singleton.CirseCommun > 0)
        {
            fleurDePot.SetActive(true);
        }
        else if (fleurType == pot.fleur.EuphorbeReveilleMatin && GameManager.s_Singleton.EuphorbeReveilleMatin > 0)
        {
            fleurDePot.SetActive(true);
        }
        else if (fleurType == pot.fleur.FleurDeLys && GameManager.s_Singleton.FleurDeLys > 0)
        {
            fleurDePot.SetActive(true);
        }
        else if (fleurType == pot.fleur.Fritillaire && GameManager.s_Singleton.Fritillaire > 0)
        {
            fleurDePot.SetActive(true);
        }
        else if (fleurType == pot.fleur.FumariaOfficinalis && GameManager.s_Singleton.FumariaOfficinalis > 0)
        {
            fleurDePot.SetActive(true);
        }
        else if (fleurType == pot.fleur.GazaniaRigens && GameManager.s_Singleton.GazaniaRigens > 0)
        {
            fleurDePot.SetActive(true);
        }
        else if (fleurType == pot.fleur.Gerbera && GameManager.s_Singleton.Gerbera > 0)
        {
            fleurDePot.SetActive(true);
        }
       
        else if (fleurType == pot.fleur.HelleboreOrient && GameManager.s_Singleton.HelleboreOrient > 0)
        {
            fleurDePot.SetActive(true);
        }
        else if (fleurType == pot.fleur.Hibiscus && GameManager.s_Singleton.Hibiscus > 0)
        {
            fleurDePot.SetActive(true);
        }
        else if (fleurType == pot.fleur.Kalanchoe && GameManager.s_Singleton.Kalanchoe > 0)
        {
            fleurDePot.SetActive(true);
        }
        else if (fleurType == pot.fleur.Orchidee && GameManager.s_Singleton.Orchidee > 0)
        {
            fleurDePot.SetActive(true);
        }
        else if (fleurType == pot.fleur.PaeoniaOfficinalis && GameManager.s_Singleton.PaeoniaOfficinalis > 0)
        {
            fleurDePot.SetActive(true);
        }

        else if (fleurType == pot.fleur.Rose && GameManager.s_Singleton.Rose > 0)
        {
            fleurDePot.SetActive(true);
        }
        else if (fleurType == pot.fleur.Tulipe && GameManager.s_Singleton.Tulipe > 0)
        {
            fleurDePot.SetActive(true);
        }


        outlinerItem.enabled = false;
        interactionIcon.SetActive(false);

    }

}
