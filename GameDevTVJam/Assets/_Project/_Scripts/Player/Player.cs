using System.Collections;
using System.Collections.Generic;
using Unity.IO.LowLevel.Unsafe;
using UnityEngine;

public class Player : StateMachineCore
{

    #region Player Variables
    public InputManager inputManager;
    public PlayerAttacks playerAttacks;

    [Header("Roll")]
    [SerializeField] private float rollCooldown = 1f;
    private float rollTimer;
    #endregion

    #region Unity Methods
    private void Awake()
    {
        SetupInstances();
        stateMachine.Initialize(states["Idle"]);
    }

    private void Update()
    {
        stateMachine.currentState.DoUpdateState();

        rollTimer -= Time.deltaTime;

        if (rollTimer < 0 && Input.GetKeyDown(KeyCode.LeftShift))
        {
            stateMachine.ChangeState(states["Roll"]);
            rollTimer = rollCooldown;
        }
    }

    #endregion

}
