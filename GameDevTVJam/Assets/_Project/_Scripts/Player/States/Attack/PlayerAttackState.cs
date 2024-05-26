using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttackState : PlayerState
{
    public PlayerAttackState(PlayerStateMachine stateMachine) : base(stateMachine) { }

    public override void EnterLogic()
    {
        stateMachine.PlayerAttackBaseInstance.DoEnterLogic();
    }

    public override void ExitLogic()
    {
        stateMachine.PlayerAttackBaseInstance.DoExitLogic();
    }

    public override void UpdateState()
    {
        stateMachine.PlayerAttackBaseInstance.DoUpdateState();
    }
    public override void FixedUpdateState()
    {
        stateMachine.PlayerAttackBaseInstance.DoFixedUpdateState();
    }
}
