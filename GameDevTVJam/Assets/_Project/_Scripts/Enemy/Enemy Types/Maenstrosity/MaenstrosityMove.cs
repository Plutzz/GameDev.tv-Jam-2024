using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Enemy States/Maenstrosity/Move")]
public class MaenstrosityMove : EnemyState
{
    public override void DoEnterLogic()
    {
        base.DoEnterLogic();
        stateMachine.Initialize(states["Up"]);
    }


    public override void DoUpdateState()
    {
        base.DoUpdateState();
    }

}
