using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueInteract : TriggerInteractionBase
{
    [SerializeField] DialogueSequence sequence;
    public override void Interact()
    {
        base.Interact();
        sequence.StartSelf();
    }
}
