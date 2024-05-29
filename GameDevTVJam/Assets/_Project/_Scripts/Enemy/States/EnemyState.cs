using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Base class that all enemy state scriptable objects inherit from.
/// </summary>
public class EnemyState : State
{
    protected Enemy enemy;
    public override void SetCore(StateMachineCore _core)
    {
        base.SetCore(_core);
        enemy = core.GetComponent<Enemy>();
    }
}