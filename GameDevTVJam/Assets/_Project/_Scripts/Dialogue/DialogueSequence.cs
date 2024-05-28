using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueSequence : MonoBehaviour
{
    [SerializeField] private List<Dialogue> dialogues;
    private bool dialogueStarted;

    public void Start()
    {
        StartDialogue(dialogues[0]);
    }

    public void StartDialogue(Dialogue dialogue)
    {
        dialogueStarted = true;
        DialogueManager.Instance.StartDialogue(dialogue);
    }

    public void ContinueDialogue()
    {
        DialogueManager.Instance.DisplayNextSentence();
    }
}
