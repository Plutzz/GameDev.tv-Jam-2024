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

    [SerializeField] private Camera mainCamera;
    [SerializeField] private int planetYRes; // Default 131

    // Player progress variables
    public bool MeteorSpawned = false;
    public bool TalkedToMae = false;

    [SerializeField] private GameObject storageRoomInteract;


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
            if (MeteorSpawned)
            {
                // Load meteor scene
                exitStorageSequence.StartSelf();
            }
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
