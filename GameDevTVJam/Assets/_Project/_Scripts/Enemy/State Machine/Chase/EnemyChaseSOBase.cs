using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class EnemyChaseSOBase : EnemyStateSOBase
{
    protected EnemyStateMachine stateMachine;
    protected Rigidbody2D rb;
    protected GameObject gameObject;
    protected Enemy enemy;

    public virtual void Initialize(GameObject gameObject, EnemyStateMachine stateMachine, Enemy enemy)
    {
        this.gameObject = gameObject;
        this.stateMachine = stateMachine;
        this.enemy = enemy;
        rb = enemy.rb;
    }
    public override void CheckTransitions()
    {
    }


}