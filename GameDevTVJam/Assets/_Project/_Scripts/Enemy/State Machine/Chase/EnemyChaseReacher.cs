using System.Collections;
using System.Collections.Generic;
using UnityEngine;



[CreateAssetMenu(menuName = "Enemy States/Chase/Reacher")]
public class EnemyChaseReacher : EnemyChaseSOBase
{
    [SerializeField] private float windupTime = 2f;
    [SerializeField] private float jumpTime = 2f;
    [SerializeField] private float jumpXVelocity = 5f;
    [SerializeField] private float jumpYVelocity = 5f;
    [SerializeField] private float jumpDrag = 10f;
    private bool jumpReady;
    private float timer;
    private int jumpDirection;

    public override void DoEnterLogic()
    {
        base.DoEnterLogic();
        timer = windupTime;
        rb.drag = 100f;
        jumpDirection = 1;

        // If player is to the left, flip charge direction
        if (enemy.player.transform.position.x < enemy.transform.position.x)
        {
            jumpDirection = -1;
        }
    }

    public override void DoUpdateState()
    {
        base.DoUpdateState();
        timer -= Time.deltaTime;

        if (timer < 0f && !jumpReady)
        {
            jumpReady = true;
            timer = jumpTime;
            Jump();
        }
        else if (timer < 0f && jumpReady)
        {
            stateMachine.ChangeState(enemy.IdleState);
        }

    }

    private void Jump()
    {
        rb.drag = jumpDrag;

        rb.AddForce(new Vector2(jumpXVelocity * jumpDirection, jumpYVelocity), ForceMode2D.Impulse);

        enemy.CheckForLeftOrRightFacing(rb.velocity);
    }

    public override void DoExitLogic()
    {
        base.DoExitLogic();
        jumpReady = false;
    }
}
