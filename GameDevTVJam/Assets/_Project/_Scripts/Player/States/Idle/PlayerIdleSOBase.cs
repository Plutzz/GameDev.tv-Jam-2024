using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerIdleSOBase : PlayerStateSOBase
{
    protected PlayerStateMachine stateMachine;
    protected Rigidbody rb;
    protected GameObject gameObject;

    public virtual void Initialize(GameObject gameObject, PlayerStateMachine stateMachine)
    {
        this.gameObject = gameObject;
        this.stateMachine = stateMachine;
        rb = stateMachine.rb;
    }
    public override void CheckTransitions()
    {
        if (stateMachine.inputManager.MoveInput != Vector2.zero)
        {
            stateMachine.ChangeState(stateMachine.MovingState);
        }
    }


}