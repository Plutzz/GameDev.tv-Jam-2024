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


    #region ScriptableObject Variables

    [SerializeField] private PlayerIdleSOBase playerIdleBase;
    [SerializeField] private PlayerMovingSOBase playerMovingBase;
    [SerializeField] private PlayerAttackSOBase playerAttackBase;

    public PlayerIdleSOBase PlayerIdleBaseInstance { get; private set; }
    public PlayerMovingSOBase PlayerMovingBaseInstance { get; private set; }
    public PlayerAttackSOBase PlayerAttackBaseInstance { get; private set; }

    #endregion

    #region Player Variables
    public Rigidbody2D rb { get; private set; }
    public InputManager inputManager { get; private set; }

    [SerializeField] private LayerMask groundLayer;
    public Transform graphics;
    [SerializeField] private float playerHeight;


    #endregion


    private void Awake()
    {

        rb = GetComponentInChildren<Rigidbody2D>();
        inputManager = GetComponent<InputManager>();

        //PlayerIdleBaseInstance = Instantiate(playerIdleBase);
        //PlayerMovingBaseInstance = Instantiate(playerMovingBase);

        PlayerIdleBaseInstance = playerIdleBase;
        PlayerMovingBaseInstance = playerMovingBase;
        PlayerAttackBaseInstance = playerAttackBase;

        IdleState = new PlayerIdleState(this);
        MovingState = new PlayerMovingState(this);
        AttackState = new PlayerAttackState(this);

        PlayerIdleBaseInstance.Initialize(gameObject, this);
        PlayerMovingBaseInstance.Initialize(gameObject, this);
        PlayerAttackBaseInstance.Initialize(gameObject, this);

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

    //Consider adding core functionalities here
    // Ex: GroundedCheck
    public bool GroundedCheck()
    {
        Debug.DrawRay(transform.position, Vector3.down * playerHeight * 0.5f + Vector3.down * 0.2f);
        return Physics.Raycast(transform.position, Vector3.down, playerHeight * 0.5f + 0.2f, groundLayer);
    }

    #endregion
}