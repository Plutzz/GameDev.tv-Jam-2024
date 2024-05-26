using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "IdleState-Ben", menuName = "PlayerStates/IdleState")]
public class PlayerIdleBen : PlayerIdleSOBase
{
    public override void DoEnterLogic()
    {
        base.DoEnterLogic();
        Debug.Log("Idleing");
        stateMachine.GetComponentInChildren<Animator>().Play("Idle");
        rb.velocity = Vector2.zero;
    }

}
