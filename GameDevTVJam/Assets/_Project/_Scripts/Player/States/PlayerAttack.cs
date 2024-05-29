using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "AttackState-Ben", menuName = "PlayerStates/AttackStates/Ben")]
public class PlayerAttack : PlayerState
{
    [SerializeField] private float attackTime = 1f;
    [SerializeField] private float attackMoveAmount = 0.5f;
    [SerializeField] private float groundDrag = 2f;
    private float timer;
    private PlayerAttacks playerAttacks;
    public override void DoEnterLogic()
    {
        base.DoEnterLogic();
        playerAttacks = core.GetComponent<PlayerAttacks>();
        timer = attackTime;
        playerAttacks.AttackPoint.SetActive(true);
        if(inputManager.MoveInput > 0 && !core.isFacingRight)
        {
            core.FlipSprite();
        }
        else if(inputManager.MoveInput < 0 && core.isFacingRight)
        {
            core.FlipSprite();
        }

        rb.drag = groundDrag;
        rb.velocity = Vector2.zero;
        int direction = core.isFacingRight ? 1 : -1;
        rb.AddForce(Vector2.right * attackMoveAmount * direction, ForceMode2D.Impulse);
    }

    public override void DoExitLogic()
    {
        base.DoExitLogic();
        playerAttacks.AttackPoint.SetActive(false);
        rb.drag = 0;
    }

    public override void DoUpdateState()
    {
        base.DoUpdateState();
        //timer -= Time.deltaTime;
        //if(timer < 0f)
        //{
        //    stateMachine.ChangeState(stateMachine.IdleState);
        //}
    }
}
