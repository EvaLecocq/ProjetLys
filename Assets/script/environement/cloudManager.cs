using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cloudManager : MonoBehaviour
{
   

    [Header("eclairage")]
    public SkyboxModule skyColor;
    public DayNightCycle sunColor;

    private float sunIntensityBase;
    private float sunIntensityVariationBase;

    public float sunIntensityPluie;
    public float sunIntensityVariationPluie;

    public float sunIntensityTempete;
    public float sunIntensityVariationTempete;

    [Header("nuage")]
    public Material[] nuageColor;
    private List<Transform> tableauNuage;

    public bool useRootPoint = true;
    public GameObject rootPoint;

    public Transform[] cloudRound;
    public float[] cloudRoundSpeed;
    public float[] cloudRoundSpeedDefault;
    public float[] cloudSpeedMultiplicatorTempete;

    public int morningCloudAppear;
    public int nightCloudDispawn;

    [Header("meteo")]
    public GameObject pluie;
    public GameObject tempete;
    public GameObject brouillard;
    public GameObject soleil;

    public GameObject[] thunder;
    public float speedSpawn;

    private bool invokeNightChange = true;

    public AudioSource audioS;
    public AudioSource audioStransition;
    public AudioSource audioSnight;
    public AudioSource audioSeffect;
    public AudioClip AmbiancePluie;
    public AudioClip AmbianceSoleil;
    public AudioClip AmbianceTempete;
    public AudioClip AmbianceBrouillard;
    public AudioClip AmbianceNuit;


    // Start is called before the first frame update
    void Start()
    {
        

     

        skyColor = SkyboxModule.FindObjectOfType<SkyboxModule>();
        sunColor = DayNightCycle.FindObjectOfType<DayNightCycle>();

        sunIntensityBase = sunColor.sunBaseIntensity;
        sunIntensityVariationBase = sunColor.sunVariation;

        for (int i = 0; i < cloudRoundSpeedDefault.Length; i++)
        {
            cloudRoundSpeedDefault[i] = cloudRoundSpeed[i];
        }

        tableauNuage = new List<Transform>();

        for (int i = 0; i < cloudRound.Length; i++)
        {
            foreach (Transform go in cloudRound[i])
            {
                tableauNuage.Add(go.transform);
            }
        }
        meteoChange();




    }

    // Update is called once per frame
    void Update()
    {
        if(useRootPoint)
        {
            transform.position = new Vector3(rootPoint.transform.position.x, transform.position.y, rootPoint.transform.position.z);
        }

        for (int i = 0; i < cloudRound.Length; i++)
        {
            cloudRound[i].Rotate(Vector3.up * cloudRoundSpeed[i]);
        }

        //meteoChange();

            CloudSpawn();
        
        if (GameManager.s_Singleton.time >= nightCloudDispawn || GameManager.s_Singleton.time < morningCloudAppear)
        {
            if(invokeNightChange)
            {
                hourChange();
            }
            
        }
        else
        {
            invokeNightChange = true;
            audioSnight.Stop();
        }

        

        if (Input.GetKeyDown(KeyCode.A))
        {
           // meteoChange();
        }
    }

    public void hourChange()
    {
        audioSnight.clip = AmbianceNuit;
     
        audioSnight.Play();

        if (GameManager.s_Singleton.meteoActive == GameManager.mode.soleil)
        {
            //audioS.Stop();
        }

            invokeNightChange = false;
    }

    public void meteoChange()
    {
        

        if (GameManager.s_Singleton.meteoActive == GameManager.mode.soleil)
        {
            pluie.SetActive(false);
            brouillard.SetActive(false);
            tempete.SetActive(false);
            soleil.SetActive(true);

            skyColor.meteo = SkyboxModule.temp.soleil;

            for (int i = 0; i < cloudRoundSpeed.Length; i++)
            {
                cloudRoundSpeed[i] = cloudRoundSpeedDefault[i];
            }

            foreach(Transform tr in tableauNuage)
            {
                tr.gameObject.GetComponent<Renderer>().material = nuageColor[0];
            }

            sunColor.sunBaseIntensity = sunIntensityBase;
            sunColor.sunVariation = sunIntensityVariationBase;

            CancelInvoke("ThunderStruck");

            audioS.clip = AmbianceSoleil;
         
            audioS.Play();
        }

        if (GameManager.s_Singleton.meteoActive == GameManager.mode.pluie)
        {
            pluie.SetActive(true);
            brouillard.SetActive(false);
            tempete.SetActive(false);
            soleil.SetActive(false);

            skyColor.meteo = SkyboxModule.temp.pluie;

            for (int i = 0; i < cloudRoundSpeed.Length; i++)
            {
                cloudRoundSpeed[i] = cloudRoundSpeedDefault[i];
            }

            foreach (Transform tr in tableauNuage)
            {
                tr.gameObject.GetComponent<Renderer>().material = nuageColor[1];
            }

            sunColor.sunBaseIntensity = sunIntensityPluie;
            sunColor.sunVariation = sunIntensityVariationPluie;

            CancelInvoke("ThunderStruck");

            audioS.clip = AmbiancePluie;
   
            audioS.Play();
        }

        if (GameManager.s_Singleton.meteoActive == GameManager.mode.tempete)
        {
            pluie.SetActive(false);
            brouillard.SetActive(false);
            tempete.SetActive(true);
            soleil.SetActive(false);

            skyColor.meteo = SkyboxModule.temp.tempete;

            for (int i = 0; i < cloudRoundSpeed.Length; i++)
            {
                cloudRoundSpeed[i] = cloudSpeedMultiplicatorTempete[i];
            }

            foreach (Transform tr in tableauNuage)
            {
                tr.gameObject.GetComponent<Renderer>().material = nuageColor[2];
            }

            sunColor.sunBaseIntensity = sunIntensityTempete;
            sunColor.sunVariation = sunIntensityVariationTempete;

            InvokeRepeating("ThunderStruck", 0f, speedSpawn);

            audioS.clip = AmbiancePluie;
     
            audioS.Play();

        }

        if (GameManager.s_Singleton.meteoActive == GameManager.mode.brouillard)
        {
            pluie.SetActive(false);
            brouillard.SetActive(true);
            tempete.SetActive(false);
            soleil.SetActive(false);

            skyColor.meteo = SkyboxModule.temp.brouillard;

            for (int i = 0; i < cloudRoundSpeed.Length; i++)
            {
                cloudRoundSpeed[i] = cloudRoundSpeedDefault[i];
            }

            foreach (Transform tr in tableauNuage)
            {
                tr.gameObject.GetComponent<Renderer>().material = nuageColor[1];
            }

            sunColor.sunBaseIntensity = sunIntensityPluie;
            sunColor.sunVariation = sunIntensityVariationPluie;

            CancelInvoke("ThunderStruck");

            audioS.clip = AmbianceBrouillard;
     
            audioS.Play();
        }
    }

    public void ThunderStruck()
    {
        
        foreach (GameObject go in thunder)
        {
            go.SetActive(false);
        }

        int range = Random.Range(0, thunder.Length);

        thunder[range].SetActive(true);

       audioSeffect.clip = AmbianceTempete;
        audioSeffect.pitch = Random.Range(0.8f, 1.2f);
        audioSeffect.Play();

        
    }

    public void CloudSpawn()
    {

        if (GameManager.s_Singleton.time >= nightCloudDispawn || GameManager.s_Singleton.time < morningCloudAppear)
        {

            if (GameManager.s_Singleton.meteoActive != GameManager.mode.tempete)
            {
                foreach (Transform go in cloudRound)
                {
                    go.gameObject.SetActive(false);
                }
            }
        }
        else
        {
            foreach (Transform go in cloudRound)
            {
                go.gameObject.SetActive(true);
            }
        }

    }
}
