using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Enemy will be stationary in idle state for x amount of seconds
// After which, the enemy will go into chase state or attack state depending on the distance to the player

[CreateAssetMenu(menuName = "Enemy States/General States/Idle")]
public class EnemyIdleStationary : EnemyState
{
    
    [SerializeField] private float maxIdleTime = 2f;
    private float idleTimer;
    public override void DoEnterLogic()
    {
        base.DoEnterLogic();
        if(animator != null && stateAnimation != null)
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
            if (enemy.IsWithinStrikingDistance)
            {
                core.stateMachine.ChangeState(core.states["Attack"]);
            }
            else if (enemy.IsAggroed)
            {
                core.stateMachine.ChangeState(core.states["Chase"]);
            }
        }
    }

}

