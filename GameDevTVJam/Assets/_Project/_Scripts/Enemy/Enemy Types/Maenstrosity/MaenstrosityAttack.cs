using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Enemy States/Maenstrosity/Attack")]
public class MaenstrosityAttack : EnemyState
{
    public override void DoEnterLogic()
    {
        base.DoEnterLogic();
        int randomAttack = Random.Range(0, 2);      // 0 = melee, 1 = tendrils
        if(randomAttack == 0)
        {
            stateMachine.Initialize(states["Melee"]);
        }
        else
        {
            stateMachine.Initialize(states["Tendril"]);
        }
    }
}
