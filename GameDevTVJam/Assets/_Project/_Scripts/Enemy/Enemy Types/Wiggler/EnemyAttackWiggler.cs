using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Enemy States/Attack/Wiggler")]
public class EnemyAttackWiggler : EnemyState
{
    [SerializeField] private float jumpStrengthX = 10f;
    [SerializeField] private float jumpStrengthY = 10f;
    private int direction;
    private Collider2D hitbox;
    public override void DoEnterLogic()
    {
        base.DoEnterLogic();

        if (enemy.player.transform.position.x > enemy.transform.position.x)
        {
            direction = -1;
        }
        else
        {
            direction = 1;
        }

        rb.velocity = new Vector2(direction * Mathf.Abs(enemy.player.transform.position.x - enemy.transform.position.x) / (2 * jumpStrengthY / (-rb.gravityScale * Physics2D.gravity.magnitude)), jumpStrengthY);
        //core.stateMachine.ChangeState(core.states["Idle"]);
    }

    public override void DoExitLogic()
    {
        base.DoExitLogic();
    }

    public override void DoUpdateState()
    {
        base.DoUpdateState();
        if(core.groundSensor.grounded && rb.velocity.y < 0)
        {
            core.stateMachine.ChangeState(core.states["Idle"]);
        }
    }
}
