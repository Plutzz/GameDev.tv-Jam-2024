using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using AYellowpaper.SerializedCollections;
using Unity.VisualScripting;

/// <summary>
/// Base class that all state scriptable objects inherit from.
/// </summary>
public class State : ScriptableObject
{
    protected StateMachineCore core;

    protected Rigidbody2D rb => core.rb;
    protected Animator animator => core.animator;
    protected bool isFacingRight => core.isFacingRight;

    protected float stateUptime = 0;

    [Tooltip("Holds references to CHILD states of this state (states accessable from this state's node of the state machine heirarchy")]
    [field: SerializeField]
    public SerializedDictionary<string, State> states;

    public StateMachine stateMachine;

    [HideInInspector] public State parent;
    public State currentState => stateMachine.currentState;

    [SerializeField] protected AnimationClip stateAnimation;



    protected void ChangeState(State _newState)
    {
        stateMachine.ChangeState(_newState);
    }

    /// <summary>
    /// Passes the StateMachineCore to this state.
    /// Can be overriden to initialize additional parameters
    /// </summary>
    /// <param name="_core"></param>
    public virtual void SetCore(StateMachineCore _core, State _parent)
    {
        stateMachine = new StateMachine();
        core = _core;
        parent = _parent;

        SerializedDictionary<string, State> tempStates = new SerializedDictionary<string, State>();

        foreach (string key in states.Keys)
        {
            tempStates.Add(key, Instantiate(states[key]));
        }

        states = tempStates;

        foreach (State _state in states.Values)
        {
            _state.SetCore(core, this);
        }
    }
    /// <summary>
    /// Setup state, e.g. starting animations.
    /// Consider this the "Start" method of this state.
    /// </summary>
    public virtual void DoEnterLogic() { }

    /// <summary>
    /// State-Cleanup.
    /// </summary>
    public virtual void DoExitLogic() { currentState?.DoExitLogic(); ResetValues(); }

    /// <summary>
    /// This method is called once every frame while this state is active.
    /// Consider this the "Update" method of this state.
    /// </summary>
    public virtual void DoUpdateState() { CheckTransitions(); HandleTimer(); }

    /// <summary>
    /// This method is called once every physics frame while this state is active.
    /// Consider this the "FixedUpdate" method of this state.
    /// </summary>
    public virtual void DoFixedUpdateState() { }

    /// <summary>
    /// This method is called during ExitLogic().
    /// Use this method to reset or null out values during state cleanup.
    /// </summary>
    public virtual void ResetValues() { stateUptime = 0f; }

    /// <summary>
    /// This method contains checks for all transitions from the current state.
    /// To be called in the UpdateState() or FixedUpdateState() methods.
    /// </summary>
    public virtual void CheckTransitions() { }


    protected void HandleTimer()
    {
        stateUptime += Time.deltaTime;
    }

    /// <summary>
    /// Calls DoUpdate for every state down the branch
    /// </summary>
    public void DoUpdateBranch()
    {
        currentState?.DoUpdateBranch();
        DoUpdateState();
    }

    /// <summary>
    /// Calls DoUpdate for every state down the branch
    /// </summary>
    public void DoFixedUpdateBranch()
    {
        currentState?.DoFixedUpdateBranch();
        DoFixedUpdateState();
    }

}