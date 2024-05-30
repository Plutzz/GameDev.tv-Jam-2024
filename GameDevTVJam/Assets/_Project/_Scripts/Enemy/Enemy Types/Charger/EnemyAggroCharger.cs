using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Enemy States/Charger/Aggro")]
public class EnemyAggroCharger : EnemyState
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
            core.stateMachine.ChangeState(states["Attack"]);
            return;
        }

    }
}
