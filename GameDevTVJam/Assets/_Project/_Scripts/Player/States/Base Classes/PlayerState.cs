using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerState
{
    // Fields to be assigned during the Construct() methods
    protected PlayerStateSOBase stateInstance;

    /// <summary>
    /// Constructor used to pass references of the stateMachine
    /// to the next state.
    /// </summary>
    /// <param name="stateMachine"></param>
    /// 
    public PlayerState(PlayerStateSOBase stateInstance)
    {
        this.stateInstance = stateInstance;
    }


    /// <summary>
    /// Setup state, e.g. starting animations.
    /// Consider this the "Start" method of this state.
    /// </summary>
    public virtual void EnterLogic()
    {
        stateInstance.DoEnterLogic();
    }

    /// <summary>
    /// State-Cleanup.
    /// </summary>
    public virtual void ExitLogic()
    {
        stateInstance.DoExitLogic();
    }

    /// <summary>
    /// This method is called once every frame while this state is active.
    /// Consider this the "Update" method of this state.
    /// </summary>
    public virtual void UpdateState()
    {
        stateInstance.DoUpdateState();
    }

    /// <summary>
    /// This method is called once every physics frame while this state is active.
    /// Consider this the "FixedUpdate" method of this state.
    /// </summary>
    public virtual void FixedUpdateState()
    {
        stateInstance.DoFixedUpdateState();
    }
    /// <summary>
    /// This method contains checks for all transitions from the current state.
    /// To be called in the UpdateState() or FixedUpdateState() methods.
    /// </summary>
    public virtual void CheckTransitions()
    {
        stateInstance.CheckTransitions();
    }
}
