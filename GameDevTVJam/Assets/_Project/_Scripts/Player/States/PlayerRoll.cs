using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

[CreateAssetMenu(menuName = "PlayerStates/RollState")]
public class PlayerRoll : PlayerState
{
    [SerializeField] private float rollTime = 0.5f;
    [SerializeField] private float rollVelocity = 5f;
    private float timer;
    [SerializeField] private LayerMask enemyLayer;
    public override void DoEnterLogic()
    {
        base.DoEnterLogic();
        timer = rollTime;
        if (inputManager.MoveInput > 0 && !core.isFacingRight)
        {
            core.FlipSprite();
        }
        else if (inputManager.MoveInput < 0 && core.isFacingRight)
        {
            core.FlipSprite();
        }
        animator.Play("PlayerRoll");
        int direction = core.isFacingRight ? 1 : -1;
        rb.velocity = Vector2.right * rollVelocity * direction;
        core.GetComponent<Collider2D>().excludeLayers = enemyLayer;
    }

    public override void DoExitLogic()
    {
        base.DoExitLogic();
        core.GetComponent<Collider2D>().excludeLayers = new LayerMask();
    }

    public override void DoUpdateState()
    {
        base.DoUpdateState();
        timer -= Time.deltaTime;
        if(timer <= 0)
        {
            if(inputManager.MoveInput == 0)
            {
                core.stateMachine.ChangeState(core.states["Idle"]);
            }
            else
            {
                core.stateMachine.ChangeState(core.states["Move"]);
            }
        }
    }

}
