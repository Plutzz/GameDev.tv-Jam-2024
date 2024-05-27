using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class EnemyStateMachine
{
    public EnemyState currentState { get; private set; }
    public EnemyState initialState { get; private set; }
    public EnemyState previousState { get; private set; } 
     

    public void Initialize(EnemyState initialState)
    {
        currentState = initialState;
        currentState.EnterLogic();
    }
    public void ChangeState(EnemyState newState)
    {
        Debug.Log("Changing to: " + newState);
        currentState.ExitLogic();
        previousState = currentState;
        currentState = newState;
        currentState.EnterLogic();
    }
}
