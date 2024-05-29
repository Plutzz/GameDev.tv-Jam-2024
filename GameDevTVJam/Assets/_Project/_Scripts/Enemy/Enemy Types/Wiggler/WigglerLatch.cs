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
        //rb.bodyType = RigidbodyType2D.Static;
        //rb.gravityScale = 0;
        //rb.position += new Vector2(0, 2);
    }
}
