using System.Collections;
using System.Collections.Generic;
using UnityEngine;



[CreateAssetMenu(menuName = "Enemy States/Chase/Reacher")]
public class EnemyChaseReacher : EnemyState
{
    [SerializeField] private float xVelocity = 2f;
    [SerializeField] private float windupTime = 2f;
    [SerializeField] private float jumpTime = 2f;
    [SerializeField] private float jumpXVelocity = 5f;
    [SerializeField] private float jumpYVelocity = 5f;
    [SerializeField] private float jumpDrag = 10f;
    [SerializeField] private float spacingBetweenPlayer = 6f;
    private bool jumpReady;
    private float timer;
    private int jumpDirection;

    public override void DoEnterLogic()
    {
        base.DoEnterLogic();
        //jumpReady = false;
        timer = windupTime;
        rb.drag = 0f;
        jumpDirection = 1;

        // If player is to the left, flip charge direction
        if (enemy.player.transform.position.x < core.transform.position.x)
        {
            jumpDirection = -1;
        }
    }

    public override void DoUpdateState()
    {
        base.DoUpdateState();

        if (Mathf.Abs(enemy.player.transform.position.x - enemy.transform.position.x) < spacingBetweenPlayer && !jumpReady)
        {
            rb.velocity = -jumpDirection * new Vector2(xVelocity, 0f);
        } else if (Mathf.Abs(enemy.player.transform.position.x - enemy.transform.position.x) >= spacingBetweenPlayer && !jumpReady)
        {
            rb.velocity = Vector2.zero;
        }

        timer -= Time.deltaTime;

        if (timer < 0f && !jumpReady)
        {
            jumpReady = true;
            timer = jumpTime;
            Jump();
        }
        else if (timer < 0f && jumpReady)
        {
            core.stateMachine.ChangeState(core.states["Idle"]);
        }

    }

    private void Jump()
    {
        rb.drag = jumpDrag;

        rb.AddForce(new Vector2(jumpXVelocity * jumpDirection, jumpYVelocity), ForceMode2D.Impulse);

        if(rb.velocity.x > 0 && !isFacingRight)
        {
            core.FlipSprite();
        }
        else if(rb.velocity.x < 0 && isFacingRight) 
        {
            core.FlipSprite();
        }
    }

    public override void DoExitLogic()
    {
        base.DoExitLogic();
        jumpReady = false;
    }
}
