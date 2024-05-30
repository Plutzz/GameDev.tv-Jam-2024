using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Enemy stands still and plays a windup animation before an attack
// Exiting this state should be controlled by its parent

[CreateAssetMenu(menuName = "Enemy States/General States/Windup")]
public class EnemyWindupState : EnemyState
{
    public override void DoEnterLogic()
    {
        base.DoEnterLogic();
        rb.velocity = Vector3.zero;
        if (animator != null && stateAnimation != null)
            animator.Play(stateAnimation.name);
    }
}
