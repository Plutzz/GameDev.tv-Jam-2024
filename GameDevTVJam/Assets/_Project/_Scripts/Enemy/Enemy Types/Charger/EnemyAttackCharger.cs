using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Enemy States/Charger/Aggro")]
public class EnemyAttackCharger : EnemyState
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

        if (stateUptime >= detectedTime && currentState == states["Detected"])
        {
            core.stateMachine.ChangeState(core.states["Attack"]);
        }
    }
}
