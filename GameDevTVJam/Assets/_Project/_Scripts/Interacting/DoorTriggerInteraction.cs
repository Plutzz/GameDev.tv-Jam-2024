using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorTriggerInteraction : TriggerInteractionBase
{

    public enum DoorToSpawnAt
    {
        None,
        One,
        Two,
        Three,
    }

    [Header("Spawn TO")]
    [SerializeField] private DoorToSpawnAt doorToSpawnAt;
    [SerializeField] private SceneField sceneToLoad;

    [Space(10f)]
    public DoorToSpawnAt currentDoor;

    public override void Interact()
    {
        Debug.Log("Use Door");
        SceneSwapManager.Instance.SwapSceneFromDoorUse(sceneToLoad, doorToSpawnAt);
        InputManager.Instance.EnablePlayerInput(false);
    }
}
