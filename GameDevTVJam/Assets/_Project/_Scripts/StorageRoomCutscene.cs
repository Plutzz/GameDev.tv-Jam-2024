using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class StorageRoomCutscene : MonoBehaviour
{
    [SerializeField] private float shakeIntensity;
    [SerializeField] private float shakeTime;
    [SerializeField] private Ease shakeEase;

    [SerializeField] private Color redColor;
    [SerializeField] private float redIntensity;
    [SerializeField] private GameObject redLight;
    public void CameraShake()
    {
        CinemachineShake.Instance.ShakeCamera(shakeIntensity, shakeTime, shakeEase);
    }

    public void GlobalLightOff()
    {
        GameManager.Instance.redLight = redLight;
        Light2D globalLight = GameObject.Find("Global Lighting").GetComponent<Light2D>();
        globalLight.intensity = 0;
    }

    public void GlobalLightOn()
    {
        Light2D globalLight = GameObject.Find("Global Lighting").GetComponent<Light2D>();
        globalLight.color = redColor;
        globalLight.intensity = redIntensity;
    }
}
