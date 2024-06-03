using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Maenstrosity : Enemy
{
    protected override void Awake()
    {
        base.Awake();
        stateMachine.Initialize(states["Idle"]);
    }
}
