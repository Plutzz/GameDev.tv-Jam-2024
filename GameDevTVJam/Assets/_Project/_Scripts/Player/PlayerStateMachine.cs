using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;


public class PlayerStateMachine : MonoBehaviour
{
    public PlayerState currentState { get; private set; } // State that player is currently in
    private PlayerState initialState; // State that player starts as
    public PlayerState previousState { get; private set; } // State that player was previously in

    // References to all player states
    public PlayerIdleState IdleState;
    public PlayerMovingState MovingState;
    public PlayerAttackState AttackState;
    public PlayerRollState RollState;


    #region ScriptableObject Variables

    [SerializeField] private PlayerIdleSOBase playerIdleBase;
    [SerializeField] private PlayerMovingSOBase playerMovingBase;
    [SerializeField] private PlayerAttackSOBase playerAttackBase;
    [SerializeField] private PlayerRollSOBase playerRollBase;

    public PlayerIdleSOBase PlayerIdleBaseInstance { get; private set; }
    public PlayerMovingSOBase PlayerMovingBaseInstance { get; private set; }
    public PlayerAttackSOBase PlayerAttackBaseInstance { get; private set; }
    public PlayerRollSOBase PlayerRollBaseInstance { get; private set; }

    #endregion

    #region Player Variables
    public Rigidbody2D rb { get; private set; }
    public InputManager inputManager { get; private set; }

    [SerializeField] private LayerMask groundLayer;
    public Transform pivot;
    [HideInInspector] public PlayerAttacks playerAttacks;
    [SerializeField] private float playerHeight;


    #endregion


    private void Awake()
    {

        rb = GetComponentInChildren<Rigidbody2D>();
        inputManager = GetComponent<InputManager>();
        playerAttacks = GetComponent<PlayerAttacks>();

        PlayerIdleBaseInstance = playerIdleBase;
        PlayerMovingBaseInstance = playerMovingBase;
        PlayerAttackBaseInstance = playerAttackBase;
        PlayerRollBaseInstance = playerRollBase;

        IdleState = new PlayerIdleState(this);
        MovingState = new PlayerMovingState(this);
        AttackState = new PlayerAttackState(this);
        RollState = new PlayerRollState(this);

        PlayerIdleBaseInstance.Initialize(gameObject, this);
        PlayerMovingBaseInstance.Initialize(gameObject, this);
        PlayerAttackBaseInstance.Initialize(gameObject, this);
        PlayerRollBaseInstance.Initialize(gameObject, this);

        initialState = IdleState;
    }




    public void Start()
    {
        currentState = initialState;
        currentState.EnterLogic();
    }


    private void Update()
    {
        currentState.UpdateState();

        if(Input.GetKeyDown(KeyCode.LeftShift) && currentState != AttackState)
        {
            ChangeState(RollState);
        }
    }
    private void FixedUpdate()
    {
        currentState.FixedUpdateState();
    }

    public void ChangeState(PlayerState newState)
    {
        Debug.Log("Changing to: " + newState);
        currentState.ExitLogic();
        previousState = currentState;
        currentState = newState;
        currentState.EnterLogic();
    }


    #region Logic Checks


    #endregion
}