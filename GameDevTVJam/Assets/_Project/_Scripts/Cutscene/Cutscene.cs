using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Playables;

[System.Serializable]
public class Cutscene : MonoBehaviour
{
    public PlayableDirector timeline;
    public UnityEvent actionOnStart;
    public UnityEvent actionOnComplete;
    public void StartSelf()
    {
        CutsceneManager.Instance.StartCutscene(this);
    }
}
