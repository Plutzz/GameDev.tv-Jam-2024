using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

[CreateAssetMenu(menuName = "Enemy States/Attack/Swipe")]
public class EnemyAttackSwipe : EnemyStateSOBase
{
    [SerializeField] private float attackChargeTime = 1f;
    private float timer;

    public override void DoEnterLogic()
    {
        base.DoEnterLogic();

        timer = attackChargeTime;
    }

    public override void DoUpdateState()
    {
        base.DoUpdateState();

        timer -= Time.deltaTime;
        Debug.Log("attack charging");

        if(timer < 0f)
        {
            Debug.Log("attacking");
            //play swing animation
            stateMachine.ChangeState(enemy.IdleState);
        }
    }

    public override void DoExitLogic()
    {
        base.DoExitLogic();
    }
}
