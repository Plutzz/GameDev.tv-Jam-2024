using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Enemy States/Chase/Charger")]
public class EnemyChaseCharger : EnemyState
{
    [SerializeField] private float windupTime = 2f;
    [SerializeField] private float chargeTime = 2f;
    [SerializeField] private float chargeVelocity = 10f;
    [SerializeField] private float chargeDrag = 10f;
    private bool jumpReady;
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

        if(timer < 0f && !jumpReady)
        {
            jumpReady = true;
            timer = chargeTime;
            Charge();
        }
        else if(timer < 0f && jumpReady)
        {
            core.stateMachine.ChangeState(core.states["Idle"]);
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

    public override void DoExitLogic()
    {
        base.DoExitLogic();
        jumpReady = false;
    }
}
