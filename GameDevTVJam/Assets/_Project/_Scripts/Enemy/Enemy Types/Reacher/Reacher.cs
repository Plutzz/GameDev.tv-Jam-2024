using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Reacher : Enemy
{
    public Collider2D tongueHitbox;
    protected override void Awake()
    {
        base.Awake();
        stateMachine.Initialize(states["Patrol"]);

    }
}
