using Cinemachine;
using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CinemachineShake : Singleton<CinemachineShake>
{
    private CinemachineBrain cinemachineBrain;

    protected override void Awake()
    {
        base.Awake();
        cinemachineBrain = GetComponent<CinemachineBrain>();
    }

    public void ShakeCamera(float intensity, float time, Ease ease)
    {
        CinemachineVirtualCamera[] camArr = cinemachineBrain.ActiveVirtualCamera.VirtualCameraGameObject.GetComponentsInChildren<CinemachineVirtualCamera>();

        foreach(var cam in camArr)
        {
            CinemachineBasicMultiChannelPerlin camBasicMultiChannelPerlin = cam.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>();

            camBasicMultiChannelPerlin.m_AmplitudeGain = intensity;

            DOTween.To(() => camBasicMultiChannelPerlin.m_AmplitudeGain, intensity => camBasicMultiChannelPerlin.m_AmplitudeGain = intensity, 0f, time).SetEase(ease);
        }
    }
}
