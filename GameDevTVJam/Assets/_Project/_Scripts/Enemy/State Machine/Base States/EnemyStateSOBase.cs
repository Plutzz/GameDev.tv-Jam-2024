using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Base class that all player state scriptable objects inherit from.
/// </summary>
public class EnemyStateSOBase : ScriptableObject
{

    protected EnemyStateMachine stateMachine;
    protected Rigidbody2D rb;
    protected GameObject gameObject;
    protected Enemy enemy;

    /// <summary>
    /// Initialize paramaters that are commonly used in states
    /// </summary>
    /// <param name="gameObject"></param>
    /// <param name="stateMachine"></param>
    /// <param name="enemy"></param>
    public virtual void Initialize(GameObject gameObject, EnemyStateMachine stateMachine, Enemy enemy)
    {
        this.gameObject = gameObject;
        this.stateMachine = stateMachine;
        this.enemy = enemy;
        rb = enemy.rb;
    }

    /// <summary>
    /// Setup state, e.g. starting animations.
    /// Consider this the "Start" method of this state.
    /// </summary>
    public virtual void DoEnterLogic() { }

    /// <summary>
    /// State-Cleanup.
    /// </summary>
    public virtual void DoExitLogic() { ResetValues(); }

    /// <summary>
    /// This method is called once every frame while this state is active.
    /// Consider this the "Update" method of this state.
    /// </summary>
    public virtual void DoUpdateState() { CheckTransitions(); }

    /// <summary>
    /// This method is called once every physics frame while this state is active.
    /// Consider this the "FixedUpdate" method of this state.
    /// </summary>
    public virtual void DoFixedUpdateState() { }

    /// <summary>
    /// This method is called during ExitLogic().
    /// Use this method to reset or null out values during state cleanup.
    /// </summary>
    public virtual void ResetValues() { }

    /// <summary>
    /// This method contains checks for all transitions from the current state.
    /// To be called in the UpdateState() or FixedUpdateState() methods.
    /// </summary>
    public virtual void CheckTransitions() { }

}