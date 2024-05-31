using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneSwapManager : Singleton<SceneSwapManager>
{
    public SceneField scene;

    private bool loadFromDoor;

    private DoorTriggerInteraction.DoorToSpawnAt doorToSpawnTo;

    private GameObject player;
    private Collider2D playerCol;
    private Collider2D doorCol;
    private Vector3 spawnPos;

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.G))
        {
            Debug.Log("Transition scene");
            StartCoroutine(FadeOutThenChangeScene(scene));
        }
    }

    private void OnEnable()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    private void OnDisable()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    public void SwapSceneFromDoorUse(SceneField _scene, DoorTriggerInteraction.DoorToSpawnAt _doorToSpawnAt)
    {
        StartCoroutine(FadeOutThenChangeScene(_scene, _doorToSpawnAt));
        loadFromDoor = true;
    }

    public void FadeOutAndChangeScene(SceneField _scene)
    {
        StartCoroutine(FadeOutThenChangeScene(_scene));
    }

    public IEnumerator FadeOutThenChangeScene(SceneField myScene, DoorTriggerInteraction.DoorToSpawnAt _doorToSpawnAt = DoorTriggerInteraction.DoorToSpawnAt.None)
    {
        Debug.Log("Start Fade Out");
        SceneFadeManager.Instance.StartFadeOut();

        while(SceneFadeManager.Instance.IsFadingOut)
        {
            yield return null;
        }

        SceneManager.LoadScene(myScene);
        doorToSpawnTo = _doorToSpawnAt;
    }



    private void OnSceneLoaded(Scene _scene, LoadSceneMode _mode)
    {
        SceneFadeManager.Instance.StartFadeIn();

        if(loadFromDoor)
        {
            FindDoor(doorToSpawnTo);
            player.transform.position = spawnPos;
            loadFromDoor = false;
        }
    }

    private void FindDoor(DoorTriggerInteraction.DoorToSpawnAt _doorSpawnNumber)
    {

        player = InputManager.Instance.gameObject;
        playerCol = player.GetComponent<Collider2D>();

        DoorTriggerInteraction[] doors = FindObjectsOfType<DoorTriggerInteraction>();

        foreach(DoorTriggerInteraction door in doors)
        {
            if(door.currentDoor == _doorSpawnNumber)
            {
                doorCol = door.GetComponent<Collider2D>();

                CalculateSpawnPosition();

                return;
            }
        }
    }

    private void CalculateSpawnPosition()
    {
        float colliderHeight = playerCol.bounds.extents.y;
        spawnPos = doorCol.transform.position - Vector3.up * colliderHeight / 2;
    }

}
