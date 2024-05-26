using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

[CreateAssetMenu(menuName = "PlayerStates/RollState")]
public class PlayerRollBen : PlayerRollSOBase
{
    [SerializeField] private float rollTime = 0.5f;
    [SerializeField] private float rollVelocity = 5f;
    private float timer;
    [SerializeField] private LayerMask enemyLayer;
    public override void DoEnterLogic()
    {
        base.DoEnterLogic();
        timer = rollTime;
        stateMachine.GetComponentInChildren<Animator>().Play("Roll");
        rb.velocity = Vector2.right * rollVelocity * stateMachine.pivot.localScale.x;
        stateMachine.GetComponent<Collider2D>().excludeLayers = enemyLayer;
    }

    public override void DoExitLogic()
    {
        base.DoExitLogic();
        stateMachine.GetComponent<Collider2D>().excludeLayers = new LayerMask();
    }

    public override void DoUpdateState()
    {
        base.DoUpdateState();
        timer -= Time.deltaTime;
        if(timer <= 0)
        {
            if(stateMachine.inputManager.MoveInput == 0)
            {
                stateMachine.ChangeState(stateMachine.IdleState);
            }
            else
            {
                stateMachine.ChangeState(stateMachine.MovingState);
            }
        }
    }

}
