using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkyboxModule : DNModuleBase {


    public enum temp { soleil, pluie, tempete, brouillard}
    public temp meteo;

    [Header("soleil")]
    [SerializeField]
    private Gradient skyColor;
    [SerializeField]
    private Gradient horizonColor;

    [Header("pluie")]
    [SerializeField]
    private Gradient skyColorPluie;
    [SerializeField]
    private Gradient horizonColorPluie;

    [Header("tempete")]
    [SerializeField]
    private Gradient skyColorTempete;
    [SerializeField]
    private Gradient horizonColorTempete;

    [Header("brouillard")]
    [SerializeField]
    private Gradient skyColorBrouillard;
    [SerializeField]
    private Gradient horizonColorBrouillard;

    public override void UpdateModule(float intensity)
    {
        if(meteo == SkyboxModule.temp.soleil)
        {
            RenderSettings.skybox.SetColor("_SkyTint", skyColor.Evaluate(intensity));
            RenderSettings.skybox.SetColor("_GroundColor", horizonColor.Evaluate(intensity));
        }
        if (meteo == SkyboxModule.temp.pluie)
        {
            RenderSettings.skybox.SetColor("_SkyTint", skyColorPluie.Evaluate(intensity));
            RenderSettings.skybox.SetColor("_GroundColor", horizonColorPluie.Evaluate(intensity));
        }
        if (meteo == SkyboxModule.temp.brouillard)
        {
            RenderSettings.skybox.SetColor("_SkyTint", skyColorBrouillard.Evaluate(intensity));
            RenderSettings.skybox.SetColor("_GroundColor", horizonColorBrouillard.Evaluate(intensity));
        }
        if (meteo == SkyboxModule.temp.tempete)
        {
            RenderSettings.skybox.SetColor("_SkyTint", skyColorTempete.Evaluate(intensity));
            RenderSettings.skybox.SetColor("_GroundColor", horizonColorTempete.Evaluate(intensity));
        }

    }
}
