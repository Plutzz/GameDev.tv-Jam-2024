using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Enemy States/General/Attack")]
public class EnemyAttack : EnemyState
{
    [SerializeField] private float windupTime;

    public override void DoEnterLogic()
    {
        base.DoEnterLogic();
        rb.velocity = Vector3.zero;
        stateMachine.Initialize(states["Windup"]);
    }

    public override void DoUpdateState()
    {
        base.DoUpdateState();

        if(stateUptime > windupTime && currentState == states["Windup"]) 
        {
            stateMachine.ChangeState(states["Tongue Whip"]);
        }

    }


}
