using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cloudManager : MonoBehaviour
{
    public enum mode { soleil, pluie, tempete, brouillard }
    public mode meteoActive;

    private SkyboxModule skyColor;

    public bool useRootPoint = true;
    public GameObject rootPoint;

    public GameObject[] cloudRound;
    public float[] cloudRoundSpeed;

    public GameObject pluie;
    public GameObject tempete;
    public GameObject brouillard;

    // Start is called before the first frame update
    void Start()
    {
        skyColor = SkyboxModule.FindObjectOfType<SkyboxModule>();
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
            cloudRound[i].transform.Rotate(Vector3.up * cloudRoundSpeed[i]);
        }

        if (meteoActive == cloudManager.mode.soleil)
        {
            pluie.SetActive(false);
            brouillard.SetActive(false);
            tempete.SetActive(false);

            skyColor.meteo = SkyboxModule.temp.soleil;
        }
        if (meteoActive == cloudManager.mode.pluie)
        {
            pluie.SetActive(true);
            brouillard.SetActive(false);
            tempete.SetActive(false);

            skyColor.meteo = SkyboxModule.temp.pluie;
        }
        if (meteoActive == cloudManager.mode.tempete)
        {
            pluie.SetActive(false);
            brouillard.SetActive(false);
            tempete.SetActive(true);

            skyColor.meteo = SkyboxModule.temp.tempete;
        }
        if (meteoActive == cloudManager.mode.brouillard)
        {
            pluie.SetActive(false);
            brouillard.SetActive(true);
            tempete.SetActive(false);

            skyColor.meteo = SkyboxModule.temp.brouillard;
        }
    }
}
