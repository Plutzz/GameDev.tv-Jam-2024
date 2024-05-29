using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "IdleState-Ben", menuName = "PlayerStates/IdleState")]
public class PlayerIdle : PlayerState
{
    public override void DoEnterLogic()
    {
        base.DoEnterLogic();
        animator.Play("PlayerIdle");
        rb.velocity = Vector2.zero;
    }


    public override void CheckTransitions()
    {
        base.CheckTransitions();
        if (inputManager.MoveInput != 0 && core.stateMachine.currentState != core.states["Attack"])
        {
            core.stateMachine.ChangeState(core.states["Move"]);
        }
    }
}
