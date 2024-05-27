using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyChaseState : EnemyState
{
    public EnemyChaseState(EnemyStateMachine stateMachine, Enemy enemy) : base(stateMachine, enemy) { }

    public override void EnterLogic()
    {
        enemy.EnemyChaseBaseInstance.DoEnterLogic();
    }

    public override void ExitLogic()
    {
        enemy.EnemyChaseBaseInstance.DoExitLogic();
    }

    public override void UpdateState()
    {
        enemy.EnemyChaseBaseInstance.DoUpdateState();
    }
    public override void FixedUpdateState()
    {
        enemy.EnemyChaseBaseInstance.DoFixedUpdateState();
    }
}
