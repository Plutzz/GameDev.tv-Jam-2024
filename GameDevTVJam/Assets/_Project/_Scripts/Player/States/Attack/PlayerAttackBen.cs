using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "AttackState-Ben", menuName = "PlayerStates/AttackStates/Ben")]
public class PlayerAttackBen : PlayerAttackSOBase
{
    [SerializeField] private float attackTime = 1f;
    [SerializeField] private float attackMoveAmount = 0.5f;
    [SerializeField] private float groundDrag = 2f;
    private float timer;
    public override void DoEnterLogic()
    {
        stateMachine.playerAttacks.AttackPoint.SetActive(true);
        base.DoEnterLogic();
        timer = attackTime;
        //stateMachine.GetComponentInChildren<Animator>().Play("Attack");
        rb.drag = groundDrag;
        rb.velocity = Vector2.zero;
        rb.AddForce(Vector2.right * attackMoveAmount * stateMachine.pivot.localScale.x, ForceMode2D.Impulse);
    }

    public override void DoExitLogic()
    {
        base.DoExitLogic();
        stateMachine.playerAttacks.AttackPoint.SetActive(false);
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
