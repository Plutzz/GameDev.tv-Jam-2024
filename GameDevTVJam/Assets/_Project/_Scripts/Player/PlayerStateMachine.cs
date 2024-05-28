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
    public PlayerState IdleState;
    public PlayerState MovingState;
    public PlayerState AttackState;
    public PlayerState RollState;
    #region ScriptableObject Variables

    [SerializeField] private PlayerStateSOBase playerIdleSO;
    [SerializeField] private PlayerStateSOBase playerMovingSO;
    [SerializeField] private PlayerStateSOBase playerAttackSO;
    [SerializeField] private PlayerStateSOBase playerRollSO;

    #endregion

    #region Player Variables
    public Rigidbody2D rb { get; private set; }
    public InputManager inputManager { get; private set; }
    public Transform pivot;
    [HideInInspector] public PlayerAttacks playerAttacks;

    [Header("Roll")]
    [SerializeField] private float rollCooldown = 1f;
    private float rollTimer;


    #endregion


    private void Awake()
    {

        rb = GetComponentInChildren<Rigidbody2D>();
        inputManager = GetComponent<InputManager>();
        playerAttacks = GetComponent<PlayerAttacks>();

        IdleState = new PlayerState(playerIdleSO);
        MovingState = new PlayerState(playerMovingSO);
        AttackState = new PlayerState(playerAttackSO);
        RollState = new PlayerState(playerRollSO);

        playerIdleSO.Initialize(gameObject, this);
        playerMovingSO.Initialize(gameObject, this);
        playerAttackSO.Initialize(gameObject, this);
        playerRollSO.Initialize(gameObject, this);

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

        rollTimer -= Time.deltaTime;

        if(rollTimer < 0 && Input.GetKeyDown(KeyCode.LeftShift))
        {
            ChangeState(RollState);
            rollTimer = rollCooldown;
        }
    }
    private void FixedUpdate()
    {
        currentState.FixedUpdateState();
    }

    public void ChangeState(PlayerState newState)
    {
        currentState.ExitLogic();
        previousState = currentState;
        currentState = newState;
        currentState.EnterLogic();
    }


    #region Logic Checks


    #endregion
}