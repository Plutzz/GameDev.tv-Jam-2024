using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using AYellowpaper.SerializedCollections;

/// <summary>
/// Base class that all state scriptable objects inherit from.
/// </summary>
public class State : ScriptableObject
{
    protected StateMachineCore core;

    protected Rigidbody2D rb => core.rb;

    protected Animator animator => core.animator;

    protected SerializedDictionary<string, State> states => core.states;

    /// <summary>
    /// Passes the StateMachineCore to this state.
    /// Can be overriden to initialize additional parameters
    /// </summary>
    /// <param name="_core"></param>
    public virtual void SetCore(StateMachineCore _core)
    {
        core = _core;
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