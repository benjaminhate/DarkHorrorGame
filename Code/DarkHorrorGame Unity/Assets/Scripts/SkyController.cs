using UnityEngine;

public class SkyController : MonoBehaviour
{
    [Header("Sun")]
    public Light sun;
        
    [Header("Day")]
    public Material daySkybox;
    public float dayLightIntensity = 2f;
        
    [Header("Night")]
    public Material nightSkybox;
    public float nightLightIntensity = 0.0001f;

    public void ChangeToNight()
    {
        RenderSettings.skybox = nightSkybox;
        sun.intensity = nightLightIntensity;
    }

    public void ChangeToDay()
    {
        RenderSettings.skybox = daySkybox;
        sun.intensity = dayLightIntensity;
    }
}