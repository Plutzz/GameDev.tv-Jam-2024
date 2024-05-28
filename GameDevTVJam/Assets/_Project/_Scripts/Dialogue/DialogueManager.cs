using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices.WindowsRuntime;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

// This script manages ALL dialog in this scene

public class DialogueManager : Singleton<DialogueManager>
{
    private TextMeshProUGUI nameText;
    private TextMeshProUGUI dialogueText;

    [SerializeField] private float textDelay;
    private Queue<string> sentences;

    protected override void Awake()
    {
        base.Awake();
        sentences = new Queue<string>();
    }

    public void StartDialogue(Dialogue dialogue)
    {

        nameText = dialogue.nameText;
        dialogueText = dialogue.dialogueText;

        if(nameText != null )
            nameText.text = dialogue.name;



        sentences.Clear();

        foreach (string sentence in dialogue.sentences)
        {
            sentences.Enqueue(sentence);
        }

        DisplayNextSentence();

    }

    public void DisplayNextSentence()
    {
        if (sentences.Count == 0)
        {
            EndDialogue();
            return;
        }

        string sentence = sentences.Dequeue();
        StopAllCoroutines();
        StartCoroutine(TypeSentence(sentence));
    }

    IEnumerator TypeSentence(string sentence)
    {
        dialogueText.text = "";
        foreach (char letter in sentence.ToCharArray())
        {
            dialogueText.text += letter;
            yield return new WaitForSeconds(textDelay);
        }
    }

    public void EndDialogue()
    {
        Debug.Log("End of Dialogue");
    }
}