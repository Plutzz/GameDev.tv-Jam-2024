using DG.Tweening;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;


public class CutsceneManager : Singleton<CutsceneManager>
{
    [SerializeField] private Cutscene initialCutscene;
    private Cutscene currentCutscene;

    [SerializeField] private RectTransform topCinematicBar;
    [SerializeField] private RectTransform bottomCinematicBar;
    [SerializeField] private Ease ease;
    [SerializeField] private float barAnimationTime = 1f;

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
        currentCutscene.actionOnStart?.Invoke();
        InputManager.Instance.SwitchActionMap("Cutscene");
        currentCutscene.gameObject.SetActive(true);
    }

    private void OnEndCutscene(PlayableDirector timeline)
    {
        InputManager.Instance.SwitchActionMap("Player");
        currentCutscene.actionOnComplete?.Invoke();
        timeline.stopped -= OnEndCutscene;
    }

    public void ActivateCinematicBars()
    {
        topCinematicBar.transform.DOLocalMoveY(topCinematicBar.localPosition.y - topCinematicBar.sizeDelta.y, barAnimationTime).SetEase(ease);
        bottomCinematicBar.transform.DOLocalMoveY(bottomCinematicBar.localPosition.y + bottomCinematicBar.sizeDelta.y, barAnimationTime).SetEase(ease);
    }

    public void DeactivateCinematicBars()
    {
        topCinematicBar.DOLocalMoveY(topCinematicBar.localPosition.y + topCinematicBar.sizeDelta.y, barAnimationTime).SetEase(ease);
        bottomCinematicBar.DOLocalMoveY(bottomCinematicBar.localPosition.y - bottomCinematicBar.sizeDelta.y, barAnimationTime).SetEase(ease);
    }



}
