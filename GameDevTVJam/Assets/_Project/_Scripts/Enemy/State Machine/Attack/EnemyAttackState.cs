using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttackState : EnemyState
{
    public EnemyAttackState(EnemyStateMachine stateMachine, Enemy enemy) : base(stateMachine, enemy) { }

    public override void EnterLogic()
    {
        enemy.EnemyAttackBaseInstance.DoEnterLogic();
    }

    public override void ExitLogic()
    {
        enemy.EnemyAttackBaseInstance.DoExitLogic();
    }

    public override void UpdateState()
    {
        enemy.EnemyAttackBaseInstance.DoUpdateState();
    }
    public override void FixedUpdateState()
    {
        enemy.EnemyAttackBaseInstance.DoFixedUpdateState();
    }
}
