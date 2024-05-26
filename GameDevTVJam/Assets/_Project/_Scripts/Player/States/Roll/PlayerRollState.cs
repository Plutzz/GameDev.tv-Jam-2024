using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRollState : PlayerState
{
    public PlayerRollState(PlayerStateMachine stateMachine) : base(stateMachine) { }

    public override void EnterLogic()
    {
        stateMachine.PlayerRollBaseInstance.DoEnterLogic();
    }

    public override void ExitLogic()
    {
        stateMachine.PlayerRollBaseInstance.DoExitLogic();
    }

    public override void UpdateState()
    {
        stateMachine.PlayerRollBaseInstance.DoUpdateState();
    }
    public override void FixedUpdateState()
    {
        stateMachine.PlayerRollBaseInstance.DoFixedUpdateState();
    }
}
