using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Base class that all enemy state scriptable objects inherit from.
/// </summary>
public class EnemyState : State
{
    protected Enemy enemy;
    public override void SetCore(StateMachineCore _core, State _parent)
    {
        base.SetCore(_core, _parent);
        enemy = core.GetComponent<Enemy>();
    }
}