using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "MovingState-Ben", menuName = "PlayerStates/MovingState")]
public class PlayerMoving : PlayerState
{
    [SerializeField] private float speed = 1f;

    public override void DoEnterLogic()
    {
        base.DoEnterLogic();
        core.animator.Play("PlayerWalk");
    }
    public override void DoUpdateState()
    {
        base.DoUpdateState();

        rb.velocity = Vector2.right * inputManager.MoveInput * speed;


        if(inputManager.MoveInput > 0 && !core.isFacingRight) // Flip Right
        {
            core.FlipSprite();
        }
        else if(inputManager.MoveInput < 0 && core.isFacingRight) // Flip Left
        {
            core.FlipSprite();
        }
    }

    public override void CheckTransitions()
    {
        base.CheckTransitions();
        if (inputManager.MoveInput == 0 && core.stateMachine.currentState != core.states["Attack"])
        {
            core.stateMachine.ChangeState(core.states["Idle"]);
        }

    }
}
