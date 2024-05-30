using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices.WindowsRuntime;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

// This script manages ALL dialog in this scene

public class DialogueManager : Singleton<DialogueManager>
{
    private Dialogue currentDialogue;

    [SerializeField] private GameObject dialogueBox;
    [SerializeField] private TextMeshProUGUI nameText;
    [SerializeField] private TextMeshProUGUI dialogueText;
    [SerializeField] private Image characterImage;
    private InputManager inputManager;

    private DialogueSequence currentSequence;
    private int currentSequenceIndex;


    [SerializeField] private float textDelay;
    private Queue<string> sentences;

    protected override void Awake()
    {
        base.Awake();
        sentences = new Queue<string>();

    }


    private void OnEnable()
    {
        inputManager = InputManager.Instance;
    }

    private void Update()
    {
        if(inputManager != null && inputManager.NextDialoguePressedThisFrame)
        {
            DisplayNextSentence();
        }
    }

    public void StartDialogueSequence(DialogueSequence sequence)
    {
        currentSequenceIndex = 0;
        currentSequence = sequence;
        StartDialogue(sequence.dialogues[currentSequenceIndex]);
    }

    private void NextDialogueInSequence()
    {
        currentSequenceIndex++;
        if(currentSequenceIndex < currentSequence.dialogues.Count)
        {
            StartDialogue(currentSequence.dialogues[currentSequenceIndex]);
        }
        else
        {
            EndDialogueSequence();
        }
    }

    public void StartDialogue(Dialogue dialogue)
    {
        InputManager.Instance.playerInput.SwitchCurrentActionMap("Cutscene");

        currentDialogue = dialogue;

        dialogueBox.SetActive(true);
        

        if(nameText != null )
            nameText.text = dialogue.name;

        if (characterImage != null)
        {
            if(dialogue.characterSprite == null)
            {
                characterImage.enabled = false;
            }

            else
            {
                characterImage.enabled = true;
                characterImage.sprite = dialogue.characterSprite;
            }
            
        }
            

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
        currentDialogue?.actionOnComplete.Invoke();
        currentDialogue = null;

        if (currentSequence != null)
        {
            NextDialogueInSequence();
        }
        else
        {
            Debug.Log("End of Dialogue");
            InputManager.Instance.playerInput.SwitchCurrentActionMap("Player");
            dialogueBox.SetActive(false);
        }
    }

    private void EndDialogueSequence()
    {
        Debug.Log("End of Dialogue Sequence");
        InputManager.Instance.playerInput.SwitchCurrentActionMap("Player");
        dialogueBox.SetActive(false);
    }
}