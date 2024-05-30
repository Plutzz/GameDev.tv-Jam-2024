using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StorageRoomInteract : TriggerInteractionBase
{
    [SerializeField] private GameObject storageRoomCutscene;
    public override void Interact()
    {
        Instantiate(storageRoomCutscene, CutsceneManager.Instance.transform);
        Destroy(gameObject);
    }
}
