using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;


public class PlayerStateMachine
{
    public PlayerState currentState  { get; private set; } 
    public PlayerState initialState { get; private set; }
    public PlayerState previousState { get; private set; } 

    public void Initialize(PlayerState initialState)
    {
        currentState = initialState;
        currentState.EnterLogic();
    }

    public void ChangeState(PlayerState newState)
    {
        currentState.ExitLogic();
        previousState = currentState;
        currentState = newState;
        currentState.EnterLogic();
    }
}