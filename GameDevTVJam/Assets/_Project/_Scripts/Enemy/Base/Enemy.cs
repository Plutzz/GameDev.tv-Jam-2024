using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class Enemy: StateMachineCore, IDamageable, ITriggerCheckable
{
    #region Knockback Variables
    [SerializeField] protected float knockbackTime = 0.1f;
    [SerializeField] protected float knockbackDrag = 25f;
    public float knockbackTimer;
    public bool knockbackEnabled = true;
    [HideInInspector] public bool canBeKnockedBack = true;
    #endregion

    #region IDamageable Variables
    // IDamageable
    [field: SerializeField] public float maxHealth { get; set; } = 100f;
    public float currentHealth { get; set; }
    #endregion
    public int collisionDamage = 1;
    public bool IsAggroed { get; set; }
    public bool IsWithinStrikingDistance { get; set; }

    protected DamageFlash damageFlash;

    #region Other Variables
    public GameObject player { get; private set; }
    #endregion

    protected virtual void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        damageFlash = GetComponent<DamageFlash>();
        SetupInstances();
        currentHealth = maxHealth;
    }

    protected virtual void Update()
    {
        knockbackTimer -= Time.deltaTime;
        stateMachine.currentState.DoUpdateBranch();


        if(!canBeKnockedBack && knockbackTimer < 0f)
        {
            canBeKnockedBack = true;
            rb.velocity = Vector2.zero;
        }

    }

    protected virtual void FixedUpdate()
    {
        stateMachine.currentState.DoFixedUpdateBranch();
    }

    #region Health/Damage Functions
    public virtual void TakeDamage(int damage, float knockback, float xPos)
    {
        currentHealth -= damage;
        damageFlash?.CallDamageFlash();

        if (currentHealth <= 0)
        {
            Die();
        }

  
        if(!knockbackEnabled) return;

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
        canBeKnockedBack = false;
    }


    public virtual void Die()
    {
        Destroy(gameObject);
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
