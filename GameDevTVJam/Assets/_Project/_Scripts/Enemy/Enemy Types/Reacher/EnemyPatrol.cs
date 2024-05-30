using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

[CreateAssetMenu(menuName = "Enemy States/General States/Patrol")]
public class EnemyPatrol : EnemyState
{
    [SerializeField] private float idleTime = 2f;
    [SerializeField] private float minimumPatrolTime = 4f;
    private float timer;


    public override void DoEnterLogic()
    {
        base.DoEnterLogic();
        stateMachine.Initialize(states["Navigate"]);
        timer = idleTime;
    }

    public override void DoUpdateState()
    {
        base.DoUpdateState();
        if(currentState == states["Idle"])
        {
            timer -= Time.deltaTime;
        }

        if(enemy.IsAggroed && stateUptime > minimumPatrolTime)
        {
            core.stateMachine.ChangeState(core.states["Aggro"]);
            return;
        }


        if(timer < 0 && currentState == states["Idle"])
        {
            stateMachine.ChangeState(states["Navigate"]);
            timer = idleTime;
            return;
        }

    }



}
