using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Reacher : Enemy
{
    protected override void Awake()
    {
        base.Awake();
        stateMachine.Initialize(states["Patrol"]);

    }
}
