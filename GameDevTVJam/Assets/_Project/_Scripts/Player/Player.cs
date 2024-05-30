using System.Collections;
using System.Collections.Generic;
using System.Threading;
using Unity.IO.LowLevel.Unsafe;
using UnityEngine;

public class Player : StateMachineCore, IDamageable
{
    public static Player Instance { get; private set; }
    [field: SerializeField] public float maxHealth { get; set; } = 5;
    public float currentHealth { get; set; }
    [SerializeField] private float invincibleTime = 1.5f;

    #region Player Variables
    public InputManager inputManager;
    public PlayerAttacks playerAttacks;

    [Header("Roll")]
    [SerializeField] private float rollCooldown = 1f;
    private float rollTimer;
    #endregion

    public bool invincible = false;
    private float invincibleTimer;

    #region Unity Methods
    private void Awake()
    {
        if (Instance != null)
            Destroy(this);

        Instance = this;

        SetupInstances();
        stateMachine.Initialize(states["Idle"]);
    }

    private void Start()
    {
        transform.parent = Persistence.Instance?.transform;
        currentHealth = maxHealth;
        invincibleTimer = invincibleTime;
    }

    private void Update()
    {
        stateMachine.currentState.DoUpdateBranch();

        rollTimer -= Time.deltaTime;

        if(invincible == true)
        {
            invincibleTimer -= Time.deltaTime;
        }

        if(invincibleTimer <= 0f)
        {
            invincible = false;
            invincibleTimer = invincibleTime;
        }


        if (rollTimer < 0 && Input.GetKeyDown(KeyCode.LeftShift))
        {
            stateMachine.ChangeState(states["Roll"]);
            rollTimer = rollCooldown;
        }
    }

    private void FixedUpdate()
    {
        stateMachine.currentState.DoFixedUpdateBranch();
    }

    #endregion

    public void TakeDamage(int damage, float knockback, float xPos)
    {
        
        if (currentHealth == 0 || invincible)
        {
            return;
        }

        currentHealth -= damage;

        invincible = true;
    }

}
