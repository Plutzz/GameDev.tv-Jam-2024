using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hatcher : Enemy
{
    [SerializeField] private GameObject wigglerPrefab;
    [SerializeField] private int wigglersSpawnedOnDeath = 3;
    [SerializeField] private float scatterRange = 5;

    protected override void Awake()
    {
        base.Awake();
        stateMachine.Initialize(states["Idle"]);
    }

    public override void TakeDamage(int damage, float knockback, float xPos)
    {
        currentHealth -= damage;
        if (currentHealth <= 0)
        {
            Death();
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

    public void Death()
    {
        for(int i = 0; i < wigglersSpawnedOnDeath; i++)
        {
            Debug.Log("spawned wiggler");
            GameObject wiggler = Instantiate(wigglerPrefab, transform.position, wigglerPrefab.transform.rotation);     //come back to testing scatter
            wiggler.GetComponent<Rigidbody2D>().AddForce((new Vector2(Random.Range(-scatterRange, scatterRange), Random.Range(-scatterRange, scatterRange))), ForceMode2D.Impulse);
        }

        Destroy(this.gameObject);
    }
}
