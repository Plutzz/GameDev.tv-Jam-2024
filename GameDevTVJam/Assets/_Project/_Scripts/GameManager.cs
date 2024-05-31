using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : Singleton<GameManager>
{
    [SerializeField] private SceneField TutorialScene;
    [SerializeField] private SceneField StorageScene;
    [SerializeField] private SceneField GameplayScene;

    // Player progress variables
    public bool meteorSpawned = false;

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
            if (meteorSpawned)
            {
                // Load meteor scene
                exitStorageSequence.StartSelf();
            }
        }
        else if( _scene.name == StorageScene.SceneName) 
        {
            if(!meteorSpawned)
            {
                Instantiate(storageRoomInteract);
            }
        }
        else if( _scene.name == GameplayScene.SceneName)
        {

        }
    }

    public void SetMeteorSpawned(bool _spawned)
    {
        meteorSpawned = _spawned;
    }


    
}
