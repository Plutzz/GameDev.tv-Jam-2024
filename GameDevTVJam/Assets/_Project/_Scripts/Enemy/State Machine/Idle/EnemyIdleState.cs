using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyIdleState : EnemyState
{
    public EnemyIdleState(EnemyStateMachine stateMachine, Enemy enemy) : base(stateMachine, enemy) { }

    public override void EnterLogic()
    {
        enemy.EnemyIdleBaseInstance.DoEnterLogic();
    }

    public override void ExitLogic()
    {
        enemy.EnemyIdleBaseInstance.DoExitLogic();
    }

    public override void UpdateState()
    {
        enemy.EnemyIdleBaseInstance.DoUpdateState();
    }
    public override void FixedUpdateState()
    {
        enemy.EnemyIdleBaseInstance.DoFixedUpdateState();
    }
}
