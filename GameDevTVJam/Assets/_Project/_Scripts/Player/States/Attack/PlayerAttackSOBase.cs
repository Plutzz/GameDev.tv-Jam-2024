using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerAttackSOBase : PlayerStateSOBase
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


}