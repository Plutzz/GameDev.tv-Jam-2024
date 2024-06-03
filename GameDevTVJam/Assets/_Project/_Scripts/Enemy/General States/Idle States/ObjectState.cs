using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Enemy will be stationary in idle state for x amount of seconds
// After which, the enemy will go into chase state or attack state depending on the distance to the player

[CreateAssetMenu(menuName = "Object/Idle")]
public class ObjectState : EnemyState
{
    public override void DoEnterLogic()
    {
        base.DoEnterLogic();
        if (animator != null && stateAnimation != null)
            animator.Play(stateAnimation.name);
        rb.velocity = Vector2.zero;
    }
}