using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy: MonoBehaviour, IDamageable, IEnemyMoveable, ITriggerCheckable
{
    #region Knockback Variables
    [SerializeField] protected float knockbackTime = 0.1f;
    [SerializeField] protected float knockbackDrag = 25f;
    private float knockbackTimer;
    #endregion

    #region IDamageable Variables
    // IDamageable
    [field: SerializeField] public float maxHealth { get; set; } = 100f;
    public float currentHealth { get; set; }
    #endregion

    #region IEnemyMoveable Variables
    // IEnemyMoveable
    public Rigidbody2D rb { get; set; }
    public bool isFacingRight { get; set; }
    #endregion

    #region State Machine Variables

    [Header("States")]
    [SerializeField] private EnemyStateSOBase enemyIdleBase;
    [SerializeField] private EnemyStateSOBase enemyChaseBase;
    [SerializeField] private EnemyStateSOBase enemyAttackBase;

    public EnemyStateMachine stateMachine { get; private set; }

    // States
    public EnemyState IdleState;
    public EnemyState ChaseState;
    public EnemyState AttackState;

    // SO Instances
    public EnemyStateSOBase EnemyIdleBaseInstance { get; private set; }
    public EnemyStateSOBase EnemyChaseBaseInstance { get; private set; }
    public EnemyStateSOBase EnemyAttackBaseInstance { get; private set; }

    public bool IsAggroed { get; set; }
    public bool IsWithinStrikingDistance { get; set; }
    #endregion

    #region Other Variables

    public GameObject player {  get; private set; }

    #endregion

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        stateMachine = new EnemyStateMachine();

        // Idle
        EnemyIdleBaseInstance = Instantiate(enemyIdleBase);
        IdleState = new EnemyState(EnemyIdleBaseInstance);
        EnemyIdleBaseInstance.Initialize(gameObject, stateMachine, this);

        // Chase
        EnemyChaseBaseInstance = Instantiate(enemyChaseBase);
        ChaseState = new EnemyState(EnemyChaseBaseInstance);
        EnemyChaseBaseInstance.Initialize(gameObject, stateMachine, this);

        // Attack
        EnemyAttackBaseInstance = Instantiate(enemyAttackBase);
        AttackState = new EnemyState(EnemyAttackBaseInstance);
        EnemyAttackBaseInstance.Initialize(gameObject, stateMachine, this);

        stateMachine.Initialize(IdleState);

        player = GameObject.FindGameObjectWithTag("Player");
        currentHealth = maxHealth;

    }

    private void Update()
    {
        knockbackTimer -= Time.deltaTime;
        stateMachine.currentState.UpdateState();

    }

    private void FixedUpdate()
    {
        stateMachine.currentState.FixedUpdateState();
    }

    #region Health/Damage Functions
    public void TakeDamage(int damage, float knockback, float xPos)
    {
        currentHealth -= damage;
        if (currentHealth <= 0)
        {
            Destroy(gameObject);
        }


        // Handle knockback
        rb.velocity = Vector2.zero;
        rb.drag = knockbackDrag;
        if (xPos <= transform.position.x)
        {
            rb.AddForce(Vector2.right * knockback, ForceMode2D.Impulse);
        }
        else
        {
            rb.AddForce(Vector2.left * knockback, ForceMode2D.Impulse);
        }
        knockbackTimer = knockbackTime;
    }
    #endregion

    #region Move Enemy Functions

    public void CheckForLeftOrRightFacing(Vector2 velocity)
    {
        if(isFacingRight && velocity.x < 0f)
        {
            transform.localEulerAngles = new Vector3(transform.rotation.x, 0f, transform.rotation.z);
            isFacingRight = !isFacingRight;
        }
        else if(!isFacingRight && velocity.x > 0f)
        {
            transform.localEulerAngles = new Vector3(transform.rotation.x, 180f, transform.rotation.z);
            isFacingRight = !isFacingRight;
        }
    }

    #endregion

    #region Trigger Checks Functions
    // ITriggerCheckable
    public void SetAggroStatus(bool isAggroed)
    {
       IsAggroed = isAggroed;
    }

    public void SetStrikingDistance(bool isWithinStrikingDistance)
    {
        IsWithinStrikingDistance = isWithinStrikingDistance;
    }
    #endregion
}
