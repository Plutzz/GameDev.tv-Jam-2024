using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Enemy States/General/Attack")]
public class EnemyAttack : EnemyState
{
    [SerializeField] private float windupTime;
    [SerializeField] private float dropAggroTime = 3f;
    private float dropAggroTimer;

    public override void DoEnterLogic()
    {
        base.DoEnterLogic();
        rb.velocity = Vector3.zero;
        stateMachine.Initialize(states["Windup"]);
        dropAggroTimer = dropAggroTime;
    }

    public override void DoUpdateState()
    {
        base.DoUpdateState();

        if(!enemy.IsAggroed)
        {
            dropAggroTimer -= Time.deltaTime;
        }
        else
        {
            dropAggroTimer = dropAggroTime;
        }

        if(dropAggroTimer <= 0f)
        {
            core.stateMachine.ChangeState(core.states["Patrol"]);
            return;
        }


        if(stateUptime > windupTime && currentState == states["Windup"]) 
        {
            stateMachine.ChangeState(states["Tongue Whip"]);
        }

    }

}
