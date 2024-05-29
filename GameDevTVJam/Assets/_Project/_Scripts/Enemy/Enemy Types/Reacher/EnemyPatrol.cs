using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

[CreateAssetMenu(menuName = "Enemy States/General States/Patrol")]
public class EnemyPatrol : EnemyState
{
    [SerializeField] private float IdleTime = 2f;
    private float timer;


    public override void DoEnterLogic()
    {
        base.DoEnterLogic();
        stateMachine.Initialize(states["Idle"]);
        timer = IdleTime;
    }

    public override void DoUpdateState()
    {
        base.DoUpdateState();
        if(currentState == states["Idle"])
        {
            timer -= Time.deltaTime;
        }

        if(enemy.IsAggroed)
        {
            core.stateMachine.ChangeState(core.states["Chase"]);
            return;
        }
        else if(enemy.IsWithinStrikingDistance)
        {
            core.stateMachine.ChangeState(core.states["Attack"]);
            return;
        }


        if(timer < 0 && currentState == states["Idle"])
        {
            stateMachine.ChangeState(states["Navigate"]);
            timer = IdleTime;
            return;
        }

    }



}
