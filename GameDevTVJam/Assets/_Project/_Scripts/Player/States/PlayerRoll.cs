using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

[CreateAssetMenu(menuName = "PlayerStates/RollState")]
public class PlayerRoll : PlayerStateSOBase
{
    [SerializeField] private float rollTime = 0.5f;
    [SerializeField] private float rollVelocity = 5f;
    private float timer;
    [SerializeField] private LayerMask enemyLayer;
    public override void DoEnterLogic()
    {
        base.DoEnterLogic();
        timer = rollTime;
        if (player.inputManager.MoveInput > 0)
        {
            player.pivot.localScale = Vector3.one;
        }
        else if (player.inputManager.MoveInput < 0)
        {
            player.pivot.localScale = new Vector3(-1, 1, 1);
        }
        player.GetComponentInChildren<Animator>().Play("PlayerRoll");
        rb.velocity = Vector2.right * rollVelocity * player.pivot.transform.localScale.x;
        player.GetComponent<Collider2D>().excludeLayers = enemyLayer;
    }

    public override void DoExitLogic()
    {
        base.DoExitLogic();
        player.GetComponent<Collider2D>().excludeLayers = new LayerMask();
    }

    public override void DoUpdateState()
    {
        base.DoUpdateState();
        timer -= Time.deltaTime;
        if(timer <= 0)
        {
            if(player.inputManager.MoveInput == 0)
            {
                stateMachine.ChangeState(player.IdleState);
            }
            else
            {
                stateMachine.ChangeState(player.MovingState);
            }
        }
    }

}
