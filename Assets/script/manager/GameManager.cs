using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager s_Singleton;

    private void Awake()
    {
       

        if (s_Singleton != null)
        {
            Destroy(gameObject);
        }
        else
        {
            s_Singleton = this;
        }
       

       // ChargementJeu();
    }

    private PlayerMovement persoT;
    private float x = 12f;
    private float y = 3.4f;
    private float z = 2.5f;


    public enum mode { soleil, pluie, tempete, brouillard }
    public mode meteoActive;

    public cloudManager meteoManager;

    public enum dayWeek { lundi, mardi, mercredi, jeudi, vendredi, samedi, dimanche}
    public dayWeek actualDay;

    public enum eventPark { glacier, cirque, expoArt, expoVin, none }
    public eventPark actualEvent;

    public bool activeMeteo = false;

    public float time;
    public int day;
    private DayNightCycle cycle;

    
    

    [Header("principale")]
    public int progression = 0;

    public enum quete { debut, lapin, sanglier, serpent, ratonLaveur, renard, chienChat, renard2, cerf, fin };
    public quete principale;

    public bool canSave;

    public bool clesDuParc = false;
    private int clesDuParcInt = 0;

    public bool queteSanglier = false;
    public bool queteRaton = false;
    public int RatonSpam;
    public bool queteChien = false;

    public bool cadeauSanglierLivrer = false;
    public bool cadeauChienLivrer = false;

    public bool queteActuelValider = false;

    [Header("secondaire")]
    public int queteSecondaireAccompli;
    public int niveauHerbier = 0;
    public int herbierPot = 0;
    public int herbierFleurRare = 0;

    public int dialogueFait;

    public int alizar;
    public int cesar;
    public int papillon;
    public int franklin;
    public int felix;
    public int mariLouise;
    public int gaspard; 
    public int chatVinci; 
    public int pog; 


    [Header("animaux")]
    public int lapin;
    public int sanglier;
    public int serpent;
    public int ratonLaveur;
    public int renard;
    public int chienChat;
    public int cerf;

    [Header("fleur")]
    public int Tulipe;
    public int CirseCommun;
    public int Chrysantheme;
    public int Orchidee;
    public int Hibiscus;
    public int PaeoniaOfficinalis;
    public int EuphorbeReveilleMatin;
    public int GazaniaRigens;
    public int HelleboreOrient;
    public int FumariaOfficinalis;
    public int BleuMarie;
    public int AncolieDuCanada;
    public int Kalanchoe;
    public int Gerbera;
    public int AngeliqueDesEstuaires;
    public int Agapanthe;
    public int Rose;
    public int Fritillaire;
    public int FleurDeLys;

    [Header("objet")]
    public int baton;
    public int graineGland;

    [Header("pot")]
    public int potTulipe;
    public int potCirseCommun;
    public int potChrysantheme;
    public int potOrchidee;
    public int potHibiscus;
    public int potPaeoniaOfficinalis;
    public int potEuphorbeReveilleMatin;
    public int potGazaniaRigens;
    public int potHelleboreOrient;
    public int potFumariaOfficinalis;
    public int potBleuMarie;
    public int potAncolieDuCanada;
    public int potKalanchoe;
    public int potGerbera;
    public int potAngeliqueDesEstuaires;
    public int potAgapanthe;
    public int potRose;
    public int potFritillaire;
    public int potFleurDeLys;

    //sauvegarde a la fin de: pot, item, dialogue

    // Start is called before the first frame update
    void Start()
    {
        DontDestroyOnLoad(this.gameObject);

        meteoManager = cloudManager.FindObjectOfType<cloudManager>();

        persoT = PlayerMovement.FindObjectOfType<PlayerMovement>();

        cycle = DayNightCycle.FindObjectOfType<DayNightCycle>();
    }

    private void OnLevelWasLoaded(int level)
    {
        meteoManager = cloudManager.FindObjectOfType<cloudManager>();

        persoT = PlayerMovement.FindObjectOfType<PlayerMovement>();

        cycle = DayNightCycle.FindObjectOfType<DayNightCycle>();
    }

    // Update is called once per frame
    void Update()
    {
        time = cycle.timeHour;
        day = cycle.dayNumberWeek;


        if (cycle.elapsedTime == 0f)
        {
            activeMeteo = true;
            //Debug.Log("fonctionne");
        }

        if(canSave)
        {
            
            SauvegadeJeu();
            //InvokeRepeating("SauvegadeJeu", 0f, 30f);

            canSave = false;
        }

        UpdateDayWeek();

        UpdateQuest();

        upgradeHerbier();

        if (queteActuelValider)
        {
            queteActuelValider = false;
            ProgressionPlus();
        }
    }
    public void nouvellePartie()
    {
        canSave = true;

        PlayerPrefs.DeleteAll();

    }

    public void SauvegadeJeu()
    {
        //bete
        PlayerPrefs.SetInt("lapin", lapin);
        PlayerPrefs.SetInt("sanglier", sanglier);
        PlayerPrefs.SetInt("serpent", serpent);
        PlayerPrefs.SetInt("ratonLaveur", ratonLaveur);
        PlayerPrefs.SetInt("renard", renard);
        PlayerPrefs.SetInt("chienChat", chienChat);
        PlayerPrefs.SetInt("cerf", cerf);

        //fleur
        PlayerPrefs.SetInt("Tulipe", Tulipe);
        PlayerPrefs.SetInt("CirseCommun", CirseCommun);
        PlayerPrefs.SetInt("Chrysantheme", Chrysantheme);
        PlayerPrefs.SetInt("Orchidee", Orchidee);
        PlayerPrefs.SetInt("Hibiscus", Hibiscus);
        PlayerPrefs.SetInt("PaeoniaOfficinalis", PaeoniaOfficinalis);
        PlayerPrefs.SetInt("EuphorbeReveilleMatin", EuphorbeReveilleMatin);
        PlayerPrefs.SetInt("GazaniaRigens", GazaniaRigens);
        PlayerPrefs.SetInt("HelleboreOrient", HelleboreOrient);
        PlayerPrefs.SetInt("FumariaOfficinalis", FumariaOfficinalis);
        PlayerPrefs.SetInt("BleuMarie", BleuMarie);
        PlayerPrefs.SetInt("AncolieDuCanada", AncolieDuCanada);
        PlayerPrefs.SetInt("Kalanchoe", Kalanchoe);
        PlayerPrefs.SetInt("Gerbera", Gerbera);
        PlayerPrefs.SetInt("AngeliqueDesEstuaires", AngeliqueDesEstuaires);
        PlayerPrefs.SetInt("Agapanthe", Agapanthe);
        PlayerPrefs.SetInt("Rose", Rose);
        PlayerPrefs.SetInt("Fritillaire", Fritillaire);
        PlayerPrefs.SetInt("FleurDeLys", FleurDeLys);

        //pot
        PlayerPrefs.SetInt("potTulipe", potTulipe);
        PlayerPrefs.SetInt("potCirseCommun", potCirseCommun);
        PlayerPrefs.SetInt("potChrysantheme", potChrysantheme);
        PlayerPrefs.SetInt("potOrchidee", potOrchidee);
        PlayerPrefs.SetInt("potHibiscus", potHibiscus);
        PlayerPrefs.SetInt("potPaeoniaOfficinalis", potPaeoniaOfficinalis);
        PlayerPrefs.SetInt("potEuphorbeReveilleMatin", potEuphorbeReveilleMatin);
        PlayerPrefs.SetInt("potGazaniaRigens", potGazaniaRigens);
        PlayerPrefs.SetInt("potHelleboreOrient", potHelleboreOrient);
        PlayerPrefs.SetInt("potFumariaOfficinalis", potFumariaOfficinalis);
        PlayerPrefs.SetInt("potBleuMarie", potBleuMarie);
        PlayerPrefs.SetInt("potAncolieDuCanada", potAncolieDuCanada);
        PlayerPrefs.SetInt("potKalanchoe", potKalanchoe);
        PlayerPrefs.SetInt("potGerbera", potGerbera);
        PlayerPrefs.SetInt("potAngeliqueDesEstuaires", potAngeliqueDesEstuaires);
        PlayerPrefs.SetInt("potAgapanthe", potAgapanthe);
        PlayerPrefs.SetInt("potRose", potRose);
        PlayerPrefs.SetInt("potFritillaire", potFritillaire);
        PlayerPrefs.SetInt("potFleurDeLys", potFleurDeLys);

        //obj
        PlayerPrefs.SetInt("graineGland", graineGland);

        //stat
        PlayerPrefs.SetInt("progression", progression);
        PlayerPrefs.SetInt("herbierFleurRare", herbierFleurRare);
        PlayerPrefs.SetInt("herbierPot", herbierPot);


        PlayerPrefs.SetInt("alizar", alizar);
        PlayerPrefs.SetInt("cesar", cesar);
        PlayerPrefs.SetInt("gaspard", gaspard);
        PlayerPrefs.SetInt("papillon", papillon);
        PlayerPrefs.SetInt("felix", felix);
        PlayerPrefs.SetInt("mariLouise", mariLouise);
        PlayerPrefs.SetInt("pog", pog);
        PlayerPrefs.SetInt("chatVinci", chatVinci);
        PlayerPrefs.SetInt("franklin", franklin);

        if (clesDuParc)
        {
            clesDuParcInt = 1;
        }
        else
        {
            clesDuParcInt = 0;
        }

        PlayerPrefs.SetInt("clesDuParcInt", clesDuParcInt);

        /*x = persoT.transform.position.x;
        y = persoT.transform.position.y;
        z = persoT.transform.position.z;

        PlayerPrefs.SetFloat("x", x);
        PlayerPrefs.SetFloat("y", y);
        PlayerPrefs.SetFloat("z", z);*/
    }

    public void ChargementJeu()
    {
        //bete
        lapin = PlayerPrefs.GetInt("lapin");
        sanglier = PlayerPrefs.GetInt("sanglier");
        serpent = PlayerPrefs.GetInt("serpent");
        ratonLaveur = PlayerPrefs.GetInt("ratonLaveur");
        renard = PlayerPrefs.GetInt("renard");
        chienChat = PlayerPrefs.GetInt("chienChat");
        cerf = PlayerPrefs.GetInt("cerf");

        //fleur
        Tulipe = PlayerPrefs.GetInt("Tulipe");
        CirseCommun = PlayerPrefs.GetInt("CirseCommun");
        Chrysantheme = PlayerPrefs.GetInt("Chrysantheme");
        Orchidee = PlayerPrefs.GetInt("Orchidee");
        Hibiscus = PlayerPrefs.GetInt("Hibiscus");
        PaeoniaOfficinalis = PlayerPrefs.GetInt("PaeoniaOfficinalis");
        EuphorbeReveilleMatin = PlayerPrefs.GetInt("EuphorbeReveilleMatin");
        GazaniaRigens = PlayerPrefs.GetInt("GazaniaRigens");
        HelleboreOrient = PlayerPrefs.GetInt("HelleboreOrient");
        FumariaOfficinalis = PlayerPrefs.GetInt("FumariaOfficinalis");
        BleuMarie = PlayerPrefs.GetInt("BleuMarie");
        AncolieDuCanada = PlayerPrefs.GetInt("AncolieDuCanada");
        Kalanchoe = PlayerPrefs.GetInt("Kalanchoe");
        Gerbera = PlayerPrefs.GetInt("Gerbera");
        AngeliqueDesEstuaires = PlayerPrefs.GetInt("AngeliqueDesEstuaires");
        Agapanthe = PlayerPrefs.GetInt("Agapanthe");
        Fritillaire = PlayerPrefs.GetInt("Fritillaire");
        FleurDeLys = PlayerPrefs.GetInt("FleurDeLys");
        Rose = PlayerPrefs.GetInt("Rose");


        //pot
        potTulipe = PlayerPrefs.GetInt("potTulipe");
        potCirseCommun = PlayerPrefs.GetInt("potCirseCommun");
        potChrysantheme = PlayerPrefs.GetInt("potChrysantheme");
        potOrchidee = PlayerPrefs.GetInt("potOrchidee");
        potHibiscus = PlayerPrefs.GetInt("potHibiscus");
        potPaeoniaOfficinalis = PlayerPrefs.GetInt("potPaeoniaOfficinalis");
        potEuphorbeReveilleMatin = PlayerPrefs.GetInt("potEuphorbeReveilleMatin");
        potGazaniaRigens = PlayerPrefs.GetInt("potGazaniaRigens");
        potHelleboreOrient = PlayerPrefs.GetInt("potHelleboreOrient");
        potFumariaOfficinalis = PlayerPrefs.GetInt("potFumariaOfficinalis");
        potBleuMarie = PlayerPrefs.GetInt("potBleuMarie");
        potAncolieDuCanada = PlayerPrefs.GetInt("potAncolieDuCanada");
        potKalanchoe = PlayerPrefs.GetInt("potKalanchoe");
        potGerbera = PlayerPrefs.GetInt("potGerbera");
        potAngeliqueDesEstuaires = PlayerPrefs.GetInt("potAngeliqueDesEstuaires");
        potAgapanthe = PlayerPrefs.GetInt("potAgapanthe");
        potFritillaire = PlayerPrefs.GetInt("potFritillaire");
        potFleurDeLys = PlayerPrefs.GetInt("potFleurDeLys");
        potRose = PlayerPrefs.GetInt("potRose");

        //obj
        graineGland = PlayerPrefs.GetInt("graineGland");

        //stat
        progression = PlayerPrefs.GetInt("progression");
        herbierFleurRare = PlayerPrefs.GetInt("herbierFleurRare" );
        herbierPot = PlayerPrefs.GetInt("herbierPot" );

        alizar = PlayerPrefs.GetInt("alizar" );
        cesar = PlayerPrefs.GetInt("cesar" );
        gaspard = PlayerPrefs.GetInt("gaspard" );
        papillon = PlayerPrefs.GetInt("papillon" );
        felix = PlayerPrefs.GetInt("felix" );
        mariLouise = PlayerPrefs.GetInt("mariLouise" );
        pog = PlayerPrefs.GetInt("pog" );
        chatVinci = PlayerPrefs.GetInt("chatVinci");
        franklin = PlayerPrefs.GetInt("franklin");

        clesDuParcInt = PlayerPrefs.GetInt("clesDuParcInt");
        if (clesDuParcInt == 1)
        {
            clesDuParc = true;
        }
        else
        {
            clesDuParc = false;
        }

        /*
        x = PlayerPrefs.GetFloat("x");
        y = PlayerPrefs.GetFloat("y");
        z = PlayerPrefs.GetFloat("z");

        persoT.transform.position = new Vector3(x, y, z);
        */
        canSave = true;
    }

    public void upgradeHerbier()
    {
        dialogueFait = lapin + sanglier + serpent + ratonLaveur + renard + chienChat + cerf;

        if(dialogueFait >= 5 && dialogueFait < 10)
        {
            niveauHerbier = 1;
        }
        else if (dialogueFait >= 10 && dialogueFait < 15)
        {
            niveauHerbier = 2;
        }
        if (dialogueFait >= 15 && dialogueFait < 20)
        {
            niveauHerbier = 3;
        }
        else if (dialogueFait >= 20 && dialogueFait < 25)
        {
            niveauHerbier = 4;
        }
        if (dialogueFait >= 25 && dialogueFait < 30)
        {
            niveauHerbier = 5;
        }
        else if (dialogueFait >= 30 && dialogueFait < 35)
        {
            niveauHerbier = 6;
        }

    }

    public void ProgressionPlus()
    {
        progression++;
        EtatQueteEnum();
    }

    public void QueteFini()
    {
        queteActuelValider = true;
    }

    public void UpdateQuest()
    {
        if(graineGland >= 1)
        {
            queteSanglier = true;
        }
        if (HelleboreOrient >= 1)
        {
            queteChien = true;
        }
        if (RatonSpam >= 2)
        {
            queteRaton = true;
        }


        
    }

    public void EtatQueteEnum()
    {
        if(progression == 0)
        {
            principale = quete.debut;
        }
        if (progression == 1)
        {
            principale = quete.lapin;
        }
        if (progression == 2)
        {
            principale = quete.sanglier;
        }
        if (progression == 3)
        {
            principale = quete.serpent;
        }
        if (progression == 4)
        {
            principale = quete.ratonLaveur;
        }
        if (progression == 5)
        {
            principale = quete.renard;
        }
        if (progression == 6)
        {
            principale = quete.chienChat;
        }
        if (progression == 7)
        {
            principale = quete.renard2;
        }
        if (progression == 8)
        {
            principale = quete.cerf;
        }
        if (progression == 9)
        {
            principale = quete.fin;
        }
    }

    public void UpdateDayWeek()
    {

        if(day == 1)
        {
            actualDay = GameManager.dayWeek.lundi;

            actualEvent = GameManager.eventPark.glacier;

            if(activeMeteo)
            {
                meteoActive = GameManager.mode.soleil;

                meteoManager.meteoChange();

                activeMeteo = false;
            }

        }
        if (day == 2)
        {
            actualDay = GameManager.dayWeek.mardi;

            actualEvent = GameManager.eventPark.none;

            if (activeMeteo)
            {
                int meteo = Random.Range(0, 3);

                if(meteo == 0)
                {
                    meteoActive = GameManager.mode.pluie;

                    meteoManager.meteoChange();
                    activeMeteo = false;
                }
                else if (meteo == 1)
                {
                    meteoActive = GameManager.mode.brouillard;

                    meteoManager.meteoChange();
                    activeMeteo = false;
                }
                else if (meteo == 2)
                {
                    meteoActive = GameManager.mode.tempete;

                    meteoManager.meteoChange();
                    activeMeteo = false;
                }
  
            }
        }
        if (day == 3)
        {
            actualDay = GameManager.dayWeek.mercredi;

            actualEvent = GameManager.eventPark.cirque;

            if (activeMeteo)
            {
                int meteo = Random.Range(0, 2);

                if (meteo == 0)
                {
                    meteoActive = GameManager.mode.pluie;

                    meteoManager.meteoChange();
                    activeMeteo = false;
                }
                else if (meteo == 1)
                {
                    meteoActive = GameManager.mode.soleil;

                    meteoManager.meteoChange();
                    activeMeteo = false;
                }
                

            }
        }
        if (day == 4)
        {
            actualDay = GameManager.dayWeek.jeudi;

            actualEvent = GameManager.eventPark.none;

            if (activeMeteo)
            {
                int meteo = Random.Range(0, 2);

                if (meteo == 0)
                {
                    meteoActive = GameManager.mode.brouillard;

                    meteoManager.meteoChange();
                    activeMeteo = false;
                }
                else if (meteo == 1)
                {
                    meteoActive = GameManager.mode.soleil;

                    meteoManager.meteoChange();
                    activeMeteo = false;
                }


            }
        }
        if (day == 5)
        {
            actualDay = GameManager.dayWeek.vendredi;

            actualEvent = GameManager.eventPark.none;

            if (activeMeteo)
            {
                int meteo = Random.Range(0, 2);

               

                if (meteo == 0)
                {
                    meteoActive = GameManager.mode.tempete;

                    meteoManager.meteoChange();
                    activeMeteo = false;
                }
                else if (meteo == 1)
                {
                    meteoActive = GameManager.mode.pluie;

                    meteoManager.meteoChange();
                    activeMeteo = false;
                }



            }
        }
        if (day == 6)
        {
            actualDay = GameManager.dayWeek.samedi;

            actualEvent = GameManager.eventPark.expoArt;

            if (activeMeteo)
            {
                meteoActive = GameManager.mode.soleil;

                meteoManager.meteoChange();

                activeMeteo = false;
            }
        }
        if (day == 7)
        {
            actualDay = GameManager.dayWeek.dimanche;

            actualEvent = GameManager.eventPark.expoVin;

            if (activeMeteo)
            {
                int meteo = Random.Range(0, 2);

                if (meteo == 0)
                {
                    meteoActive = GameManager.mode.brouillard;

                    meteoManager.meteoChange();
                    activeMeteo = false;
                }
                else if (meteo == 1)
                {
                    meteoActive = GameManager.mode.soleil;

                    meteoManager.meteoChange();
                    activeMeteo = false;
                }


            }
        }
    }
}
