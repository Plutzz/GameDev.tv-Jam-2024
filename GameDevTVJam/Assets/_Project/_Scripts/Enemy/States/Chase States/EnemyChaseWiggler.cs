using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Enemy States/Chase/Wiggler")]
public class EnemyChaseWiggler : EnemyState
{
    [SerializeField] private float xVelocity = 2f;
    private int direction = 1;
    public override void DoEnterLogic()
    {
        base.DoEnterLogic();
    }

    public override void DoUpdateState()
    {
        base.DoUpdateState();

        rb.velocity = direction * Vector2.right * xVelocity;

        facePlayer();

        if(enemy.IsAggroed == false)
        {
            core.stateMachine.ChangeState(core.states["Idle"]);
        } else if (enemy.IsWithinStrikingDistance == true)
        {
            core.stateMachine.ChangeState(core.states["Attack"]);
        }
    }

    public override void DoExitLogic()
    {
        base.DoExitLogic();
    }

    private void facePlayer()
    {
        // If player is to the left, flip charge direction
        if (enemy.player.transform.position.x < enemy.transform.position.x)
        {
            direction = -1;
        } else
        {
            direction = 1;
        }
    }
}
