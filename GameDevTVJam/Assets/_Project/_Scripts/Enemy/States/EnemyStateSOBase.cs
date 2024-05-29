using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Base class that all enemy state scriptable objects inherit from.
/// </summary>
public class EnemyStateSOBase : State
{

    protected StateMachine stateMachine;
    protected GameObject gameObject;
    protected Enemy enemy;
    [SerializeField] protected AnimationClip stateAnimationClip;

    /// <summary>
    /// Initialize paramaters that are commonly used in states
    /// </summary>
    /// <param name="gameObject"></param>
    /// <param name="stateMachine"></param>
    /// <param name="enemy"></param>
    public virtual void Initialize(GameObject gameObject, StateMachine stateMachine, Enemy enemy)
    {
        this.gameObject = gameObject;
        this.stateMachine = stateMachine;
        this.enemy = enemy;
    }
}