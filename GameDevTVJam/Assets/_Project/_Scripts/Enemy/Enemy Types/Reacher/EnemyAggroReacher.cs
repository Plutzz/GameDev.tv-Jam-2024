using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

[CreateAssetMenu(menuName = "Enemy States/Reacher/Aggro")]
public class EnemyAggroReacher : EnemyState
{
    [SerializeField] private float detectedTime = 0.66f;

    public override void DoEnterLogic()
    {
        base.DoEnterLogic();
        stateMachine.Initialize(states["Detected"]);

    }


    public override void DoUpdateState()
    {
        base.DoUpdateState();

        if (stateUptime < detectedTime) return;

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
