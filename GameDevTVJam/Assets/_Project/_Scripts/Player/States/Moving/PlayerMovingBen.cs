using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "MovingState-Ben", menuName = "PlayerStates/MovingState")]
public class PlayerMovingBen : PlayerMovingSOBase
{

    [SerializeField] private float speed = 1f;

    public override void DoEnterLogic()
    {
        base.DoEnterLogic();
        stateMachine.GetComponentInChildren<Animator>().Play("PlayerWalk");
    }
    public override void DoUpdateState()
    {
        base.DoUpdateState();
        rb.velocity = Vector2.right * stateMachine.inputManager.MoveInput * speed;

        if(stateMachine.inputManager.MoveInput > 0)
        {
            stateMachine.pivot.localScale = Vector2.one;
        }
        else if(stateMachine.inputManager.MoveInput < 0)
        {
            stateMachine.pivot.localScale = new Vector3(-1, 1, 1);
        }

    }
}
