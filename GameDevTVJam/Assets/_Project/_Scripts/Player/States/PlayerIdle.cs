using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "IdleState-Ben", menuName = "PlayerStates/IdleState")]
public class PlayerIdle : PlayerStateSOBase
{
    public override void DoEnterLogic()
    {
        base.DoEnterLogic();
        stateMachine.GetComponentInChildren<Animator>().Play("PlayerIdle");
        rb.velocity = Vector2.zero;
    }


    public override void CheckTransitions()
    {
        base.CheckTransitions();
        if (stateMachine.inputManager.MoveInput != 0 && stateMachine.currentState != stateMachine.AttackState)
        {
            stateMachine.ChangeState(stateMachine.MovingState);
        }
    }
}
