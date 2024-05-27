using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class EnemyIdleSOBase : PlayerStateSOBase
{
    protected EnemyStateMachine stateMachine;
    protected Rigidbody2D rb;
    protected GameObject gameObject;

    public virtual void Initialize(GameObject gameObject, EnemyStateMachine stateMachine)
    {
        this.gameObject = gameObject;
        this.stateMachine = stateMachine;
        rb = stateMachine.rb;
    }
    public override void CheckTransitions()
    {
    }


}