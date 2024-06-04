using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Enemy States/Maenstrosity/Hover")]
public class MaenstrosityHover : EnemyState
{
    [SerializeField] private float moveSpeed = 5f;
    [SerializeField] private float moveTime = 3f;
    public override void DoEnterLogic()
    {
        base.DoEnterLogic();
        rb.velocity = Vector3.zero;
        rb.drag = 0;
        animator.Play(stateAnimation.name);
        enemy.knockbackEnabled = false;
    }

    public override void DoUpdateState()
    {
        base.DoUpdateState();

        float direction;

        if(enemy.player.transform.position.x < enemy.transform.position.x)
        {
            direction = -1;
        }
        else
        {
            direction = 1;
        }

        if ((enemy.player.transform.position.x < enemy.transform.position.x && isFacingRight) ||
enemy.player.transform.position.x > enemy.transform.position.x && !isFacingRight)
        {
            enemy.FlipSprite();
        }


        rb.AddForce(new Vector2(moveSpeed * direction, 0), ForceMode2D.Force);

        if(stateUptime > moveTime)
        {
            parent.stateMachine.ChangeState(parent.states["Down"]);
        }
    }

    public override void DoExitLogic()
    {
        base.DoExitLogic();
        //enemy.knockbackEnabled = true;
    }
}
