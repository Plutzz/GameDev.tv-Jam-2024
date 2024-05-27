using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyIdleState : EnemyState
{
    public EnemyIdleState(EnemyStateMachine stateMachine, Enemy enemy) : base(stateMachine, enemy) { }

    public override void EnterLogic()
    {
        stateMachine.EnemyIdleBaseInstance.DoEnterLogic();
    }

    public override void ExitLogic()
    {
        stateMachine.EnemyIdleBaseInstance.DoExitLogic();
    }

    public override void UpdateState()
    {
        stateMachine.EnemyIdleBaseInstance.DoUpdateState();
    }
    public override void FixedUpdateState()
    {
        stateMachine.EnemyIdleBaseInstance.DoFixedUpdateState();
    }
}
