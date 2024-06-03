using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Enemy States/Maenstrosity/Idle")]
public class MaenstrosityIdle : EnemyState
{
    [SerializeField] private float maxIdleTime = 2f;
    private float idleTimer;
    public override void DoEnterLogic()
    {
        base.DoEnterLogic();
        if (animator != null && stateAnimation != null)
            animator.Play(stateAnimation.name);
        idleTimer = maxIdleTime;
        rb.velocity = Vector2.zero;
    }

    public override void DoUpdateState()
    {
        base.DoUpdateState();
        idleTimer -= Time.deltaTime;

        if (idleTimer < 0)
        {
            core.stateMachine.ChangeState(core.states["Move"]);
        }
    }
}
