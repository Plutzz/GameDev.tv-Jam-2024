using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Enemy States/Charger/Charge")]
public class EnemyChargeCharger : EnemyState
{
    [SerializeField] private float chargeTime = 2f;
    [SerializeField] private float chargeVelocity = 10f;
    [SerializeField] private float chargeDrag = 10f;
    private int chargeDirection;


    public override void DoEnterLogic()
    {
        base.DoEnterLogic();
        rb.drag = 100f;
        chargeDirection = 1;

        // If player is to the left, flip charge direction
        if (enemy.player.transform.position.x < enemy.transform.position.x)
        {
            chargeDirection = -1;
        }

        Charge();

    }


    public override void DoExitLogic()
    {
        base.DoExitLogic();
        rb.drag = 0f;
    }

    public override void DoUpdateState()
    {
        base.DoUpdateState();

        if(stateUptime > chargeTime)
        {
            core.stateMachine.ChangeState(core.states["Patrol"]);
            return;
        }

    }

    private void Charge()
    {
        rb.drag = chargeDrag;

        rb.AddForce(new Vector2(chargeVelocity * chargeDirection, 0), ForceMode2D.Impulse);

        if (rb.velocity.x > 0 && !isFacingRight)
        {
            core.FlipSprite();
        }
        else if (rb.velocity.x < 0 && isFacingRight)
        {
            core.FlipSprite();
        }
    }
}
