using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(menuName = "Enemy States/Reacher/Tongue Whip")]
public class EnemyTongueWhipReacher : EnemyState
{
    public override void DoEnterLogic()
    {
        base.DoEnterLogic();
        rb.velocity = Vector3.zero;
        if (animator != null && stateAnimation != null)
            animator.Play(stateAnimation.name);
    }


    public override void DoUpdateState()
    {
        base.DoUpdateState();
        if (stateUptime > 2f)
            core.stateMachine.ChangeState(core.states["Patrol"]);
    }
}
