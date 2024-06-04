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
    [SerializeField] private FMODEvents.NetworkSFXName meteorSFX;
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

    public void SwitchActionMapCutscene()
    {
        InputManager.Instance.SwitchActionMap("Cutscene");
    }

    public void SwitchActionMapPlayer()
    {
        InputManager.Instance.SwitchActionMap("Player");
    }

    public void PlayMeteorOneShot()
    {
        AudioManager.Instance.PlayOneShot(meteorSFX, transform.position);
    }

    public void PlayAlarmOneShot()
    {
        GameManager.Instance.PlayAlarmSfx();
    }
}
