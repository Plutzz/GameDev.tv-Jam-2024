using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "MovingState-Ben", menuName = "PlayerStates/MovingState")]
public class PlayerMoving : PlayerStateSOBase
{

    [SerializeField] private float speed = 1f;

    public override void DoEnterLogic()
    {
        base.DoEnterLogic();
        player.GetComponentInChildren<Animator>().Play("PlayerWalk");
    }
    public override void DoUpdateState()
    {
        base.DoUpdateState();

        rb.velocity = Vector2.right * player.inputManager.MoveInput * speed;

        if(player.inputManager.MoveInput > 0)
        {
            player.pivot.localScale = Vector2.one;
        }
        else if(player.inputManager.MoveInput < 0)
        {
            player.pivot.localScale = new Vector3(-1, 1, 1);
        }
    }

    public override void CheckTransitions()
    {
        base.CheckTransitions();
        if (player.inputManager.MoveInput == 0 && stateMachine.currentState != player.AttackState)
        {
            stateMachine.ChangeState(player.IdleState);
        }

    }
}
