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

    [SerializeField] private Camera mainCamera;
    [SerializeField] private GameObject playerLight;
    [SerializeField] private GameObject planetLight;
    [SerializeField] private GameObject shipLight;
    [SerializeField] private GameObject dustParticles;

    [SerializeField] private int planetYRes; // Default 131

    // Player progress variables
    public bool MeteorSpawned = false;
    public bool TalkedToMae = false;

    [SerializeField] private GameObject storageRoomInteract;
    [HideInInspector] public GameObject redLight;


    [Header("Dialogues")]
    [SerializeField] private DialogueSequence exitStorageSequence;


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
            playerLight.SetActive(true);
            shipLight.SetActive(true);
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
            ChangePixelCamera(planetYRes);
            planetLight.SetActive(true);
            playerLight.SetActive(true);
            dustParticles.SetActive(true);
            shipLight.SetActive(false);
        }
        else if(_scene.name == MeteorScene.SceneName)
        {
            // Load meteor scene
            exitStorageSequence.StartSelf();
            Destroy(redLight);
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
    
}
