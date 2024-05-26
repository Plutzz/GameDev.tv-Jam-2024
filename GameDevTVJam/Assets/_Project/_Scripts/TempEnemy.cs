using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TempEnemy : MonoBehaviour, IDamageable
{
    private Rigidbody2D rb;
    [SerializeField] float moveSpeed = 1f;
    public int health { get; private set; }
    public void TakeDamage(int damage)
    {
        health -= damage;
        if(health <= 0)
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        health = 3;
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        rb.velocity = Vector2.left * moveSpeed;
    }
}
