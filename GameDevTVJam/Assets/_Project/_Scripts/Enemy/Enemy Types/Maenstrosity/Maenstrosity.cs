using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Maenstrosity : Enemy
{
    [SerializeField] private SceneField endGameScene;
    protected override void Awake()
    {
        base.Awake();
        stateMachine.Initialize(states["Idle"]);
    }

    public override void Die()
    {
        SceneSwapManager.Instance.FadeOutAndChangeScene(endGameScene);
        base.Die();
    }
}
