using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy: StateMachineCore, IDamageable, ITriggerCheckable
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
    public bool IsAggroed { get; set; }
    public bool IsWithinStrikingDistance { get; set; }

    #region Other Variables
    public GameObject player { get; private set; }
    #endregion

    private void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        SetupInstances();
        currentHealth = maxHealth;
        stateMachine.Initialize(states["Idle"]);
    }

    private void Update()
    {
        knockbackTimer -= Time.deltaTime;
        stateMachine.currentState.DoUpdateState();

    }

    private void FixedUpdate()
    {
        stateMachine.currentState.DoFixedUpdateState();
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
