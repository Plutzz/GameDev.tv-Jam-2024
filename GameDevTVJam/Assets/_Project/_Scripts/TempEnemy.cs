using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TempEnemy : MonoBehaviour, IDamageable
{
    private Rigidbody2D rb;
    [SerializeField] float moveSpeed = 1f;
    public int health = 100;
    [SerializeField] float knockbackTime = 0.1f;
    [SerializeField] float knockbackDrag = 25f;
    private float knockbackTimer;
    public void TakeDamage(int damage, float knockback, float xPos)
    {
        health -= damage;
        if(health <= 0)
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

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        knockbackTimer -= Time.deltaTime;
        if(knockbackTimer <= 0)
        {
            knockbackDrag = 0f;
            rb.velocity = new Vector2(-moveSpeed, rb.velocity.y);
        }
        
    }
}
