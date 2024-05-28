using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Enemy will be stationary in idle state for x amount of seconds
// After which, the enemy will go into chase state or attack state depending on the distance to the player

[CreateAssetMenu(menuName = "Enemy States/Idle/Stationary")]
public class EnemyIdleStationary : EnemyIdleSOBase
{
    [SerializeField] private float maxIdleTime = 2f;
    private float idleTimer;
    public override void DoEnterLogic()
    {
        base.DoEnterLogic();
        Debug.Log("EnemyIdle");
        idleTimer = maxIdleTime;
        rb.velocity = Vector2.zero;
    }

    public override void DoUpdateState()
    {
        Debug.Log("Update Enemy");
        base.DoUpdateState();
        idleTimer -= Time.deltaTime;
        if (idleTimer < 0)
        {
            if (enemy.IsWithinStrikingDistance)
            {
                stateMachine.ChangeState(enemy.AttackState);
            }
            else if (enemy.IsAggroed)
            {
                stateMachine.ChangeState(enemy.ChaseState);
            }
        }
    }

}
