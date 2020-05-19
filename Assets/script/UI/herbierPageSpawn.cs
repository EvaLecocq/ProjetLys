using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class herbierPageSpawn : MonoBehaviour
{
    public enum pageType
    {
        Tulipe, CirseCommun, Chrysantheme, Orchidee, Hibiscus, PaeoniaOfficinalis, EuphorbeReveilleMatin, GazaniaRigens, HelleboreOrient,
        FumariaOfficinalis, BleuMarie, AncolieDuCanada, Kalanchoe, Gerbera, AngeliqueDesEstuaires, Agapanthe, Rose, Fritillaire, FleurDeLys,
        feuille, baton, graineGland, terre, Sanglier, Lapin, Serpent, RatonLaveur, Renard, ChienChat, Cerf
    };

    public pageType page;

    public Sprite pageRempli;
    private Image pageActuel;
    public bool conditionRempli = false;


    // Start is called before the first frame update
    void Start()
    {
        pageActuel = GetComponent<Image>();
    }

    // Update is called once per frame
    void Update()
    {
      
            AddItemToManager();
        
    }

    public void conditionRempliValide()
    {
        if(conditionRempli == true)
        {
            pageActuel.sprite = pageRempli;
        }
    }


    public void AddItemToManager()
    {
        if (page == herbierPageSpawn.pageType.Agapanthe && GameManager.s_Singleton.Agapanthe > 0)
        {
            conditionRempli = true;
        }
        else if (page == herbierPageSpawn.pageType.AncolieDuCanada && GameManager.s_Singleton.AncolieDuCanada > 0)
        {
            conditionRempli = true;
        }
        else if (page == herbierPageSpawn.pageType.AngeliqueDesEstuaires && GameManager.s_Singleton.AngeliqueDesEstuaires > 0)
        {
            conditionRempli = true;
        }
        else if (page == herbierPageSpawn.pageType.baton && GameManager.s_Singleton.baton > 0)
        {
            conditionRempli = true;
        }
        else if (page == herbierPageSpawn.pageType.BleuMarie && GameManager.s_Singleton.BleuMarie > 0)
        {
            conditionRempli = true;
        }
        else if (page == herbierPageSpawn.pageType.Chrysantheme && GameManager.s_Singleton.Chrysantheme > 0)
        {
            conditionRempli = true;
        }
        else if (page == herbierPageSpawn.pageType.CirseCommun && GameManager.s_Singleton.CirseCommun > 0)
        {
            conditionRempli = true;
        }
        else if (page == herbierPageSpawn.pageType.EuphorbeReveilleMatin && GameManager.s_Singleton.EuphorbeReveilleMatin >0)
        {
            conditionRempli = true;
        }
        else if (page == herbierPageSpawn.pageType.FleurDeLys && GameManager.s_Singleton.FleurDeLys > 0)
        {
            conditionRempli = true;
        }
        else if (page == herbierPageSpawn.pageType.Fritillaire && GameManager.s_Singleton.Fritillaire >0)
        {
            conditionRempli = true;
        }
        else if (page == herbierPageSpawn.pageType.FumariaOfficinalis && GameManager.s_Singleton.FumariaOfficinalis > 0)
        {
            conditionRempli = true;
        }
        else if (page == herbierPageSpawn.pageType.GazaniaRigens && GameManager.s_Singleton.GazaniaRigens >0)
        {
            conditionRempli = true;
        }
        else if (page == herbierPageSpawn.pageType.Gerbera && GameManager.s_Singleton.Gerbera > 0)
        {
            conditionRempli = true;
        }
        else if (page == herbierPageSpawn.pageType.graineGland && GameManager.s_Singleton.graineGland > 0)
        {
            conditionRempli = true;
        }
        else if (page == herbierPageSpawn.pageType.HelleboreOrient && GameManager.s_Singleton.HelleboreOrient > 0)
        {
            conditionRempli = true;
        }
        else if (page == herbierPageSpawn.pageType.Hibiscus && GameManager.s_Singleton.Hibiscus > 0)
        {
            conditionRempli = true;
        }
        else if (page == herbierPageSpawn.pageType.Kalanchoe && GameManager.s_Singleton.Kalanchoe >0)
        {
            conditionRempli = true;
        }
        else if (page == herbierPageSpawn.pageType.Orchidee && GameManager.s_Singleton.Orchidee > 0)
        {
            conditionRempli = true;
        }
        else if (page == herbierPageSpawn.pageType.PaeoniaOfficinalis && GameManager.s_Singleton.PaeoniaOfficinalis > 0)
        {
            conditionRempli = true;
        }

        else if (page == herbierPageSpawn.pageType.Rose && GameManager.s_Singleton.Rose > 0)
        {
            conditionRempli = true;
        }
        else if (page == herbierPageSpawn.pageType.Tulipe && GameManager.s_Singleton.Tulipe > 0)
        {
            conditionRempli = true;
        }

        else if (page == herbierPageSpawn.pageType.Lapin && GameManager.s_Singleton.lapin > 0)
        {
            conditionRempli = true;
        }
        else if (page == herbierPageSpawn.pageType.Sanglier && GameManager.s_Singleton.sanglier > 0)
        {
            conditionRempli = true;
        }
        else if (page == herbierPageSpawn.pageType.Serpent && GameManager.s_Singleton.serpent > 0)
        {
            conditionRempli = true;
        }
        else if (page == herbierPageSpawn.pageType.RatonLaveur && GameManager.s_Singleton.ratonLaveur > 0)
        {
            conditionRempli = true;
        }
        else if (page == herbierPageSpawn.pageType.Renard && GameManager.s_Singleton.renard > 0)
        {
            conditionRempli = true;
        }
        else if (page == herbierPageSpawn.pageType.ChienChat && GameManager.s_Singleton.chienChat > 0)
        {
            conditionRempli = true;
        }
        else if (page == herbierPageSpawn.pageType.Cerf && GameManager.s_Singleton.cerf > 0)
        {
            conditionRempli = true;
        }


        conditionRempliValide();
    }
}
