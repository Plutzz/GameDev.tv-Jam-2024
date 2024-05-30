using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Enemy States/Wiggler/Latch")]
public class WigglerLatch : EnemyState
{
    public override void DoEnterLogic()
    {
        base.DoEnterLogic();
        //animator.Play("WigglerLatch");
        rb.velocity = Vector2.zero;
        rb.bodyType = RigidbodyType2D.Kinematic;
        //rb.gravityScale = 0;
        //rb.position += new Vector2(0, 2);
    }

    public override void DoExitLogic()
    {
        base.DoExitLogic();
        rb.bodyType = RigidbodyType2D.Dynamic;
    }

    public void UnLatch()
    {
        core.stateMachine.ChangeState(core.states["Idle"]);
    }
}
