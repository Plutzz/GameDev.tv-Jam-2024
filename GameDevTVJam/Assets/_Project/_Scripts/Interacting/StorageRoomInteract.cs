using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StorageRoomInteract : TriggerInteractionBase
{
    [SerializeField] private GameObject storageRoomCutscene;
    [SerializeField] private Dialogue dialogue;
    public override void Interact()
    {
        base.Interact();
        if(GameManager.Instance.TalkedToMae)
        {
            Instantiate(storageRoomCutscene, CutsceneManager.Instance.transform);
            GameManager.Instance.SetMeteorSpawned(true);
            Destroy(gameObject);
        }
        else
        {
            DialogueManager.Instance.StartDialogue(dialogue);
        }
    }

    public void SwitchActionMapCutscene()
    {
        InputManager.Instance.SwitchActionMap("Cutscene");
    }

    public void SwitchActionMapPlayer()
    {
        InputManager.Instance.SwitchActionMap("Player");
    }
}
