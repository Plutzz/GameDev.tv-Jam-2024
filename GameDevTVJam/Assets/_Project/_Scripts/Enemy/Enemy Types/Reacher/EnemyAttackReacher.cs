using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttackReacher : EnemyState
{
    public override void DoEnterLogic()
    {
        base.DoEnterLogic();

        if (animator != null && stateAnimation != null)
            animator.Play(stateAnimation.name);
    }

    public override void DoUpdateState()
    {
        base.DoUpdateState();
        if(stateUptime >= stateAnimation.length * animator.speed)
        {
            core.stateMachine.ChangeState(core.states["Patrol"]);
        }

    }


}
