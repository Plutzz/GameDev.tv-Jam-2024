using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Enemy States/Maenstrosity/Attacks/Melee")]
public class MaenstrosityMelee : EnemyState
{
    [SerializeField] private AnimationClip attackAnimation;
    [SerializeField] private float windupTime;
    private bool hasAttacked;

    

    public override void DoEnterLogic()
    {
        base.DoEnterLogic();
        rb.velocity = Vector3.zero;
        animator.Play(stateAnimation.name);
        hasAttacked = false;
        if ((enemy.player.transform.position.x < enemy.transform.position.x && isFacingRight) ||
   enemy.player.transform.position.x > enemy.transform.position.x && !isFacingRight)
        {
            enemy.FlipSprite();
        }
    }

    public override void DoUpdateState()
    {
        base.DoUpdateState();

        if (stateUptime > windupTime && !hasAttacked)
        {
            animator.Play(attackAnimation.name);
            hasAttacked = true;
        }


        if(hasAttacked && animator.GetCurrentAnimatorStateInfo(0).normalizedTime > 0.95f)
        {
            core.stateMachine.ChangeState(core.states["Idle"]);
        }

    }
}
