using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Enemy States/Chase/Charger")]
public class EnemyChaseCharger : EnemyChaseSOBase
{
    [SerializeField] private float windupTime = 2f;
    [SerializeField] private float chargeTime = 2f;
    [SerializeField] private float chargeVelocity = 10f;
    [SerializeField] private float chargeDrag = 10f;
    private bool chargeReady;
    private float timer;


    public override void DoEnterLogic()
    {
        base.DoEnterLogic();
        timer = windupTime;
        rb.drag = 100f;
    }

    public override void DoUpdateState()
    {
        base.DoUpdateState();
        timer -= Time.deltaTime;

        if(timer < 0f && !chargeReady)
        {
            chargeReady = true;
            timer = chargeTime;
            Charge();
        }
        else if(timer < 0f && chargeReady)
        {
            stateMachine.ChangeState(enemy.IdleState);
        }

    }

    private void Charge()
    {
        rb.drag = chargeDrag;
        int chargeDirection = 1;

        // If player is to the left, flip charge direction
        if(enemy.player.transform.position.x < enemy.transform.position.x)
        {
            chargeDirection = -1;
        }

        rb.AddForce(new Vector2(chargeVelocity * chargeDirection, 0), ForceMode2D.Impulse);
    }

    public override void DoExitLogic()
    {
        base.DoExitLogic();
        chargeReady = false;
    }
}
