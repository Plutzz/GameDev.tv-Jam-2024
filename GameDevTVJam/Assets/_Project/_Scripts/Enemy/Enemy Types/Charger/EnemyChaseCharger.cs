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
    private float chargeDirection;

    public override void DoEnterLogic()
    {
        base.DoEnterLogic();
        rb.drag = 100f;

        chargeDirection = 1f;

        if(enemy.transform.localRotation.y == 0f)
        {
            chargeDirection = -1f;
        }

        Charge();

        if (animator != null && stateAnimation != null)
            animator.Play(stateAnimation.name);
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
            //parent.stateMachine.ChangeState(parent.states["Windup"]);
            core.stateMachine.ChangeState(core.states["Attack"]);
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
