using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

/// <summary>
/// Allows for the creation of a state machine to define more advanced player, npc, and enemy behavior
/// </summary>
public class StateMachine
{
    public State currentState  { get; private set; } 
    public State initialState { get; private set; }
    public State previousState { get; private set; }

    /// <summary>
    /// Starts the state machine with a specified state
    /// </summary>
    /// <param name="initialState"></param>
    public void Initialize(State initialState)
    {
        currentState = initialState;
        currentState.DoEnterLogic();
    }

    /// <summary>
    /// Change the active state to newState
    /// </summary>
    /// <param name="newState"></param>
    public void ChangeState(State newState)
    {
        currentState.DoExitLogic();
        previousState = currentState;
        currentState = newState;
        currentState.DoEnterLogic();
    }


    public List<State> GetActiveStateBranch(List<State> list = null)
    {
        if (list == null)
            list = new List<State>();

        if (currentState == null)
            return list;

        else
        {
            list.Add(currentState);
            return currentState.stateMachine.GetActiveStateBranch(list);
        }

    }

}