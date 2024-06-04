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
    [SerializeField] private GameObject Player;
    [SerializeField] private GameObject PlayerHealthbar;

    [SerializeField] private int planetYRes; // Default 131

    // Player progress variables
    public bool MeteorSpawned = false;
    public bool TalkedToMae = false;

    [SerializeField] private GameObject storageRoomInteract;
    [HideInInspector] public GameObject redLight;

    private StudioEventEmitter alarmEventEmitter;

    [Header("Dialogues")]
    [SerializeField] private DialogueSequence exitStorageSequence;

    private void Start()
    {
        AudioManager.Instance.SetMusicArea(AudioManager.MusicArea.MaeTheme);
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
            playerLight.SetActive(true);
            shipLight.SetActive(true);
            PlayerHealthbar.SetActive(false);
            AudioManager.Instance.musicEventInstance.stop(FMOD.Studio.STOP_MODE.IMMEDIATE);

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
            AudioManager.Instance.musicEventInstance.start();
            AudioManager.Instance.SetMusicArea(AudioManager.MusicArea.Escape);
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
            AudioManager.Instance.SetMusicArea(AudioManager.MusicArea.Escape);
            AudioManager.Instance.musicEventInstance.start();
            // Turn on ship ambience if not on
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
            //AudioManager.Instance.SetAmbienceParameter();
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
