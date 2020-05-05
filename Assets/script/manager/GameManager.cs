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
    }

  
    public enum mode { soleil, pluie, tempete, brouillard }
    public mode meteoActive;

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

    public GameObject lapin;
    public bool clesDuParc = false;

    public bool queteActuelValider = false;

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
    public int feuille;
    public int baton;
    public int graineGland;
    public int terre;

    // Start is called before the first frame update
    void Start()
    {
        DontDestroyOnLoad(this.gameObject);

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

        UpdateDayWeek();

        if(queteActuelValider)
        {
            queteActuelValider = false;
            ProgressionPlus();
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
                    activeMeteo = false;
                }
                else if (meteo == 1)
                {
                    meteoActive = GameManager.mode.brouillard;
                    activeMeteo = false;
                }
                else if (meteo == 2)
                {
                    meteoActive = GameManager.mode.tempete;
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
                    activeMeteo = false;
                }
                else if (meteo == 1)
                {
                    meteoActive = GameManager.mode.soleil;
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
                    activeMeteo = false;
                }
                else if (meteo == 1)
                {
                    meteoActive = GameManager.mode.soleil;
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
                    activeMeteo = false;
                }
                else if (meteo == 1)
                {
                    meteoActive = GameManager.mode.pluie;
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
                    activeMeteo = false;
                }
                else if (meteo == 1)
                {
                    meteoActive = GameManager.mode.soleil;
                    activeMeteo = false;
                }


            }
        }
    }
}
