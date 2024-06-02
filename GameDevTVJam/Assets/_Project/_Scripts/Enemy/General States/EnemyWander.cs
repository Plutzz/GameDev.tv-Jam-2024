using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using UnityEngine;

[CreateAssetMenu(menuName = "Enemy States/General States/Wander")]
public class EnemyWander : EnemyState
{
    [SerializeField] private float maxWanderDistance;
    [SerializeField] private float walkSpeed = 10f;
    private float startingXPos;
    private float randomXPos;
    private float direction;
    public override void DoEnterLogic()
    {
        base.DoEnterLogic();
        startingXPos = enemy.transform.position.x;
        core.CheckSpriteDirection();
        randomXPos = Random.Range(-maxWanderDistance, maxWanderDistance);
        direction = randomXPos - enemy.transform.position.x;
        rb.velocity = Vector3.right * walkSpeed * Mathf.Sign(direction);

        // Animation clip
        if (animator != null && stateAnimation != null)
            animator.Play(stateAnimation.name);
    }


    public override void DoUpdateState()
    {
        base.DoUpdateState();

        if (enemy.knockbackTimer < 0)
        {
            rb.velocity = Vector3.right * walkSpeed * Mathf.Sign(direction);
        }

        if(enemy.transform.position.x >= startingXPos + maxWanderDistance || enemy.transform.position.x <= startingXPos - maxWanderDistance)
        {
            parent.stateMachine.ChangeState(parent.states["Idle"]);
        }
    }
}
