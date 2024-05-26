using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using JetBrains.Annotations;


public class PlayerStateMachine : MonoBehaviour
{
    public PlayerState currentState { get; private set; } // State that player is currently in
    private PlayerState initialState; // State that player starts as
    public PlayerState previousState { get; private set; } // State that player was previously in

    // References to all player states
    public PlayerIdleState IdleState;
    public PlayerMovingState MovingState;


    #region ScriptableObject Variables

    [SerializeField] private PlayerIdleSOBase playerIdleBase;
    [SerializeField] private PlayerMovingSOBase playerMovingBase;

    public PlayerIdleSOBase PlayerIdleBaseInstance { get; private set; }
    public PlayerMovingSOBase PlayerMovingBaseInstance { get; private set; }

    #endregion

    #region Player Variables
    public Rigidbody rb { get; private set; }
    public InputManager inputManager { get; private set; }

    [SerializeField] private LayerMask groundLayer;
    public float moveSpeed = 5f;
    public Transform player;
    [SerializeField] private float playerHeight;


    #endregion


    private void Awake()
    {

        rb = GetComponentInChildren<Rigidbody>();
        inputManager = GetComponent<InputManager>();
        //playerAnim = GetComponent<PlayerAnim>();

        PlayerIdleBaseInstance = Instantiate(playerIdleBase);
        PlayerMovingBaseInstance = Instantiate(playerMovingBase);

        IdleState = new PlayerIdleState(this);
        MovingState = new PlayerMovingState(this);

        PlayerIdleBaseInstance.Initialize(gameObject, this);
        PlayerMovingBaseInstance.Initialize(gameObject, this);

        initialState = IdleState;
    }




    public void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
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
        //playerAnim.HandleAnimations(currentState);
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