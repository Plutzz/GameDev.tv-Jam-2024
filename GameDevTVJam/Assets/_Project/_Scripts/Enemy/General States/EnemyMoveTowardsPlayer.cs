using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Enemy States/General States/Move Towards Player")]
public class EnemyMoveTowardsPlayer : EnemyState
{
    [SerializeField] private float chaseSpeed = 8f;
    [SerializeField] private float animationSpeed = 0.5f;

    public override void DoEnterLogic()
    {
        base.DoEnterLogic();

        // Animation clip
        if (animator != null && stateAnimation != null)
            animator.Play(stateAnimation.name);
    }

    public override void DoUpdateState()
    {
        base.DoUpdateState();
        Debug.Log("running");
        float direction = enemy.player.transform.position.x - enemy.transform.position.x;
        rb.velocity = Vector3.right * chaseSpeed * Mathf.Sign(direction);
        enemy.CheckSpriteDirection();
        animator.speed = animationSpeed;
    }
}
