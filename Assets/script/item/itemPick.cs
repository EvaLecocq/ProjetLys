using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class itemPick : MonoBehaviour
{

    public enum type { Tulipe , CirseCommun , Chrysantheme , Orchidee , Hibiscus , PaeoniaOfficinalis , EuphorbeReveilleMatin , GazaniaRigens , HelleboreOrient ,
        FumariaOfficinalis , BleuMarie , AncolieDuCanada, Kalanchoe, Gerbera, AngeliqueDesEstuaires, Agapanthe, Rose, Fritillaire, FleurDeLys,
    pierre, baton, gland};

    public type itemType;
    public Outline outlinerItem;

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
        }
        else if (itemType == itemPick.type.AncolieDuCanada)
        {
            GameManager.s_Singleton.AncolieDuCanada++;
        }
        else if (itemType == itemPick.type.AngeliqueDesEstuaires)
        {
            GameManager.s_Singleton.AngeliqueDesEstuaires++;
        }
        else if (itemType == itemPick.type.baton)
        {
            GameManager.s_Singleton.baton++;
        }
        else if (itemType == itemPick.type.BleuMarie)
        {
            GameManager.s_Singleton.BleuMarie++;
        }
        else if (itemType == itemPick.type.Chrysantheme)
        {
            GameManager.s_Singleton.Chrysantheme++;
        }
        else if (itemType == itemPick.type.CirseCommun)
        {
            GameManager.s_Singleton.CirseCommun++;
        }
        else if (itemType == itemPick.type.EuphorbeReveilleMatin)
        {
            GameManager.s_Singleton.EuphorbeReveilleMatin++;
        }
        else if (itemType == itemPick.type.FleurDeLys)
        {
            GameManager.s_Singleton.FleurDeLys++;
        }
        else if (itemType == itemPick.type.Fritillaire)
        {
            GameManager.s_Singleton.Fritillaire++;
        }
        else if (itemType == itemPick.type.FumariaOfficinalis)
        {
            GameManager.s_Singleton.FumariaOfficinalis++;
        }
        else if (itemType == itemPick.type.GazaniaRigens)
        {
            GameManager.s_Singleton.GazaniaRigens++;
        }
        else if (itemType == itemPick.type.Gerbera)
        {
            GameManager.s_Singleton.Gerbera++;
        }
        else if (itemType == itemPick.type.gland)
        {
            GameManager.s_Singleton.gland++;
        }
        else if (itemType == itemPick.type.HelleboreOrient)
        {
            GameManager.s_Singleton.HelleboreOrient++;
        }
        else if (itemType == itemPick.type.Hibiscus)
        {
            GameManager.s_Singleton.Hibiscus++;
        }
        else if (itemType == itemPick.type.Kalanchoe)
        {
            GameManager.s_Singleton.Kalanchoe++;
        }
        else if (itemType == itemPick.type.Orchidee)
        {
            GameManager.s_Singleton.Orchidee++;
        }
        else if (itemType == itemPick.type.PaeoniaOfficinalis)
        {
            GameManager.s_Singleton.PaeoniaOfficinalis++;
        }
        else if (itemType == itemPick.type.pierre)
        {
            GameManager.s_Singleton.pierre++;
        }
        else if (itemType == itemPick.type.Rose)
        {
            GameManager.s_Singleton.Rose++;
        }
        else if (itemType == itemPick.type.Tulipe)
        {
            GameManager.s_Singleton.Tulipe++;
        }

        Destroy(gameObject);
    }
}
