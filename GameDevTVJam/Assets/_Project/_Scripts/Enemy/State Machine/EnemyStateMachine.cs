using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class EnemyStateMachine : MonoBehaviour
{
    public EnemyState currentState { get; private set; } 
    private EnemyState initialState;
    public EnemyState previousState { get; private set; } 

    // References to all player states
    public EnemyIdleState IdleState;


    #region ScriptableObject Variables

    [SerializeField] private EnemyIdleSOBase enemyIdleBase;

    public EnemyIdleSOBase EnemyIdleBaseInstance { get; private set; }

    #endregion

    #region Enemy Variables
    public Rigidbody2D rb { get; private set; }
    private Enemy enemy;


    #endregion


    private void Awake()
    {

        rb = GetComponentInChildren<Rigidbody2D>();
        enemy = GetComponentInChildren<Enemy>();

        EnemyIdleBaseInstance = Instantiate(enemyIdleBase);

        IdleState = new EnemyIdleState(this, enemy);

        EnemyIdleBaseInstance.Initialize(gameObject, this);

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

    public void ChangeState(EnemyState newState)
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
