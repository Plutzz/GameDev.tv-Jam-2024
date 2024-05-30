using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class Wiggler : Enemy
{
    protected override void Awake()
    {
        base.Awake();
        stateMachine.Initialize(states["Idle"]);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.CompareTag("Player") && stateMachine.currentState == states["Attack"])
        {
            transform.parent = other.transform;
            stateMachine.ChangeState(states["Latch"]);
        }
    }
}
