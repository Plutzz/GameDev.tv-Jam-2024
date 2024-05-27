using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy: MonoBehaviour, IDamageable, IEnemyMoveable
{
    [SerializeField] float knockbackTime = 0.1f;
    [SerializeField] float knockbackDrag = 25f;
    private float knockbackTimer;

    // IDamageable
    [field: SerializeField] public float maxHealth { get; set; } = 100f;
    public float currentHealth { get; set; }

    // IEnemyMoveable
    public Rigidbody2D rb { get; set; }
    public bool isFacingRight { get; set; } = true;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        currentHealth = maxHealth;
    }

    public void TakeDamage(int damage, float knockback, float xPos)
    {
        currentHealth -= damage;
        if(currentHealth <= 0)
        {
            Destroy(gameObject);
        }

        rb.velocity = Vector2.zero;
        rb.drag = knockbackDrag;

        // Handle knockback
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



    private void Update()
    {
        knockbackTimer -= Time.deltaTime;
    }

    public void MoveEnemy(Vector2 velocity)
    {
        if(knockbackTimer <= 0)
        {
            knockbackDrag = 0f;
            rb.velocity = velocity;
        }
        rb.velocity = velocity;
        CheckForLeftOrRightFacing(velocity);
    }

    public void CheckForLeftOrRightFacing(Vector2 velocity)
    {
        if(isFacingRight && velocity.x < 0f)
        {
            transform.localEulerAngles = new Vector3(transform.rotation.x, 180f, transform.rotation.z);
            isFacingRight = !isFacingRight;
        }
        else if(!isFacingRight && velocity.x > 0f)
        {
            transform.localEulerAngles = new Vector3(transform.rotation.x, 0f, transform.rotation.z);
            isFacingRight = !isFacingRight;
        }
    }
}
