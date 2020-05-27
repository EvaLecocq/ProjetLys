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
    public GameObject interactionIcon;

    public void PlaceFlower()
    {
        if (fleurType == pot.fleur.Agapanthe)
        {
            GameManager.s_Singleton.Agapanthe++;
        }
        else if (fleurType == pot.fleur.AncolieDuCanada)
        {
            GameManager.s_Singleton.AncolieDuCanada++;
        }
        else if (fleurType == pot.fleur.AngeliqueDesEstuaires)
        {
            GameManager.s_Singleton.AngeliqueDesEstuaires++;
        }
       
        else if (fleurType == pot.fleur.BleuMarie)
        {
            GameManager.s_Singleton.BleuMarie++;
        }
        else if (fleurType == pot.fleur.Chrysantheme)
        {
            GameManager.s_Singleton.Chrysantheme++;
        }
        else if (fleurType == pot.fleur.CirseCommun)
        {
            GameManager.s_Singleton.CirseCommun++;
        }
        else if (fleurType == pot.fleur.EuphorbeReveilleMatin)
        {
            GameManager.s_Singleton.EuphorbeReveilleMatin++;
        }
        else if (fleurType == pot.fleur.FleurDeLys)
        {
            GameManager.s_Singleton.FleurDeLys++;
        }
        else if (fleurType == pot.fleur.Fritillaire)
        {
            GameManager.s_Singleton.Fritillaire++;
        }
        else if (fleurType == pot.fleur.FumariaOfficinalis)
        {
            GameManager.s_Singleton.FumariaOfficinalis++;
        }
        else if (fleurType == pot.fleur.GazaniaRigens)
        {
            GameManager.s_Singleton.GazaniaRigens++;
        }
        else if (fleurType == pot.fleur.Gerbera)
        {
            GameManager.s_Singleton.Gerbera++;
        }
       
        else if (fleurType == pot.fleur.HelleboreOrient)
        {
            GameManager.s_Singleton.HelleboreOrient++;
        }
        else if (fleurType == pot.fleur.Hibiscus)
        {
            GameManager.s_Singleton.Hibiscus++;
        }
        else if (fleurType == pot.fleur.Kalanchoe)
        {
            GameManager.s_Singleton.Kalanchoe++;
        }
        else if (fleurType == pot.fleur.Orchidee)
        {
            GameManager.s_Singleton.Orchidee++;
        }
        else if (fleurType == pot.fleur.PaeoniaOfficinalis)
        {
            GameManager.s_Singleton.PaeoniaOfficinalis++;
        }

        else if (fleurType == pot.fleur.Rose)
        {
            GameManager.s_Singleton.Rose++;
        }
        else if (fleurType == pot.fleur.Tulipe)
        {
            GameManager.s_Singleton.Tulipe++;
        }



       
    }

}
