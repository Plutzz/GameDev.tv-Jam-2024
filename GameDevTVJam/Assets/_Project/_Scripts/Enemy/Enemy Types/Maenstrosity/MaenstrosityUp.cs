using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Enemy States/Maenstrosity/Up")]
public class MaenstrosityUp : EnemyState
{
    [SerializeField] private float moveUpVelocity;
    [SerializeField] private bool IsUp = true;

    public override void DoEnterLogic()
    {
        base.DoEnterLogic();
        rb.gravityScale = 0f;
        rb.velocity = Vector2.zero;
        animator.Play(stateAnimation.name);
        enemy.knockbackEnabled = false;
    }

    public override void DoUpdateState()
    {
        base.DoUpdateState();

        if (animator.GetCurrentAnimatorStateInfo(0).normalizedTime > 0.5f)
        {
            if(IsUp)
            {
                rb.velocity = new Vector3(0, moveUpVelocity, 0);
            }
            else
            {
                rb.velocity = new Vector3(0, -moveUpVelocity, 0);
            }
            
        }

        if(animator.GetCurrentAnimatorStateInfo(0).normalizedTime > 0.95f && IsUp)
        {
            parent.stateMachine.ChangeState(parent.states["Hover"]);
        }
        else if (animator.GetCurrentAnimatorStateInfo(0).normalizedTime > 0.95f && !IsUp)
        {
            core.stateMachine.ChangeState(core.states["Attack"]);
            enemy.knockbackEnabled = true;
        }
    }
}
