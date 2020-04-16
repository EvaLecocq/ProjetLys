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



    public float time;
    public int day;
    private DayNightCycle cycle;

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
    public int pierre;
    public int baton;
    public int gland;

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
    }
}
