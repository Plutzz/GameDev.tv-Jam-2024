using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;


public class StateMachine
{
    public State currentState  { get; private set; } 
    public State initialState { get; private set; }
    public State previousState { get; private set; } 

    public void Initialize(State initialState)
    {
        currentState = initialState;
        currentState.EnterLogic();
    }

    public void ChangeState(State newState)
    {
        currentState.ExitLogic();
        previousState = currentState;
        currentState = newState;
        currentState.EnterLogic();
    }
}