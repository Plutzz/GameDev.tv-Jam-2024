using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{


    #region States
    public StateMachine stateMachine {  get; private set; }

    // References to all player states
    public State IdleState;
    public State MovingState;
    public State AttackState;
    public State RollState;
    #endregion

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

    #region Unity Methods
    private void Awake()
    {
        rb = GetComponentInChildren<Rigidbody2D>();
        inputManager = GetComponent<InputManager>();
        playerAttacks = GetComponent<PlayerAttacks>();

        SetupStateMachine();

    }
    private void Update()
    {
        stateMachine.currentState.UpdateState();

        rollTimer -= Time.deltaTime;

        if (rollTimer < 0 && Input.GetKeyDown(KeyCode.LeftShift))
        {
            stateMachine.ChangeState(RollState);
            rollTimer = rollCooldown;
        }
    }

    private void FixedUpdate()
    {
        stateMachine.currentState.FixedUpdateState();
    }

    #endregion

    #region Helper Methods
    private void SetupStateMachine()
    {
        stateMachine = new StateMachine();

        IdleState = new State(playerIdleSO);
        MovingState = new State(playerMovingSO);
        AttackState = new State(playerAttackSO);
        RollState = new State(playerRollSO);

        playerIdleSO.Initialize(gameObject, stateMachine, this);
        playerMovingSO.Initialize(gameObject, stateMachine, this);
        playerAttackSO.Initialize(gameObject, stateMachine, this);
        playerRollSO.Initialize(gameObject, stateMachine, this);

        stateMachine.Initialize(IdleState);
    }
    #endregion
}
