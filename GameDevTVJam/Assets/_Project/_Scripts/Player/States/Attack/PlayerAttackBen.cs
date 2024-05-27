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
        
        base.DoEnterLogic();
        timer = attackTime;
        stateMachine.playerAttacks.AttackPoint.SetActive(true);
        if(stateMachine.inputManager.MoveInput > 0)
        {
            stateMachine.pivot.localScale = Vector3.one;
        }
        else if(stateMachine.inputManager.MoveInput < 0)
        {
            stateMachine.pivot.localScale = new Vector3(-1, 1, 1);
        }
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

    private void EnableHitbox()
    {

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
