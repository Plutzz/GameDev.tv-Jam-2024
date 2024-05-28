using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Base class that all player state scriptable objects inherit from.
/// </summary>
public class PlayerStateSOBase : StateSOBase
{
    protected StateMachine stateMachine;
    protected Player player;
    protected Rigidbody2D rb;
    protected GameObject gameObject;

    /// <summary>
    /// Initialize paramaters that are commonly used in states
    /// </summary>
    /// <param name="gameObject"></param>
    /// <param name="stateMachine"></param>
    /// <param name="player"></param>
    public void Initialize(GameObject gameObject, StateMachine stateMachine, Player player)
    {
        this.gameObject = gameObject;
        this.stateMachine = stateMachine;
        this.player = player;
        rb = player.rb;
    }
}