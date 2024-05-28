using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "IdleState-Ben", menuName = "PlayerStates/IdleState")]
public class PlayerIdle : PlayerStateSOBase
{
    public override void DoEnterLogic()
    {
        base.DoEnterLogic();
        player.GetComponentInChildren<Animator>().Play("PlayerIdle");
        rb.velocity = Vector2.zero;
    }


    public override void CheckTransitions()
    {
        base.CheckTransitions();
        if (player.inputManager.MoveInput != 0 && stateMachine.currentState != player.AttackState)
        {
            stateMachine.ChangeState(player.MovingState);
        }
    }
}
