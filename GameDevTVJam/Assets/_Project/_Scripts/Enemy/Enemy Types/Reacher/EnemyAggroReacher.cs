using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

[CreateAssetMenu(menuName = "Enemy States/Reacher/Aggro")]
public class EnemyAggroReacher : EnemyState
{
    [SerializeField] private float detectedTime = 0.66f;
    [SerializeField] private float dropAggroTime = 3f;
    private float dropAggroTimer;
    public override void DoEnterLogic()
    {
        base.DoEnterLogic();
        if(core.stateMachine.previousState == core.states["Attack"])
        {
            stateMachine.Initialize(states["Run"]);
        }
        else
        {
            stateMachine.Initialize(states["Detected"]);
        }
        
        dropAggroTimer = dropAggroTime;
    }


    public override void DoUpdateState()
    {
        base.DoUpdateState();

        if (stateUptime < detectedTime) return;


        if (!enemy.IsAggroed)
        {
            dropAggroTimer -= Time.deltaTime;
        }
        else
        {
            dropAggroTimer = dropAggroTime;
        }

        if (dropAggroTimer <= 0f)
        {
            core.stateMachine.ChangeState(core.states["Patrol"]);
            return;
        }

        if (currentState == states["Detected"])
        {
            stateMachine.ChangeState(states["Run"]);
            return;
        }

        if (enemy.IsWithinStrikingDistance && currentState != states["Detected"])
        {
            core.stateMachine.ChangeState(core.states["Attack"]);
            return;
        }


    }
}
