using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovingSOBase : PlayerStateSOBase
{
    protected PlayerStateMachine stateMachine;
    protected Rigidbody2D rb;
    protected GameObject gameObject;

    public virtual void Initialize(GameObject gameObject, PlayerStateMachine stateMachine)
    {
        this.gameObject = gameObject;
        this.stateMachine = stateMachine;
        rb = stateMachine.rb;

    }

    public override void CheckTransitions()
    {
        // Moving => Idle
        if (stateMachine.inputManager.MoveInput == 0)
        {
            stateMachine.ChangeState(stateMachine.IdleState);
        }
    }
}