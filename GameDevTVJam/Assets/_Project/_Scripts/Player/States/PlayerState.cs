using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Base class that all player state scriptable objects inherit from.
/// </summary>
public class PlayerState : State
{
    protected InputManager inputManager;
    public override void SetCore(StateMachineCore _core)
    {
        base.SetCore(_core);
        inputManager = core.GetComponent<InputManager>();
    }

}