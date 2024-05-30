using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Charger : Enemy
{
    protected override void Awake()
    {
        base.Awake();
        stateMachine.Initialize(states["Patrol"]);
    }
}
