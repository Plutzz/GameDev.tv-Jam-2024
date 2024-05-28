using System.Collections;
using System.Collections.Generic;
using UnityEngine;



[CreateAssetMenu(menuName = "Enemy States/Chase/Reacher")]
public class EnemyChaseReacher : EnemyChaseSOBase
{
    [SerializeField] private float windupTime = 2f;
    [SerializeField] private float jumpTime = 2f;
    [SerializeField] private float chargeVelocity = 10f;
    [SerializeField] private float chargeDrag = 10f;
    private bool chargeReady;
    private float timer;
    private int chargeDirection;

    public override void DoEnterLogic()
    {
        base.DoEnterLogic();
        timer = windupTime;
        rb.drag = 100f;
        chargeDirection = 1;

        // If player is to the left, flip charge direction
        if (enemy.player.transform.position.x < enemy.transform.position.x)
        {
            chargeDirection = -1;
        }
    }

    public override void DoUpdateState()
    {
        base.DoUpdateState();
        timer -= Time.deltaTime;

        if (timer < 0f && !chargeReady)
        {
            chargeReady = true;
            timer = chargeTime;
            Charge();
        }
        else if (timer < 0f && chargeReady)
        {
            stateMachine.ChangeState(enemy.IdleState);
        }

    }

    private void Charge()
    {
        rb.drag = chargeDrag;

        rb.AddForce(new Vector2(chargeVelocity * chargeDirection, 0), ForceMode2D.Impulse);

        enemy.CheckForLeftOrRightFacing(rb.velocity);
    }

    public override void DoExitLogic()
    {
        base.DoExitLogic();
        chargeReady = false;
    }
}
