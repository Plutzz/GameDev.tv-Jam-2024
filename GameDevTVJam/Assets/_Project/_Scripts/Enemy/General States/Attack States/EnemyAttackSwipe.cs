using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

[CreateAssetMenu(menuName = "Enemy States/Attack/Swipe")]
public class EnemyAttackSwipe : EnemyState
{
    [SerializeField] private float attackChargeTime = 1f;
    private float timer;

    public override void DoEnterLogic()
    {
        base.DoEnterLogic();

        timer = attackChargeTime;
        rb.velocity = Vector3.zero;
    }

    public override void DoUpdateState()
    {
        base.DoUpdateState();
        rb.velocity = Vector3.zero;
        timer -= Time.deltaTime;

        if(timer < 0f)
        {
            //play swing animation
            //core.stateMachine.ChangeState(core.states["Idle"]);
            core.stateMachine.ChangeState(core.states["Patrol"]);
        }
    }

    public override void DoExitLogic()
    {
        base.DoExitLogic();
    }
}
