using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class CutsceneManager : Singleton<CutsceneManager>
{
    [SerializeField] private Cutscene initialCutscene;
    private Cutscene currentCutscene;

    private void Start()
    {
        if(initialCutscene != null)
        {
            StartCutscene(initialCutscene);
        }
    }
    public void StartCutscene(Cutscene cutscene)
    {
        Debug.Log("Starting cutscene" + cutscene.name);
        currentCutscene = cutscene;
        currentCutscene.timeline.stopped += OnEndCutscene;
        InputManager.Instance.SwitchActionMap("Cutscene");
        currentCutscene.gameObject.SetActive(true);
    }

    private void OnEndCutscene(PlayableDirector timeline)
    {
        InputManager.Instance.SwitchActionMap("Player");
        currentCutscene.actionOnComplete?.Invoke();
        timeline.stopped -= OnEndCutscene;
    }


}
