using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Enemy States/Attack/Melee")]
public class EnemyAttackMelee : EnemyState
{
    public override void DoEnterLogic()
    {
        base.DoEnterLogic();
        Debug.Log("Melee");
        core.stateMachine.ChangeState(core.states["Idle"]);
    }
}
