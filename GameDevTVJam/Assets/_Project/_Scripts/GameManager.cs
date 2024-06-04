using FMODUnity;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.Rendering.Universal;
using UnityEngine.SceneManagement;

public class GameManager : Singleton<GameManager>
{
    [SerializeField] private SceneField TutorialScene;
    [SerializeField] private SceneField StorageScene;
    [SerializeField] private SceneField GameplayScene;
    [SerializeField] private SceneField MeteorScene;
    [SerializeField] private SceneField ComicScene;
    [SerializeField] private SceneField EndScene;

    [SerializeField] private Camera mainCamera;
    [SerializeField] private GameObject playerLight;
    [SerializeField] private GameObject planetLight;
    [SerializeField] private GameObject shipLight;
    [SerializeField] private GameObject dustParticles;
    [SerializeField] private GameObject mae;
    [SerializeField] private GameObject Player;
    [SerializeField] private GameObject PlayerHealthbar;

    [SerializeField] private int planetYRes; // Default 131

    // Player progress variables
    public bool MeteorSpawned = false;
    public bool TalkedToMae = false;
    public bool LeftShipOnce = false;

    [SerializeField] private GameObject storageRoomInteract;
    [HideInInspector] public GameObject redLight;

    private StudioEventEmitter alarmEventEmitter;
    public GameObject musicEventEmitter;
    [HideInInspector]public StudioEventEmitter currentMusicEventEmitter;

    public GameObject ambienceEventEmitter;
    [HideInInspector]public StudioEventEmitter currentAmbienceEventEmitter;

    [Header("Dialogues")]
    [SerializeField] private DialogueSequence exitStorageSequence;

    private void Start()
    {
        currentMusicEventEmitter = AudioManager.Instance.InitializeEventEmitter(FMODEvents.NetworkSFXName.MaeTheme, musicEventEmitter);
        currentMusicEventEmitter.Play();
    }


    private void OnEnable()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;

    }
    private void OnDisable()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    private void OnSceneLoaded(Scene _scene, LoadSceneMode _sceneMode)
    {
        if (_scene.name == TutorialScene.SceneName)
        {
            // Turn on ship ambience
            currentAmbienceEventEmitter = AudioManager.Instance.InitializeEventEmitter(FMODEvents.NetworkSFXName.ShipAmbience, ambienceEventEmitter);
            currentAmbienceEventEmitter.Play();
            playerLight.SetActive(true);
            shipLight.SetActive(true);
            PlayerHealthbar.SetActive(false);
            currentMusicEventEmitter?.Stop();
            Destroy(musicEventEmitter.GetComponent<StudioEventEmitter>());

        }
        else if( _scene.name == StorageScene.SceneName) 
        {
            if(!MeteorSpawned)
            {
                Instantiate(storageRoomInteract);
            }
        }
        else if( _scene.name == GameplayScene.SceneName)
        {
            LeftShipOnce = true;
            mae.SetActive(false);
            ChangePixelCamera(planetYRes);
            Player.SetActive(true);
            planetLight.SetActive(true);
            playerLight.SetActive(true);
            dustParticles.SetActive(true);
            shipLight.SetActive(false);
            PlayerHealthbar.SetActive(true);
        }
        else if(_scene.name == MeteorScene.SceneName)
        {
            mae.SetActive(true);
            if(!LeftShipOnce)
            {
                Destroy(musicEventEmitter.GetComponent<StudioEventEmitter>());
                currentMusicEventEmitter?.Stop();
                currentMusicEventEmitter = AudioManager.Instance.InitializeEventEmitter(FMODEvents.NetworkSFXName.Escape, musicEventEmitter);
                currentMusicEventEmitter.Play();
                currentAmbienceEventEmitter?.Stop();
                currentAmbienceEventEmitter = AudioManager.Instance.InitializeEventEmitter(FMODEvents.NetworkSFXName.ShipAmbience, ambienceEventEmitter);
                currentAmbienceEventEmitter.Play();
            }
            PlayAlarmSfx();
            ChangePixelCamera(132);
            // Load meteor scene
            exitStorageSequence.StartSelf();
            Destroy(redLight);
            PlayerHealthbar.SetActive(false);

            planetLight.SetActive(false);
            playerLight.SetActive(true);
            dustParticles.SetActive(false);
            shipLight.SetActive(true);
        }
        else if(_scene.name == ComicScene.SceneName) 
        {
            // Turn off ship ambience
            currentAmbienceEventEmitter?.Stop();
            alarmEventEmitter.Stop();
            alarmEventEmitter = null;
            Player.SetActive(false);
        }
        else if(_scene.name == EndScene.SceneName)
        {
            Player.SetActive(false);
            PlayerHealthbar.SetActive(false);
        }
    }

    public void SetMeteorSpawned(bool _spawned)
    {
        MeteorSpawned = _spawned;
    }

    public void SetTalkedToMae(bool _talkedToMae)
    {
        TalkedToMae = _talkedToMae;
    }

    public void ChangePixelCamera(int _yRes)
    {
        mainCamera.GetComponent<PixelPerfectCamera>().refResolutionY = _yRes;
    }

    public void PlayAlarmSfx()
    {
        if (alarmEventEmitter != null) return;

        alarmEventEmitter = AudioManager.Instance.InitializeEventEmitter(FMODEvents.NetworkSFXName.Alarm, gameObject);
        alarmEventEmitter.Play();
    }

}
