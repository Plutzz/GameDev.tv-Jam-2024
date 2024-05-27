using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Enemy States/Attack/Melee")]
public class EnemyAttackMelee : EnemyAttackSOBase
{
    public override void DoEnterLogic()
    {
        base.DoEnterLogic();
        Debug.Log("Melee");
        stateMachine.ChangeState(enemy.IdleState);
    }
}
