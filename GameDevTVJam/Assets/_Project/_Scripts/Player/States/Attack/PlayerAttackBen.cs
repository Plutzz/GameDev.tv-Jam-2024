using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "AttackState-Ben", menuName = "PlayerStates/AttackStates/Ben")]
public class PlayerAttackBen : PlayerAttackSOBase
{
    [SerializeField] private float attackTime = 1f;
    [SerializeField] private float attackMoveAmount = 0.5f;
    private float timer;
    public override void DoEnterLogic()
    {
        base.DoEnterLogic();
        timer = attackTime;
        stateMachine.GetComponentInChildren<Animator>().Play("HeroKnight_Attack1");
        rb.velocity = Vector2.zero;
        rb.AddForce(Vector2.right * attackMoveAmount * stateMachine.graphics.localScale.x, ForceMode2D.Impulse);
    }

    public override void DoUpdateState()
    {
        base.DoUpdateState();
        timer -= Time.deltaTime;
        if(timer < 0f)
        {
            stateMachine.ChangeState(stateMachine.IdleState);
        }
    }
}
