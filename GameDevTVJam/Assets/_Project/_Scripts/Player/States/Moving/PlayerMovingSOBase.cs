using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovingSOBase : PlayerStateSOBase
{
    protected PlayerStateMachine stateMachine;
    protected Rigidbody rb;
    protected GameObject gameObject;
    protected Vector2 inputVector;

    public virtual void Initialize(GameObject gameObject, PlayerStateMachine stateMachine)
    {
        this.gameObject = gameObject;
        this.stateMachine = stateMachine;
        rb = stateMachine.rb;

    }

    public override void CheckTransitions()
    {
        // Moving => Idle
        if (stateMachine.inputManager.MoveInput == Vector2.zero)
        {
            stateMachine.ChangeState(stateMachine.IdleState);
        }
    }
}